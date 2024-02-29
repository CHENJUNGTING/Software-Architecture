using System;
using System.IO;
using NUnit.Framework;

namespace Tasks
{
	[TestFixture]
	public sealed class ApplicationTest
	{
		public const string PROMPT = "> ";

		private FakeConsole console;
		private System.Threading.Thread applicationThread;

		[SetUp]
		public void StartTheApplication()
		{
			this.console = new FakeConsole();
			var taskList = new TaskList(console);
			this.applicationThread = new System.Threading.Thread(() => taskList.Run());
			applicationThread.Start();
		}

		[TearDown]
		public void KillTheApplication()
		{
			if (applicationThread == null || !applicationThread.IsAlive)
			{
				return;
			}

			applicationThread.Abort();
			throw new Exception("The application is still running.");
		}

		[Test, Timeout(1000)]
		public void ItWorks()
		{
			string dateTime = DateTime.Now.ToString("yyyy/MM/dd");
			Execute("show");

			Execute("add project secrets");
			Execute("add task id1 secrets Eat more donuts.");
			Execute("add task id2 secrets Destroy all humans.");

			Execute("show");
			ReadLines(
				"secrets",
				"    [ ] id1: Eat more donuts.",
				"    [ ] id2: Destroy all humans.",
				""
			);
            
			Execute("add project training");
			Execute("add task id3 training Four Elements of Simple Design");
			Execute("add task id4 training SOLID");
			Execute("add task id5 training Coupling and Cohesion");
			Execute("add task id6 training Primitive Obsession");
			Execute("add task id7 training Outside-In TDD");
			Execute("add task id8 training Interaction-Driven Design");

			Execute("check id1");
			Execute("check id3");
			Execute("check id5");
			Execute("check id6");

			Execute("show");
			ReadLines(
				"secrets",
				"    [x] id1: Eat more donuts." ,
				"    [ ] id2: Destroy all humans." ,
				"",
				"training",
				"    [x] id3: Four Elements of Simple Design",
				"    [ ] id4: SOLID" ,
				"    [x] id5: Coupling and Cohesion",
				"    [x] id6: Primitive Obsession",
				"    [ ] id7: Outside-In TDD",
				"    [ ] id8: Interaction-Driven Design",
				""
			);
			
            Execute("quit");
		}

		private void Execute(string command)
		{
			Read(PROMPT);
			Write(command);
		}

		private void Read(string expectedOutput)
		{
			var length = expectedOutput.Length;
			var actualOutput = console.RetrieveOutput(expectedOutput.Length);
			Assert.AreEqual(expectedOutput, actualOutput);
		}

		private void ReadLines(params string[] expectedOutput)
		{
			foreach (var line in expectedOutput)
			{
				Read(line + Environment.NewLine);
			}
		}

		private void Write(string input)
		{
			console.SendInput(input + Environment.NewLine);
		}
	}
}

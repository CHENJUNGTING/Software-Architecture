為了滿足Clean Architecture 三原則，總計為四個主資料夾及一個UI進入點(TaskListRun.cs)
- I/O    :   
  - 存放Console的I/O操作
  - TaskListRun.cs
    - 負責輸入與顯示輸出，與Controller雙向溝通。

- Adapter :
  - TaskExecute.cs 負責選擇需要的Command並回傳其執行結果
  - Controller
    - 定義 各種CommandController 負責執行所選的Command
    - 將UI資料轉送至此，負責與User Case層溝通，轉換來自於User Case的資料(DTO)。  
- Entity     :  
  - 存放底層模型  
- Use Cases  :  
  - 內部存放三個資料夾 (Command、Message、Input)  
    - Command -> 存放了各種指令類別  
    - Message -> 定義回傳給Controller的格式 (DTO)
    - Input -> 定義Command輸入的格式(DTO)

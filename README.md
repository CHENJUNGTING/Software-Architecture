總計為四個資料夾及一個UI進入點(TaskList.cs)   
*Console    :   
            存放Console的I/O操作  
*Controller :  
            將UI資料轉送至此，負責與User Case層溝通，轉換來自於User Case的資料(DTO)。  
*Entity     :  
            存放底層模型  
*Use Cases  :  
            內部存放三個資料夾 (Command、Factory、Message)  
            Command -> 存放了各種指令類別  
            Factory -> 工廠模式，負責生產各式各樣的Command  
            Message -> 定義回傳給Controller的格式  

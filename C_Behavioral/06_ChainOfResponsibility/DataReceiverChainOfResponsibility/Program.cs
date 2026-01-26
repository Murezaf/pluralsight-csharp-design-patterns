using DataReceiverChainOfResponsibility;

Console.Title = "DataReceiverChainOfResponsibility";

CacheHandler ChainOfDataHandlers = new CacheHandler();
ChainOfDataHandlers.SetNext(new FileHandler())
    .SetNext(new DatabaseHndler());

ChainOfDataHandlers.GetData("Ali");
Console.WriteLine();
ChainOfDataHandlers.GetData("Mohamad");
Console.WriteLine();
ChainOfDataHandlers.GetData("LKJOADJFK");
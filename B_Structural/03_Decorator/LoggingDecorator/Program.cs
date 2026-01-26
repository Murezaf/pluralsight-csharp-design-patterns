using LoggingDecorator;

Console.Title = "LoggingDecorator";

Migration migration =  new Migration();
UpdateDatabase updateDatabase = new UpdateDatabase();

ConsoleLoggerDecorator consoleLoggerDecorator = new ConsoleLoggerDecorator(migration);
FileLoggerDecorator fileLoggerDecorator = new FileLoggerDecorator(updateDatabase);

consoleLoggerDecorator.Process();
fileLoggerDecorator.Process();
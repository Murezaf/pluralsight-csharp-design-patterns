using Decorator;

Console.Title = "Decorator";

//Instantiate mail services
CloudMailService cloudMailService = new CloudMailService();
cloudMailService.SendMail("Hi there!");

OnPremisMailService onPremisMailService = new OnPremisMailService();
onPremisMailService.SendMail("Hi there!");

Console.WriteLine();

//add behavior
StatisticDecorator statisticDecorator = new StatisticDecorator(cloudMailService);
statisticDecorator.SendMail($"Hi there via {nameof(statisticDecorator)} wrapper.");

Console.WriteLine();

MessageDatabaseDecorator messageDatabaseDecorator = new MessageDatabaseDecorator(onPremisMailService);
messageDatabaseDecorator.SendMail($"Hi there via {nameof(messageDatabaseDecorator)} wrapper, message 1.");
messageDatabaseDecorator.SendMail($"Hi there via {nameof(messageDatabaseDecorator)} wrapper, message 2.");

foreach (var message in messageDatabaseDecorator.SentMessages)
{
    Console.WriteLine($"Stored message: \"{message}\"");
}
using Observer;

Console.Title = "Observer";

//New up three services we want(one notifier(subject) and two listener(observer))
OrderService orderService = new OrderService();
TicketStockService ticketStockService = new TicketStockService();   
TicketResellService ticketResellService = new TicketResellService();

orderService.AddObserver(ticketResellService);
orderService.AddObserver(ticketStockService);

orderService.CompleteTicketSale(1, 2);
Console.WriteLine();

//The nice thing here is that we can manage all of this at runtime. We added the observers at runtime. That means we can add more or also remove them.
orderService.RemoveObserver(ticketResellService);
orderService.CompleteTicketSale(2, 4);
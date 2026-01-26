using Strategy;

Console.Title = "Strategy";

Order order = new Order("VisualStudio License", "Ali", 1);
order.ExportService = new CSVExportService();
order.Export();

order.ExportService = new JsonExportService();
order.Export();
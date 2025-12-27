using ReportingSystem_FactoryMethodvsAbstractFactory;

HeaderCreator headerFactory = new ExcelHeaderCreator();
BodyCreator bodyFactory = new PdfBodyCreator();

IHeader header = headerFactory.CreateHeader();
IBody body = bodyFactory.CreateBody();

header.RenderHeader();
body.RenderBody();
Console.WriteLine();

//------------------------------------------------------------
PDFReportCreator reportCreator = new PDFReportCreator();
reportCreator.CreateReport();
Console.WriteLine();

//------------------------------------------------------------
IReportFactory factory = new PdfReportFactory(); 

IHeader header2 = factory.CreateHeader();
IBody body2 = factory.CreateBody();

header2.RenderHeader();
body2.RenderBody();
Console.WriteLine();
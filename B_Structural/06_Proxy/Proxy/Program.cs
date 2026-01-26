using Proxy;

Console.Title = "Proxy";

//WithoutProxy
Console.WriteLine("Constructing document");
Document document = new Document("MyDocument.pdf");
Console.WriteLine("Document constructed");
document.DisplayDocument();
//The expensive operation happens when the document is being constructed and not when it's being used. expensive operations running when no need => unnecessary slow

Console.WriteLine();

//WithVirtualProxy
Console.WriteLine("Constructing document proxy");
DocumentProxy documentProxy = new DocumentProxy("MyDocument.pdf");
Console.WriteLine("Document proxy constructed");
documentProxy.DisplayDocument();
//The way to interact with the Document and the DocumentProxy is transparent for the client. The client executes exactly the same statements.
//The expensive operation is only executed when we actually need it to be(DisplayDocument). => Lazy

Console.WriteLine();

//Add protection proxy(chained proxy)
Console.WriteLine("Constructing protected document proxy");
ProtectedDocumentProxy protectedDocumentProxy = new ProtectedDocumentProxy("MyDocument.pdf", "Viewer");
Console.WriteLine("protected Document proxy constructed");
protectedDocumentProxy.DisplayDocument();

Console.WriteLine();

Console.WriteLine("Constructing protected document proxy");
ProtectedDocumentProxy anotherProtectedDocumentProxy = new ProtectedDocumentProxy("MyDocument.pdf", "another role");
Console.WriteLine("protected Document proxy constructed");
anotherProtectedDocumentProxy.DisplayDocument();
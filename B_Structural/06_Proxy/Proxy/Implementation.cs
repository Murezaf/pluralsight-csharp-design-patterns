namespace Proxy;

//Subject
public interface IDocument
{
    void DisplayDocument();
}

//RealSubject 
public class Document : IDocument
{
    private string _fileName;
    public string? Title { get; private set; }
    public string? Content { get; private set; }
    public int AuthorId { get; private set; }
    public DateTimeOffset LastAccessed { get; private set; }

    public Document(string fileName)
    {
        _fileName = fileName;
        loadDocument(fileName);
    }

    private void loadDocument(string fileName)
    {
        Console.WriteLine("Executing expensive action: loading file from disk");
        
        //fake loading expensive action
        Thread.Sleep(1000);

        Title = "An expensive Document";
        Content = "Lots of content";
        AuthorId = 1;
        LastAccessed = DateTimeOffset.UtcNow;
    }

    public void DisplayDocument()
    {
        Console.WriteLine($"Title: {Title}, Content: {Content}.");
    }
}

//Proxy(VirtualProxy)
public class DocumentProxy : IDocument
{
    private string _fileName;
    //private Document? _document;
    private Lazy<Document> _document; //Exactly like what we did in Singleton DesignPattern.

    //public DocumentProxy(string fileName)
    //{
    //    _fileName = fileName;
    //}
    public DocumentProxy(string fileName)
    {
        _fileName = fileName;
        _document = new Lazy<Document>(() => new Document(fileName));
    }

    public void DisplayDocument()
    {
        //if (_document == null)
        //{
        //    _document = new Document(_fileName);
        //}

        //_document.DisplayDocument();

        _document.Value.DisplayDocument();
    }
}

//Proxy(ProtectionProxy)
public class ProtectedDocumentProxy : IDocument
{
    private string _fileName;
    private string _userRole;
    private DocumentProxy _documentProxy; //Chain of proxies

    public ProtectedDocumentProxy(string fileName, string userRole)
    {
        _fileName= fileName;
        _userRole = userRole;
        _documentProxy = new DocumentProxy(fileName);
    }

    public void DisplayDocument()
    {
        Console.WriteLine($"Entering Display document in {nameof(ProtectedDocumentProxy)}");

        if(_userRole != "Viewer")
            throw new UnauthorizedAccessException();

        _documentProxy.DisplayDocument();
        Console.WriteLine($"Exiting Display document in {nameof(ProtectedDocumentProxy)}");
    }
}
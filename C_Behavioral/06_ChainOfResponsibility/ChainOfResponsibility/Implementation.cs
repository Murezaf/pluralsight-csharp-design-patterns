using System.ComponentModel.DataAnnotations;

namespace ChainOfResponsibility;

public class Document
{

    public string Title { get; set; }
    public DateTimeOffset LastModified { get; set; }
    public bool ApprovedByLitigation { get; set; }
    public bool ApprovedByManagement { get; set; }

    public Document(string title, DateTimeOffset lastModified, bool approvedByLitigation, bool approvedByManagement)
    {
        Title = title;
        LastModified = lastModified;
        ApprovedByLitigation = approvedByLitigation;
        ApprovedByManagement = approvedByManagement;
    }
}

//Handler
public interface IHandler<T> where T : class
{
    //T == Document here, but can use it on other classes as well. IHandler<T> like DocumentTitleHandler and ...  
    void Handle(T request);
    IHandler<T> SetSuccessor (IHandler<T> successor);
}

//ConcreteHandler
public class DocumentTitleHandler : IHandler<Document>
{
    private IHandler<Document>? _successor;

    public void Handle(Document request)
    {
        if(request.Title == string.Empty)
        {
            throw new ValidationException(new ValidationResult("Title must be filledout", new List<string>() { request.Title }), null, null);
        }

        if (_successor != null) //Successor can be null(last handler)
        {
            _successor.Handle(request);
        }
    }

    public IHandler<Document> SetSuccessor(IHandler<Document> successor)
    {
        _successor = successor; //_successor will be null if we don't call this method first
        return _successor;
    }
}

//ConcreteHandler
public class DocumentLastModifiedHandler : IHandler<Document>
{
    private IHandler<Document>? _successor;

    public void Handle(Document request)
    {
        if (request.LastModified < DateTimeOffset.UtcNow.AddDays(-30))
        {
            throw new ValidationException(new ValidationResult("Document must be modified in the last 30 days.", new List<string>() { "LastModified" }), null, null);
        }

        if (_successor != null)
        {
            _successor.Handle(request);
        }
    }

    public IHandler<Document> SetSuccessor(IHandler<Document> successor)
    {
        _successor = successor; 
        return _successor;
    }
}

//ConcreteHandler
public class DocumentApprovedByLitigationHandler : IHandler<Document>
{
    private IHandler<Document>? _successor;

    public void Handle(Document request)
    {
        if (!request.ApprovedByLitigation)
        {
            throw new ValidationException(new ValidationResult("Document must be approved by litigation", new List<string>() { "ApprovedByLitigation" }), null, null);
        }

        if (_successor != null)
        {
            _successor.Handle(request);
        }
    }

    public IHandler<Document> SetSuccessor(IHandler<Document> successor)
    {
        _successor = successor;
        return _successor;
    }
}

//ConcreteHandler
public class DocumentApprovedByManagementHandler : IHandler<Document>
{
    private IHandler<Document>? _successor;

    public void Handle(Document request)
    {
        if (!request.ApprovedByManagement)
        {
            throw new ValidationException(new ValidationResult("Document must be approved by management", new List<string>() { "ApprovedByManagement" }), null, null);
        }

        if (_successor != null)
        {
            _successor.Handle(request);
        }
    }

    public IHandler<Document> SetSuccessor(IHandler<Document> successor)
    {
        _successor = successor;
        return _successor;
    }
}
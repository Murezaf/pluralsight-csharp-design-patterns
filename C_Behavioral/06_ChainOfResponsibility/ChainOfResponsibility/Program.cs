using ChainOfResponsibility;
using System.ComponentModel.DataAnnotations;

Console.Title = "Chain of Responsibility";

Document validDocument = new Document("How to avoid Java Development", DateTimeOffset.UtcNow, true, true);
Document invalidDocument = new Document("How to avoid Java Development", DateTimeOffset.UtcNow, false, true);

//Create Chain of Responsibility
DocumentTitleHandler documentHandlerChain = new DocumentTitleHandler();

documentHandlerChain.SetSuccessor(new DocumentLastModifiedHandler())
    .SetSuccessor(new DocumentApprovedByLitigationHandler())
    .SetSuccessor(new DocumentApprovedByManagementHandler());

try
{
    documentHandlerChain.Handle(validDocument);
    Console.WriteLine("First document is valid.");

    documentHandlerChain.Handle(invalidDocument);
    Console.WriteLine("Second document is valid.");
}
catch(ValidationException ex)
{
    Console.WriteLine(ex.Message);
}
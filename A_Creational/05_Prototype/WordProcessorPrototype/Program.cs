using WordProcessorPrototype;

Console.Title = "WordProcessorProtoType";

WordDocument template = new WordDocument()
{
    Title = "Project Template",
    Content = "This is a base document.",
    FontName = "Calibri",
    FontSize = 12,
    ThemeColor = "Blue",
    PageSettings = new PageSettings
    {
        MarginTop = 20,
        MarginBottom = 20,
        HasHeader = true,
        HasFooter = true
    }
};

WordDocument doc1 = (WordDocument)template.Clone(true);
doc1.Title = "Project Report";
doc1.Content = "This is my project report.";

WordDocument doc2 = (WordDocument)template.Clone(true);
doc2.Title = "Meeting Notes";
doc2.Content = "These are meeting notes.";

template.PageSettings.MarginTop = 100;

Console.WriteLine("Template MarginTop: " + template.PageSettings.MarginTop);
Console.WriteLine("Doc1 MarginTop: " + doc1.PageSettings.MarginTop);
Console.WriteLine("Doc2 MarginTop: " + doc2.PageSettings.MarginTop);
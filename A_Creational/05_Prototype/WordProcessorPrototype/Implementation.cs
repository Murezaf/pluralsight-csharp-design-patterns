using System.Text.Json;

namespace WordProcessorPrototype;

//Helper
public class PageSettings
{
    public int MarginTop { get; set; }
    public int MarginBottom { get; set; }
    public bool HasHeader { get; set; }
    public bool HasFooter { get; set; }
}

//Prototype
public abstract class Document
{
    public string Title { get; set; }
    public abstract Document Clone(bool deepClone = false);
}

//ConcretePrototype
public class WordDocument : Document
{
    public string Content { get; set; }
    public string FontName { get; set; }
    public int FontSize { get; set; }
    public string ThemeColor { get; set; }

    public PageSettings PageSettings { get; set; }

    public override Document Clone(bool deepClone = false)
    {
        if (!deepClone)
            return (Document)this.MemberwiseClone();

        var json = JsonSerializer.Serialize(this);
        return JsonSerializer.Deserialize<WordDocument>(json);
    }
}

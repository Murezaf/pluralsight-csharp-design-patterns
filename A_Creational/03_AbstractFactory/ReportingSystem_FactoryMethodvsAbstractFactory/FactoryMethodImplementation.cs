namespace ReportingSystem_FactoryMethodvsAbstractFactory;

public interface IHeader
{
    void RenderHeader();
}

public interface IBody
{
    void RenderBody();
}

public class PDFHeader : IHeader
{
    public void RenderHeader()
    {
        Console.WriteLine("PDFHeader rendering");
    }
}

public class PDFBody : IBody
{
    public void RenderBody()
    {
        Console.WriteLine("PDFBody rendering");
    }
}

public class ExcelHeader : IHeader
{
    public void RenderHeader()
    {
        Console.WriteLine("ExcelHeader rendering");
    }
}

public class ExcelBody : IBody
{
    public void RenderBody()
    {
        Console.WriteLine("ExcelBody rendering");
    }
}

public abstract class HeaderCreator
{
    public abstract IHeader CreateHeader();
}

public abstract class BodyCreator
{
    public abstract IBody CreateBody();
}

public class PDFHeaderCreator : HeaderCreator
{
    public override IHeader CreateHeader()
    {
        return new PDFHeader();
    }
}

public class ExcelHeaderCreator : HeaderCreator
{
    public override IHeader CreateHeader()
    {
        return new ExcelHeader();
    }
}

public class PdfBodyCreator : BodyCreator
{
    public override IBody CreateBody()
    {
        return new PDFBody();
    }
}

public class ExcelBodyCreator : BodyCreator
{
    public override IBody CreateBody()
    {
        return new ExcelBody();
    }
}

//------------------------------------------------------------
public abstract class ReportCreator
{
    public abstract IHeader CreateHeader();
    public abstract IBody CreateBody();

    public void CreateReport()
    {
        IHeader header = CreateHeader();
        IBody body = CreateBody();

        header.RenderHeader();
        body.RenderBody();
    }
}

public class PDFReportCreator : ReportCreator
{
    public override IHeader CreateHeader()
    {
        return new PDFHeader();
    }

    public override IBody CreateBody()
    {
        return new PDFBody();
    }
}

public class ExcelReportCreator : ReportCreator
{
    public override IHeader CreateHeader()
    {
        return new ExcelHeader();
    }

    public override IBody CreateBody()
    {
        return new ExcelBody();
    }
}

//------------------------------------------------------------
public interface IReportFactory
{
    IHeader CreateHeader();
    IBody CreateBody();
}

public class PdfReportFactory : IReportFactory
{
    public IHeader CreateHeader()
    {
        return new PDFHeader();
    }

    public IBody CreateBody()
    {
        return new PDFBody();
    }
}

public class ExcelReportFactory : IReportFactory
{
    public IHeader CreateHeader()
    {
        return new ExcelHeader();
    }

    public IBody CreateBody()
    {
        return new ExcelBody();
    }
}
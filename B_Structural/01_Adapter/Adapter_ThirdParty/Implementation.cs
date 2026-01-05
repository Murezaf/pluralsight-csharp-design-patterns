namespace Adapter_ThirdParty;

//Third‑Party Library (Adaptee)
public class ExternalMailSdk
{
    public void SendPlain(string mail, string text) { }
    public void SendHtml(string mail, string html) { }
}

//helper
public class EmailMessage
{
    public string To;
    public string Subject;
    public string Body;
    public bool IsHtml;
}

//Target
public interface IEmailService
{
    void Send(EmailMessage message);
}

//Adapter
public class MailAdapter : IEmailService
{
    private readonly ExternalMailSdk _sdk;

    public MailAdapter(ExternalMailSdk sdk)
    {
        _sdk = sdk;
    }

    public void Send(EmailMessage message)
    {
        Console.WriteLine("[Adapter] Mapping EmailMessage to ExternalMailMessage");

        if (message.IsHtml)
            _sdk.SendHtml(message.To, message.Body);
        else
            _sdk.SendPlain(message.To, message.Body);

        Console.WriteLine("[Adapter] Mail forwarded to ExternalMailSdk successfully");
    }
}
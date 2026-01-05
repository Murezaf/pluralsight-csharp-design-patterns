using Adapter_ThirdParty;

var externalSdk = new ExternalMailSdk();

IEmailService emailService = new MailAdapter(externalSdk);

var message = new EmailMessage
{
    To = "test@example.com",
    Subject = "Hello",
    Body = "<h1>Hello Adapter</h1>",
    IsHtml = true
};

emailService.Send(message);

//DI Container:
//var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddScoped<ExternalMailSdk>();
//builder.Services.AddScoped<IEmailService, MailAdapter>();
//var app = builder.Build();
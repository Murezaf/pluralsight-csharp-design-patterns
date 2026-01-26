using TemplateMethod;

Console.Title = "TemplateMethod";

ExchangeMailParser exchangeMailParser = new ExchangeMailParser();
Console.WriteLine(exchangeMailParser.ParseMailBody("flifkjs-164fsf-00125416faf"));
Console.WriteLine();

ApacheMailParser apacheMailParser = new ApacheMailParser();
Console.WriteLine(apacheMailParser.ParseMailBody("dsdfsdv-cc485121c-00268579rat"));
Console.WriteLine();

EudoraMailParser eudoraMailParser = new EudoraMailParser();
Console.WriteLine(eudoraMailParser.ParseMailBody("fjqorgjom-fasd168494123-fadfrq8898"));

//Even though they all call one method(ParseMailBody), what we see in result is different
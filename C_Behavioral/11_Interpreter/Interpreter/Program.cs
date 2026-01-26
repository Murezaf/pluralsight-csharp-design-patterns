using Interpreter;

Console.Title = "Interpreter";

List<RomanExpression> expressions = new List<RomanExpression>() { new RomanHundredExpression(),
    new RomanTenExpression(),
    new RomanOneExpression(),
};

RomanContext context = new RomanContext(5);
foreach (RomanExpression expression in expressions)
{
    expression.Interpret(context);
}
Console.WriteLine($"Translating to Roman numerals: 5 = {context.OutPut}.");

context = new RomanContext(81);
foreach (RomanExpression expression in expressions)
{
    expression.Interpret(context);
}
Console.WriteLine($"Translating to Roman numerals: 81 = {context.OutPut}.");

context = new RomanContext(733);
foreach (RomanExpression expression in expressions)
{
    expression.Interpret(context);
}
Console.WriteLine($"Translating to Roman numerals: 733 = {context.OutPut}.");
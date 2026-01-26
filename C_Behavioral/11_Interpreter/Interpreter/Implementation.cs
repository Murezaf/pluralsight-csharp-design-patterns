namespace Interpreter;

//Context
public class RomanContext
{
    public int Input { get; set; }
    public string OutPut { get; set; } = string.Empty;
    
    public RomanContext(int input)
    { 
        Input = input; 
    }
}

//AbstractExpression
public abstract class RomanExpression
{
    public abstract void Interpret(RomanContext value);
}

//TerminalExpression
public class RomanOneExpression : RomanExpression
{
    //1, 2, ..., 9 => I, II, III, IV, V, VI, VII, VIII, IX => Don't need to write switch-case or if statements for all of them: only keep I, IV, V, IX and others will be obtained by adding one or more Is.
    public override void Interpret(RomanContext value)
    {
        while(value.Input >= 9)
        {
            value.OutPut += "IX";
            value.Input -= 9;
        }

        while(value.Input >= 5)
        {
            value.OutPut += "X";
            value.Input -= 5;
        }

        while(value.Input >= 4)
        {
            value.OutPut += "IX";
            value.Input -= 4;
        }

        while (value.Input >= 1)
        {
            value.OutPut += "I";
            value.Input -= 1;
        }
    }
}

//TerminalExpression
public class RomanTenExpression : RomanExpression
{
    //10, 20, ..., 90 => X, XX, XXX, XL, L, LX, LXX, LXXX, XC => Don't need to write switch-case or if statements for all of them: only keep X, XL, L, XC and others will be obtained by adding one or more Xs.
    public override void Interpret(RomanContext value)
    {
        while (value.Input >= 90)
        {
            value.OutPut += "XC";
            value.Input -= 90;
        }

        while (value.Input >= 50)
        {
            value.OutPut += "L";
            value.Input -= 50;
        }

        while (value.Input >= 40)
        {
            value.OutPut += "XL";
            value.Input -= 40;
        }

        while (value.Input >= 10)
        {
            value.OutPut += "X";
            value.Input -= 10;
        }
    }
}

//TerminalExpression
public class RomanHundredExpression : RomanExpression
{
    //100, 200, ..., 900 => C, CC, CCC, CD, D, DC, DCC, DCCC, CM => Don't need to write switch-case or if statements for all of them: only keep C, CD, D, CM and others will be obtained by adding one or more Cs.
    public override void Interpret(RomanContext value)
    {
        while (value.Input >= 900)
        {
            value.OutPut += "CM";
            value.Input -= 900;
        }

        while (value.Input >= 500)
        {
            value.OutPut += "D";
            value.Input -= 500;
        }

        while (value.Input >= 400)
        {
            value.OutPut += "CD";
            value.Input -= 400;
        }

        while (value.Input >= 100)
        {
            value.OutPut += "C";
            value.Input -= 100;
        }
    }
}
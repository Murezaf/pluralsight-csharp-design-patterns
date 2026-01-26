namespace State;

//State
public abstract class BankAccountState
{
    public BankAccount BankAccount { get; protected set; } = null!;
    public decimal Balance { get; protected set; }
    public abstract void Deposit(decimal amount);
    public abstract void Withdraw(decimal amount);
}

//ConcreteState
public class RegularState : BankAccountState
{
    public RegularState(BankAccount bankAccount, decimal balance)
    {
        BankAccount = bankAccount;
        Balance = balance;
    }
    public override void Deposit(decimal amount)
    {
        Console.WriteLine($"In {GetType()}, depositing {amount}.");
        Balance += amount;

        if (Balance > 1000)
        {
            BankAccount.BankAccountState = new GoldState(BankAccount, Balance);
        }
    }

    public override void Withdraw(decimal amount)
    {
        Console.WriteLine($"In {GetType()}, withdrawing {amount} from {Balance}.");
        Balance -= amount;

        if (Balance < 0)
        {
            BankAccount.BankAccountState = new OverdrawnState(BankAccount, Balance); //Isn't it a problem to new up a new object each time?
        }
    }
}

//ConcreteState
public class OverdrawnState : BankAccountState
{
    public OverdrawnState(BankAccount bankAccount, decimal balance)
    {
        BankAccount = bankAccount;
        Balance = balance;
    }
    public override void Deposit(decimal amount)
    {
        Console.WriteLine($"In {GetType()}, depositing {amount}.");
        Balance += amount;

        if (Balance >= 0)
        {
            BankAccount.BankAccountState = new RegularState(BankAccount, Balance);//Isn't it a problem to new up a new object each time?
        }
        //In our bank rules, you can't go to Gold state from Overdrawn state in one action. you should be in Regular state waiting for one more deposit. So no change needed here after adding GoldState 
    }

    public override void Withdraw(decimal amount)
    {
        Console.WriteLine($"In {GetType()}, can not withdraw: balance {Balance}.");
    }
}

//ConcreteState
public class GoldState : BankAccountState
{
    public GoldState(BankAccount bankAccount, decimal balance)
    {
        BankAccount = bankAccount;
        Balance = balance;
    }

    public override void Deposit(decimal amount)
    {
        Console.WriteLine($"In {GetType()}, depositing {amount} with 10% bonus: {amount/10}");
        Balance += amount + amount / 10;
        //When you're in Gold state and depositing money, there is no state transition that can happen, so no further logic is required.
    }

    public override void Withdraw(decimal amount)
    {
        Console.WriteLine($"In {GetType()}, withdrawing {amount} from {Balance}.");
        Balance -= amount;
    
        if(Balance <= 1000 && Balance >= 0)
        {
            BankAccount.BankAccountState = new RegularState(BankAccount, Balance);
        }
        else if(Balance < 0)
        {
            BankAccount.BankAccountState = new OverdrawnState(BankAccount, Balance);
        }
    }
}

//Context
public class BankAccount
{
    public BankAccountState BankAccountState { get; set; }
    
    public BankAccount()
    {
        BankAccountState = new RegularState(this, 200);
    }

    //Client can know about his account balance and also can request for Deposit & Withdraw
    public decimal Balance
    {
        get
        {
            return BankAccountState.Balance;
        }
    }

    public void Deposit(decimal balance)
    {
        BankAccountState.Deposit(balance);
    }
    public void Withdraw(decimal balance)
    {
        BankAccountState.Withdraw(balance);
    }
}
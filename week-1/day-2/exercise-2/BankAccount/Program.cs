using System;

abstract class BankAccount
{
    public int AccountNumber { get; set; }
    public decimal Balance { get; set; }

    public virtual void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public virtual void Withdraw(decimal amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
        }
        else
        {
            Console.WriteLine("Insufficient funds");
        }
    }
}

class SavingsAccount : BankAccount
{
    public decimal InterestRate { get; set; }

    public override void Deposit(decimal amount)
    {
        // add interest before depositing
        Balance += Balance * InterestRate / 100;
        base.Deposit(amount);
    }

    public override void Withdraw(decimal amount)
    {
        // check if withdrawal amount is within balance and minimum balance limit
        if (Balance >= amount && Balance - amount >= 1000)
        {
            base.Withdraw(amount);
        }
        else
        {
            Console.WriteLine("Insufficient funds or minimum balance limit reached");
        }
    }
}

class CheckingAccount : BankAccount
{
    public decimal OverdraftLimit { get; set; }

    public override void Withdraw(decimal amount)
    {
        // check if withdrawal amount is within balance and overdraft limit
        if (Balance + OverdraftLimit >= amount)
        {
            base.Withdraw(amount);
        }
        else
        {
            Console.WriteLine("Insufficient funds or overdraft limit reached");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        SavingsAccount savingsAccount = new SavingsAccount()
        {
            AccountNumber = 123456,
            Balance = 1000,
            InterestRate = 5
        };

        CheckingAccount checkingAccount = new CheckingAccount()
        {
            AccountNumber = 654321,
            Balance = 5000,
            OverdraftLimit = 1000
        };

        Console.WriteLine($"Savings account balance before deposit: {savingsAccount.Balance}");
        savingsAccount.Deposit(500);
        Console.WriteLine($"Savings account balance after deposit: {savingsAccount.Balance}");
        savingsAccount.Withdraw(1500);
        Console.WriteLine($"Savings account balance after withdrawal: {savingsAccount.Balance}");

        Console.WriteLine($"Checking account balance before withdrawal: {checkingAccount.Balance}");
        checkingAccount.Withdraw(6000);
        Console.WriteLine($"Checking account balance after withdrawal: {checkingAccount.Balance}");
        checkingAccount.Withdraw(2000);
        Console.WriteLine($"Checking account balance after withdrawal: {checkingAccount.Balance}");
    }
}
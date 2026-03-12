using System;

public class BankAccount
{

    private string AccHolderName { get; set; }
    private decimal CurrentBalance { get; set; } = 5000;

    public BankAccount(string accHolderName, decimal currentBalance)

    {
        AccHolderName = accHolderName;
        CurrentBalance = currentBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new InvalidAmountException("Deposit amount should be greater than 0 you are giving an input < 0");
        }
        CurrentBalance += amount;
        Console.WriteLine($"{amount} deposited in your account");
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new InvalidAmountException("Deposit amount should be greater than 0 you are giving an input < 0");
        }
        if (amount > CurrentBalance)
        {
            throw new InsufficientBalanceException($"Insufficient balance, cannot withdraw {amount}");
        }
        CurrentBalance -= amount;
        Console.WriteLine($"{amount} withdrawn from your account");
    }

    public void TransferToOtherAcc(decimal amount, BankAccount otherBankAcc)
    {
        if (amount <= 0) { throw new InvalidAmountException("Deposit amount should be greater than 0 you are giving an input < 0"); }
        else if (amount > CurrentBalance)
        {
            throw new InsufficientBalanceException($"Insufficient balance, cannot withdraw {amount}");
        }
        else if (otherBankAcc == null)
        {
            throw new AccountNotFoundException("Account not found");
        }
        else
        {
            this.CurrentBalance -= amount;
            otherBankAcc.CurrentBalance += amount;
            Console.WriteLine($"{amount} transfered from {this.AccHolderName}'s account to {otherBankAcc.AccHolderName} account");
        }
    }

}

public class InvalidAmountException : Exception
{
    public InvalidAmountException() { }

    public InvalidAmountException(string message) : base(message) { }

    public InvalidAmountException(string message, Exception innerException) : base(message, innerException)
    {

    }
}

public class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException() { }
    public InsufficientBalanceException(string message) : base(message) { }

    public InsufficientBalanceException(string message, Exception innerException) : base(message, innerException)
    {
    }
}

public class AccountNotFoundException : Exception
{

    public AccountNotFoundException() { }

    public AccountNotFoundException(string message) : base(message) { }

    public AccountNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }

}
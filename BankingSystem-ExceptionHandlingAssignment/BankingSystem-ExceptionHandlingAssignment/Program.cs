public class Program
{

    public static void Main()
    {

        //=============================
        //BANKING SYSTEM
        //=============================

        BankAccount bankAccount1 = new BankAccount("Ashutosh", 3000);
        BankAccount bankAccount2 = new BankAccount("Sam", 1000);
        BankAccount bankAccount3 = null;


        try
        {
            bankAccount1.Withdraw(500);
            bankAccount1.Deposit(2000);
            bankAccount1.TransferToOtherAcc(500, bankAccount2);
            bankAccount1.TransferToOtherAcc(500, bankAccount3);
        }
        catch (InvalidAmountException invex)
        {
            throw new InvalidAmountException("Invalid amount", invex);
            Console.WriteLine("caught");
        }
        catch (InsufficientBalanceException inbex)
        {
            Console.WriteLine(inbex.Message);
        }
        catch (AccountNotFoundException anfex)
        {
            Console.WriteLine(anfex.Message);
        }

    }

}
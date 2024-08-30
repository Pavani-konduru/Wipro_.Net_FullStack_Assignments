using System;
using System.Threading;

public class Program
{
    private static void PerformTransaction(AccountManager manager, Account fromAccount, Account toAccount, double amount)
    {
        Console.WriteLine($"Thread starting transfer of {amount} from {fromAccount.AccountId} to {toAccount.AccountId}.");
        manager.Transfer(fromAccount, toAccount, amount);
    }

    public static void Main()
    {
        Account acc1 = new Account("1", 1500.0);
        Account acc2 = new Account("2", 1000.0);

        acc1.PrintInitialBalance();
        acc2.PrintInitialBalance();

        AccountManager manager = new AccountManager();

        Thread thread1 = new Thread(() => PerformTransaction(manager, acc1, acc2, 100.0));
 

        thread1.Start();


        thread1.Join();
      

        Console.WriteLine($"Final balance of account {acc1.AccountId}: {acc1.GetBalance()}");
        Console.WriteLine($"Final balance of account {acc2.AccountId}: {acc2.GetBalance()}");
    }
}

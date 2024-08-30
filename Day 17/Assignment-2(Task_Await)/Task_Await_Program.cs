using System;
using System.Threading.Tasks;

public class Program
{
    private static async Task DepositTask(Account account, double amount)
    {
        Console.WriteLine($"Starting deposit of {amount} into account {account.AccountId}.");
        await account.DepositAsync(amount);
        Console.WriteLine($"Completed deposit of {amount} into account {account.AccountId}.");
    }

    private static async Task WithdrawTask(Account account, double amount)
    {
        Console.WriteLine($"Starting withdrawal of {amount} from account {account.AccountId}.");
        bool success = await account.WithdrawAsync(amount);
        if (success)
        {
            Console.WriteLine($"Completed withdrawal of {amount} from account {account.AccountId}.");
        }
        else
        {
            Console.WriteLine($"Failed to withdraw {amount} from account {account.AccountId}.");
        }
    }

    public static async Task Main()
    {
        Account account = new Account("1", 1000.0);

        account.PrintInitialBalance();

        Task depositTask = DepositTask(account, 500.0);  
        Task withdrawTask = WithdrawTask(account, 200.0);

        await Task.WhenAll(depositTask, withdrawTask);

        Console.WriteLine($"Final balance of account {account.AccountId}: {account.GetBalance()}");

        Console.WriteLine();
        Console.WriteLine("This is done by using Tasks in C# ");
    }
}

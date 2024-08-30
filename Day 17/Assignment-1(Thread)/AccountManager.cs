using System;

public class AccountManager
{
    public void Transfer(Account fromAccount, Account toAccount, double amount)
    {
        if (fromAccount == toAccount)
        {
            Console.WriteLine("Cannot transfer to the same account.");
            return;
        }

        if (amount <= 0)
        {
            Console.WriteLine("Transfer amount must be positive.");
            return;
        }

        if (fromAccount.Withdraw(amount))
        {
            toAccount.Deposit(amount);
            Console.WriteLine($"Transferred {amount} from account {fromAccount.AccountId} to account {toAccount.AccountId}.");
        }
    }
}

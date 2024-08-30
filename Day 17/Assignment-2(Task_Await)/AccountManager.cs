using System.Threading.Tasks;

public class AccountManager
{
    public async Task TransferAsync(Account fromAccount, Account toAccount, double amount)
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

        if (await fromAccount.WithdrawAsync(amount))
        {
            await toAccount.DepositAsync(amount);
            Console.WriteLine($"Transferred {amount} from account {fromAccount.AccountId} to account {toAccount.AccountId}.");
        }
    }
}

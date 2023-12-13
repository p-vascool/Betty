namespace Betty.Services.Contracts
{
    public interface IBalanceSerivce
    {
        decimal Balance { get; }

        decimal Deposit(decimal amount);
        decimal Withdraw(decimal amount);
        bool CanWithdrawAmount(decimal amount);
    }
}

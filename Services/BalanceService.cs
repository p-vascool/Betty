using Betty.Services.Contracts;

namespace Betty.Services
{
    public class BalanceService : IBalanceSerivce
    {
        public decimal Balance { get; private set; } = default(decimal);

        public bool CanWithdrawAmount(decimal amount)
            => this.Balance >= amount && this.Balance > 0;

        public decimal Deposit(decimal amount)
        {
            this.Balance += amount;
            return this.Balance;
        }

        public decimal Withdraw(decimal amount)
        {
            this.Balance -= amount;
            return this.Balance;
        }
    }
}

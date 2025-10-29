namespace BankManagementSystem.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public string AccountHolderName { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public string AccountType { get; set; } = string.Empty;
    }
}

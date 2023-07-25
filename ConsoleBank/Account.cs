namespace ConsoleBank
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateCreated { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public string NIN { get; set; }
        public bool IsSavings { get; set; }
        public bool IsCurrent { get; set; }
        public double AccountBalance;
    }
}

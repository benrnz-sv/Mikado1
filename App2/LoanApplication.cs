namespace App2
{
    public class LoanApplication
    {
        public decimal Amount { get; private set; }

        public string Contact { get; private set; }


        public void SetAmount(decimal amount)
        {
            Amount = amount;
        }

        public void SetContact(string contact)
        {
            Contact = contact;
        }
    }
}
namespace App2
{
    public class LoanRepository
    {
        public const string FILE_EXTENSION = ".loan";
        public const string REPOSITORY_ROOT = @"X:\LoanData\";

        public Ticket Store(LoanApplication application)
        {
            // Hard coded to store to a file via IO... code omitted
            return new Ticket();
        }

        public Ticket Approve(string ticketId)
        {
            // Code omitted
            return new Ticket();
        }

        public LoanApplication Fetch(string ticketId)
        {
            // Hard coded to fetch from a file.
            return new LoanApplication();
        }
    }
}
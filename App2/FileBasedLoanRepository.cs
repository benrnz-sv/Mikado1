namespace App2
{
    public class FileBasedLoanRepository : ILoanRepository
    {
        public const string FILE_EXTENSION = ".foo";
        public const string REPOSITORY_ROOT = @"X:\";

        public Ticket Store(LoanApplication application)
        {
            // TODO
            return new Ticket();
        }

        public Ticket Approve(string ticketId)
        {
            return new Ticket();
        }

        public LoanApplication Fetch(string ticketId)
        {
            // TODO
            return new LoanApplication();
        }
    }
}
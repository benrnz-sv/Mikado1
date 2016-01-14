namespace App2
{
    public interface ILoanRepository
    {
        Ticket Store(LoanApplication application);
        Ticket Approve(string ticketId);
        LoanApplication Fetch(string ticketId);
    }
}
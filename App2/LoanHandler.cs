using System;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using App2.Fakes;

namespace App2
{
    public class LoanHandler : IHandler
    {
        private readonly FileBasedLoanRepository _loanRepository = new FileBasedLoanRepository();
        private const string APPLICATION = "Apply";
        private const string FETCH = "Fetch";
        private const string TICKET_ID = "Ticket";
        private const string APPLICATION_ID = "ApplicationId";
        private const string APPROVE = "Approve";

        public void Handle(string target, HttpRequest baseRequest, HttpResponse response)
        {
            response.SetContentType("application/json;charset=utf-8");
            response.SetStatus(HttpStatusCode.OK);
            baseRequest.SetHandled(true);

            try
            {
                if (IsApplication(baseRequest))
                {
                    LoanApplication application = new LoanApplication();
                    application.SetAmount(AmountFrom(baseRequest));
                    application.SetContact(ContactFrom(baseRequest));
                    Ticket ticket = _loanRepository.Store(application);
                    response.Write(JsonSerialiser.ToJson(ticket));
                }
                else if (IsStatusRequest(baseRequest) && IdSpecified(baseRequest))
                {
                    response.Write(FetchLoanInfo(baseRequest.GetParameter(TICKET_ID)));
                }
                else if (IsApproval(baseRequest) && IdSpecified(baseRequest))
                {
                    response.Write(ApproveLoan(baseRequest.GetParameter(TICKET_ID)));
                }
                else
                {
                    response.Write("Incorrect parameters provided");
                }
            }
            catch (ApplicationException ex)
            {
                response.Write("Uh oh! Problem occured: " + ex);
            }
        }

        private string ApproveLoan(string ticketId)
        {
            return JsonSerialiser.ToJson(_loanRepository.Approve(ticketId));
        }

        private bool IsApproval(HttpRequest request)
        {
            return APPROVE == request.GetParameter("action");
        }

        private string FetchLoanInfo(string ticketId)
        {
            LoanApplication formerApplication = _loanRepository.Fetch(ticketId);
            return JsonSerialiser.ToJson(formerApplication);
        }

        private bool IdSpecified(HttpRequest request)
        {
            return request.GetParameter(TICKET_ID) != null && ValidId(request) >= 0;
        }

        private long ValidId(HttpRequest request)
        {
            string ticketId = request.GetParameter(TICKET_ID);
            try
            {
                return long.Parse(ticketId);
            }
            catch (FormatException)
            {
                return -1;
            }
        }

        private bool IsStatusRequest(HttpRequest request)
        {
            return FETCH == request.GetParameter("action");
        }

        private string ContactFrom(HttpRequest request)
        {
            return request.GetParameter("contact");
        }

        private decimal AmountFrom(HttpRequest request)
        {
            return decimal.Parse(request.GetParameter("amount"));
        }

        private bool IsApplication(HttpRequest request)
        {
            return APPLICATION == request.GetParameter("action");
        }

        public long GetNextId()
        {
            File file = new File(FileBasedLoanRepository.REPOSITORY_ROOT);
            var files = file.ListFiles(f => f.EndsWith(FileBasedLoanRepository.FILE_EXTENSION));
            return files?.Count() + 1 ?? 0;
        }
    }
}
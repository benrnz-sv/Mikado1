using System.Net;

namespace App2.Fakes
{
    public interface IHandler
    {
        void Handle(string target, HttpRequest baseRequest, HttpResponse response);
    }
}
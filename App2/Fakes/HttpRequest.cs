namespace App2.Fakes
{
    public class HttpRequest
    {
        public void SetHandled(bool handled)
        {
            // fake
        }

        public string GetParameter(string parameterId)
        {
            // Fake
            return "foo";
        }
    }
}
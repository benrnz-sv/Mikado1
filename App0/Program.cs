using System;

namespace App0
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                MyApp app = new MyApp(new XamlDatabaseRepository(args[0]));
                app.Launch();
                Console.ReadLine();
            }
            catch (ApplicationException ex)
            {
                var currentColour = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = currentColour;
            }
        }
    }
}
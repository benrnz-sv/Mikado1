using System;

namespace App0
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                MyApp.SetStorageFile(args[0]);
                MyApp app = new MyApp();
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
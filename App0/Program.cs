using System;

namespace App0
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                MyApp.SetStorageFile(@"D:\GitRepos2\Mikado\App0\bin\Debug\AppDb.xaml");
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
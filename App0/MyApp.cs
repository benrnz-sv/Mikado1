using System;
using System.IO;
using Portable.Xaml;

namespace App0
{
    public class MyApp
    {
        private static ApplicationDatabase MyData;

        public static void SetStorageFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                var defaultDatabase = new ApplicationDatabase
                {
                    MyInt = 11,
                    MyTextData = "The quick brown fox jumped over the lazy dog.",
                    NetWorth = 25.21M,
                };
                using (var stream = new FileStream(fileName, FileMode.CreateNew))
                {
                    XamlServices.Save(stream, defaultDatabase);
                }
            }

            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                MyData = (ApplicationDatabase) XamlServices.Load(stream);
            }
        }

        public void Launch()
        {
            for (var i = 0; i < MyData.MyInt; i++)
            {
                Console.WriteLine($"{i} Hey there high roller, you're net worth is {MyData.NetWorth:C}.");
            }
        }
    }
}
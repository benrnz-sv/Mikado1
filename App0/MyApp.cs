using System;
using System.IO;
using Portable.Xaml;

namespace App0
{
    public class MyApp
    {
        private readonly IDatabaseRepository _dbRepo;

        public MyApp(IDatabaseRepository dbRepo)
        {
            _dbRepo = dbRepo;
        }

        public void Launch()
        {
            _dbRepo.Load();
            for (var i = 0; i < _dbRepo.MyData.MyInt; i++)
            {
                Console.WriteLine($"{i} Hey there high roller, you're net worth is {_dbRepo.MyData.NetWorth:C}.");
            }
        }
    }
}
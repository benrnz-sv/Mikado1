using System.IO;
using Portable.Xaml;

namespace App0
{
    public class XamlDatabaseRepository : IDatabaseRepository
    {
        private string _fileName;

        public XamlDatabaseRepository(string fileName)
        {
            _fileName = fileName;
        }

        public ApplicationDatabase MyData { get; private set; }

        public void Load()
        {
            if (!File.Exists(_fileName))
            {
                var defaultDatabase = new ApplicationDatabase
                {
                    MyInt = 11,
                    MyTextData = "The quick brown fox jumped over the lazy dog.",
                    NetWorth = 25.21M,
                };
                using (var stream = new FileStream(_fileName, FileMode.CreateNew))
                {
                    XamlServices.Save(stream, defaultDatabase);
                }
            }

            using (var stream = new FileStream(_fileName, FileMode.Open))
            {
                MyData = (ApplicationDatabase)XamlServices.Load(stream);
            }
        }
    }
}
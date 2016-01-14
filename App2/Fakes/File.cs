using System;
using System.Collections.Generic;

namespace App2.Fakes
{
    public class File
    {
        public File(string location)
        {
            // Fake
        }

        public IEnumerable<File> ListFiles(Func<string, bool> filter)
        {
            return new List<File>();
        }
    }
}
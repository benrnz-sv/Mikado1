using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.Storage;
using App1.Annotations;
using Portable.Xaml;

namespace App1
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private StorageFile _dataFile;
        private App1Data _database;
        private string _textProperty;
        private int _myInt;
        private decimal _netWorth;

        public MainViewModel()
        {
        }

        public async Task<MainViewModel> Init()
        {
            await Task.Run(async () =>
            {
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                try
                {
                    _dataFile = await storageFolder.GetFileAsync("App1Database.xaml");
                    _database = (App1Data) XamlServices.Load(_dataFile.Path);
                }
                catch (FileNotFoundException)
                {
                    // Create sample file;
                    var data = new App1Data
                    {
                        IntData = 83,
                        NetWorth = 100000000001.99M,
                        SomeStringData = "One Hundred Billion Dollars... and some change."
                    };
                    StorageFile sampleFile =
                        await
                            storageFolder.CreateFileAsync("App1Database.xaml", CreationCollisionOption.ReplaceExisting);
                    using (var stream = new FileStream(sampleFile.Path, FileMode.Truncate))
                    {
                        XamlServices.Save(stream, data);
                    }
                }
            });
            MyInt = _database.IntData;
            NetWorth = _database.NetWorth;
            TextProperty = _database.SomeStringData;
            return this;
        }

        public string TextProperty
        {
            get { return _textProperty; }
            set
            {
                if (value == _textProperty) return;
                _textProperty = value;
                OnPropertyChanged();
            }
        }

        public int MyInt
        {
            get { return _myInt; }
            set
            {
                if (value == _myInt) return;
                _myInt = value;
                OnPropertyChanged();
            }
        }

        public decimal NetWorth
        {
            get { return _netWorth; }
            set
            {
                if (value == _netWorth) return;
                _netWorth = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

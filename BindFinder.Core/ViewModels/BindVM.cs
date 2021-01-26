using OutOfHome.Models;
using OutOfHome.Models.Binds;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BindFinder.ViewModels
{
    class BindVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Bind OriginalBind { get; }
        public Exception Exception { get; set; }

        public string OriginalAddress { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public Location Location { get; set; }

        public BindVM() { }
        public BindVM(Bind bind)
        {
            this.OriginalBind = bind;
            this.OriginalAddress = bind.OriginalAddress;
            this.Description = bind.Description;
            this.Address = bind.Address.ToString();
            this.Location = bind.Address.Location;
        }


        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}


using OutOfHome.Models.Binds;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace BindFinder.ViewModels
{
    sealed class MainWindowVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private BindVM _selectedBind;
        public ObservableCollection<BindVM> Binds { get; }
        public BindVM SelectedBind
        {
            get { return _selectedBind; }
            set {
                _selectedBind = value;
                OnPropertyChanged("SelectedBind");
            }
        }
        public MainWindowVM()
        {
            this.Binds = new ObservableCollection<BindVM>();
        }

        public RelayCommand ImportWithInputBox => _importWithInputBox ??= new RelayCommand(async obj => {
            var addresses = Helpers.DialogsProvider.GetBindsStrings();

            if(addresses == null || addresses.Length == 0)
                return;

            OutOfHome.Binds.BindBuilder b = new OutOfHome.Binds.BindBuilder();

            foreach(var adr in addresses)
            {
                try
                {
                    var bind = await b.BuildBindAsync(adr);
                    BindVM view = new BindVM(bind);
                    this.Binds.Add(view);
                }
                catch(System.Exception ex)
                {
                    BindVM view = new BindVM { OriginalAddress = adr, Address = ex.Message };
                    this.Binds.Add(view);
                }                
            }
        });
        private RelayCommand _importWithInputBox;
        public RelayCommand OpenFile => _openFile ??= new RelayCommand(async obj => {

            string file = Helpers.DialogsProvider.ShowOpenFileDialog();
            if(string.IsNullOrEmpty(file) || !System.IO.File.Exists(file)) return;

            IEnumerable<Bind> binds = await Helpers.ImportExport.OpenBindsFromFile(file);

            foreach(var model in binds.Select(a => new BindVM(a)))
            {
                this.Binds.Add(model);
            }
        });
        private RelayCommand _openFile;
        public RelayCommand SaveToFile => _saveToFile ??= new RelayCommand(async obj => 
        {
            var binds = this.Binds.Where(a => !OutOfHome.Models.Location.IsNullOrEmpty(a.Location));
            if(!binds.Any()) return;

            string file = Helpers.DialogsProvider.ShowSaveAsFileDialog();

            if(!string.IsNullOrEmpty(file))
                await Helpers.ImportExport.SaveBindsToFile(binds.Select(a => a.OriginalBind), file);

            MessageBox.Show("Saved");

        });
        private RelayCommand _saveToFile;
        public RelayCommand ClearBindsList => _clearBindsList ??= new RelayCommand(obj =>
        {
            if(MessageBox.Show("Вы хотите удалить все точки в этом списке?", "Очистить список точек", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                this.Binds.Clear();

        });
        private RelayCommand _clearBindsList;
        
        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        
       
    }
}

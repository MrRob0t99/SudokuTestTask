using ConsoleApp3;
using System.ComponentModel;

namespace TestTask.ViewModel
{
    class ApplicationViewModel: INotifyPropertyChanged
    {
        private readonly Sudoku _sudoku;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

using System;
using ConsoleApp3;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TestTask.My
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        #region Private Fields

        private readonly Sudoku _sudoku;
        private string NameProperty { get; set; }
        private InputPanel InputPanel { get; set; }
        private readonly bool _canExecute;
        private int[][] arr;
        private ICommand _startCommand;
        private ICommand _inputCommand;
        private ICommand _changeValueCommand;
        private ICommand _cleanCommand;
        private ICommand _stopCommand;
        private bool _canChangeValue = true;
        private CancellationTokenSource source = new CancellationTokenSource();

        #endregion

        #region Ctor

        public ApplicationViewModel()
        {
            _sudoku = new Sudoku();
            _canExecute = true;
        }

        #endregion

        #region CommandProperty

        public ICommand StartCommand
        {
            get
            {
                return _startCommand ?? (_startCommand = new CommandHandler((x) => Start(), _canExecute));
            }
        }
        public ICommand ShowCommand
        {
            get
            {
                return _inputCommand ?? (_inputCommand = new CommandHandler((obj) => ShowInputPanel(obj), _canExecute));
            }
        }
        public ICommand CleanCommand
        {
            get
            {
                return _cleanCommand ?? (_cleanCommand = new CommandHandler((obj) => Clean(), _canExecute));
            }
        }
        public ICommand ChangeValue
        {
            get
            {
                return _changeValueCommand ?? (_changeValueCommand = new CommandHandler((x) => Change(x), _canExecute));
            }
        }
        public ICommand StopCommand
        {
            get
            {
                return _stopCommand ?? (_stopCommand = new CommandHandler((x) => Stop(), _canExecute));
            }
        }

        #endregion

        #region Private Method

        private void Clean()
        {
            if (_canChangeValue)
            {
                _sudoku.Clean();
                OnPropertyChanged();
            }
        }

        private void Change(object value)
        {
            if (value != null)
            {
                this.GetType().GetProperty(NameProperty).SetValue(this, Convert.ToInt32(value));
                InputPanel.Close();
            }
        }

        private void ShowInputPanel(object x)
        {
            if (_canChangeValue)
            {
                NameProperty = x as string;
                InputPanel = new InputPanel(this);
                InputPanel.ShowDialog();
            }
        }

        private async Task Start()
        {
            _canChangeValue = false;
            var res = await Task.Factory.StartNew(() => _sudoku.Start(this, CheckBoxIsChecked,source.Token));
            if (res==0)
            {
                MessageBox.Show("There is no solution");
            }
            if (res == 1)
            {
                MessageBox.Show("Cancel");
            }
            _canChangeValue = true;
            source = new CancellationTokenSource();
        }

        private void Stop()
        {
            if (!_canChangeValue)
            {
                source.Cancel();
                _sudoku.Clean();
            }
        }

        #endregion

        #region Implementation INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        #endregion

        #region PropertyBinding
        public bool CheckBoxIsChecked { get; set; } = true;

        public int Cell11
        {
            get
            {
                return _sudoku[0, 0];
            }
            set
            {
                if (value != _sudoku[0, 0])
                {
                    _sudoku[0, 0] = value;
                    OnPropertyChanged("Cell11");
                }
            }
        }

        public int Cell12
        {
            get
            {
                var res = _sudoku[0, 1];
                return res;
            }
            set
            {
                if (value != _sudoku[0, 1])
                {
                    _sudoku[0, 1] = value;
                    OnPropertyChanged("Cell12");
                }
            }
        }

        public int Cell13
        {
            get
            {
                return _sudoku[0, 2];
            }
            set
            {
                if (value != _sudoku[0, 2])
                {
                    _sudoku[0, 2] = value;
                    OnPropertyChanged("Cell13");
                }
            }
        }

        public int Cell21
        {
            get
            {
                return _sudoku[0, 3];
            }
            set
            {
                if (value != _sudoku[0, 3])
                {
                    _sudoku[0, 3] = value;
                    OnPropertyChanged("Cell21");
                }
            }
        }

        public int Cell22
        {
            get
            {
                return _sudoku[0, 4];
            }
            set
            {
                if (value != _sudoku[0, 4])
                {
                    _sudoku[0, 4] = value;
                    OnPropertyChanged("Cell22");
                }
            }
        }

        public int Cell23
        {
            get
            {
                return _sudoku[0, 5];
            }
            set
            {
                if (value != _sudoku[0, 5])
                {
                    _sudoku[0, 5] = value;
                    OnPropertyChanged("Cell23");
                }
            }
        }

        public int Cell31
        {
            get
            {
                return _sudoku[0, 6];
            }
            set
            {
                if (value != _sudoku[0, 6])
                {
                    _sudoku[0, 6] = value;
                    OnPropertyChanged("Cell31");
                }
            }
        }

        public int Cell32
        {
            get
            {
                return _sudoku[0, 7];
            }
            set
            {
                if (value != _sudoku[0, 7])
                {
                    _sudoku[0, 7] = value;
                    OnPropertyChanged("Cell32");
                }
            }
        }

        public int Cell33
        {
            get
            {
                return _sudoku[0, 8];
            }
            set
            {
                if (value != _sudoku[0, 8])
                {
                    _sudoku[0, 8] = value;
                    OnPropertyChanged("Cell33");
                }
            }
        }


        public int Cell14
        {
            get
            {
                return _sudoku[1, 0];
            }
            set
            {
                if (value != _sudoku[1, 0])
                {
                    _sudoku[1, 0] = value;
                    OnPropertyChanged("Cell14");
                }
            }
        }

        public int Cell15
        {
            get
            {
                return _sudoku[1, 1];
            }
            set
            {
                if (value != _sudoku[1, 1])
                {
                    _sudoku[1, 1] = value;
                    OnPropertyChanged("Cell15");
                }
            }
        }

        public int Cell16
        {
            get
            {
                return _sudoku[1, 2];
            }
            set
            {
                if (value != _sudoku[1, 2])
                {
                    _sudoku[1, 2] = value;
                    OnPropertyChanged("Cell16");
                }
            }
        }

        public int Cell24
        {
            get
            {
                return _sudoku[1, 3];
            }
            set
            {
                if (value != _sudoku[1, 3])
                {
                    _sudoku[1, 3] = value;
                    OnPropertyChanged("Cell24");
                }
            }
        }

        public int Cell25
        {
            get
            {
                return _sudoku[1, 4];
            }
            set
            {
                if (value != _sudoku[1, 4])
                {
                    _sudoku[1, 4] = value;
                    OnPropertyChanged("Cell25");
                }
            }
        }

        public int Cell26
        {
            get
            {
                return _sudoku[1, 5];
            }
            set
            {
                if (value != _sudoku[1, 5])
                {
                    _sudoku[1, 5] = value;
                    OnPropertyChanged("Cell26");
                }
            }
        }

        public int Cell34
        {
            get
            {
                return _sudoku[1, 6];
            }
            set
            {
                if (value != _sudoku[1, 6])
                {
                    _sudoku[1, 6] = value;
                    OnPropertyChanged("Cell34");
                }
            }
        }

        public int Cell35
        {
            get
            {
                return _sudoku[1, 7];
            }
            set
            {
                if (value != _sudoku[1, 7])
                {
                    _sudoku[1, 7] = value;
                    OnPropertyChanged("Cell35");
                }
            }
        }

        public int Cell36
        {
            get
            {
                return _sudoku[1, 8];
            }
            set
            {
                if (value != _sudoku[1, 8])
                {
                    _sudoku[1, 8] = value;
                    OnPropertyChanged("Cell36");
                }
            }
        }



        public int Cell17
        {
            get
            {
                return _sudoku[2, 0];
            }
            set
            {
                if (value != _sudoku[2, 0])
                {
                    _sudoku[2, 0] = value;
                    OnPropertyChanged("Cell17");
                }
            }
        }

        public int Cell18
        {
            get
            {
                return _sudoku[2, 1];
            }
            set
            {
                if (value != _sudoku[2, 1])
                {
                    _sudoku[2, 1] = value;
                    OnPropertyChanged("Cell18");
                }
            }

        }

        public int Cell19
        {
            get
            {
                return _sudoku[2, 2];
            }
            set
            {
                if (value != _sudoku[2, 2])
                {
                    _sudoku[2, 2] = value;
                    OnPropertyChanged("Cell19");
                }
            }

        }

        public int Cell27
        {
            get
            {
                return _sudoku[2, 3];
            }
            set
            {
                if (value != _sudoku[2, 3])
                {
                    _sudoku[2, 3] = value;
                    OnPropertyChanged("Cell27");
                }
            }

        }

        public int Cell28
        {
            get
            {
                return _sudoku[2, 4];
            }
            set
            {
                if (value != _sudoku[2, 4])
                {
                    _sudoku[2, 4] = value;
                    OnPropertyChanged("Cell28");
                }
            }

        }

        public int Cell29
        {
            get
            {
                return _sudoku[2, 5];
            }
            set
            {
                if (value != _sudoku[2, 5])
                {
                    _sudoku[2, 5] = value;
                    OnPropertyChanged("Cell29");
                }
            }

        }

        public int Cell37
        {
            get
            {
                return _sudoku[2, 6];
            }
            set
            {
                if (value != _sudoku[2, 6])
                {
                    _sudoku[2, 6] = value;
                    OnPropertyChanged("Cell37");
                }
            }

        }

        public int Cell38
        {
            get
            {
                return _sudoku[2, 7];
            }
            set
            {
                if (value != _sudoku[2, 7])
                {
                    _sudoku[2, 7] = value;
                    OnPropertyChanged("Cell38");
                }
            }

        }

        public int Cell39
        {
            get
            {
                return _sudoku[2, 8];
            }
            set
            {
                if (value != _sudoku[2, 8])
                {
                    _sudoku[2, 8] = value;
                    OnPropertyChanged("Cell39");
                }

            }

        }



        public int Cell41
        {
            get
            {
                return _sudoku[3, 0];
            }
            set
            {
                if (value != _sudoku[3, 0])
                {
                    _sudoku[3, 0] = value;
                    OnPropertyChanged("Cell41");
                }
            }

        }

        public int Cell42
        {
            get
            {
                return _sudoku[3, 1];
            }
            set
            {
                if (value != _sudoku[3, 1])
                {
                    _sudoku[3, 1] = value;
                    OnPropertyChanged("Cell42");
                }
            }
        }

        public int Cell43
        {
            get
            {
                return _sudoku[3, 2];
            }
            set
            {
                if (value != _sudoku[3, 2])
                {
                    _sudoku[3, 2] = value;
                    OnPropertyChanged("Cell43");
                }
            }
        }

        public int Cell51
        {
            get
            {
                return _sudoku[3, 3];
            }
            set
            {
                if (value != _sudoku[3, 3])
                {
                    _sudoku[3, 3] = value;
                    OnPropertyChanged("Cell51");
                }
            }
        }

        public int Cell52
        {
            get
            {
                return _sudoku[3, 4];
            }
            set
            {
                if (value != _sudoku[3, 4])
                {
                    _sudoku[3, 4] = value;
                    OnPropertyChanged("Cell52");
                }
            }
        }

        public int Cell53
        {
            get
            {
                return _sudoku[3, 5];
            }
            set
            {
                if (value != _sudoku[3, 5])
                {
                    _sudoku[3, 5] = value;
                    OnPropertyChanged("Cell53");
                }
            }
        }

        public int Cell61
        {
            get
            {
                return _sudoku[3, 6];
            }
            set
            {
                if (value != _sudoku[3, 6])
                {
                    _sudoku[3, 6] = value;
                    OnPropertyChanged("Cell61");
                }
            }
        }

        public int Cell62
        {
            get
            {
                return _sudoku[3, 7];
            }
            set
            {
                if (value != _sudoku[3, 7])
                {
                    _sudoku[3, 7] = value;
                    OnPropertyChanged("Cell62");
                }
            }
        }

        public int Cell63
        {
            get
            {
                return _sudoku[3, 8];
            }
            set
            {
                if (value != _sudoku[3, 8])
                {
                    _sudoku[3, 8] = value;
                    OnPropertyChanged("Cell63");
                }
            }
        }



        public int Cell44
        {
            get
            {
                return _sudoku[4, 0];
            }
            set
            {
                if (value != _sudoku[4, 0])
                {
                    _sudoku[4, 0] = value;
                    OnPropertyChanged("Cell44");
                }
            }
        }

        public int Cell45
        {
            get
            {
                return _sudoku[4, 1];
            }
            set
            {
                if (value != _sudoku[4, 1])
                {
                    _sudoku[4, 1] = value;
                    OnPropertyChanged("Cell45");
                }
            }
        }

        public int Cell46
        {
            get
            {
                return _sudoku[4, 2];
            }
            set
            {
                if (value != _sudoku[4, 2])
                {
                    _sudoku[4, 2] = value;
                    OnPropertyChanged("Cell46");
                }
            }
        }

        public int Cell54
        {
            get
            {
                return _sudoku[4, 3];
            }
            set
            {
                if (value != _sudoku[4, 3])
                {
                    _sudoku[4, 3] = value;
                    OnPropertyChanged("Cell54");
                }
            }
        }

        public int Cell55
        {
            get
            {
                return _sudoku[4, 4];
            }
            set
            {
                if (value != _sudoku[4, 4])
                {
                    _sudoku[4, 4] = value;
                    OnPropertyChanged("Cell55");
                }
            }
        }

        public int Cell56
        {
            get
            {
                return _sudoku[4, 5];
            }
            set
            {
                if (value != _sudoku[4, 5])
                {
                    _sudoku[4, 5] = value;
                    OnPropertyChanged("Cell56");
                }
            }
        }

        public int Cell64
        {
            get
            {
                return _sudoku[4, 6];
            }
            set
            {
                if (value != _sudoku[4, 6])
                {
                    _sudoku[4, 6] = value;
                    OnPropertyChanged("Cell64");
                }
            }
        }

        public int Cell65
        {
            get
            {
                return _sudoku[4, 7];
            }
            set
            {
                if (value != _sudoku[4, 7])
                {
                    _sudoku[4, 7] = value;
                    OnPropertyChanged("Cell65");
                }
            }
        }

        public int Cell66
        {
            get
            {
                return _sudoku[4, 8];
            }
            set
            {
                if (value != _sudoku[4, 8])
                {
                    _sudoku[4, 8] = value;
                    OnPropertyChanged("Cell66");
                }
            }
        }




        public int Cell47
        {
            get
            {
                return _sudoku[5, 0];
            }
            set
            {
                if (value != _sudoku[5, 0])
                {
                    _sudoku[5, 0] = value;
                    OnPropertyChanged("Cell47");
                }
            }
        }

        public int Cell48
        {
            get
            {
                return _sudoku[5, 1];
            }
            set
            {
                if (value != _sudoku[5, 1])
                {
                    _sudoku[5, 1] = value;
                    OnPropertyChanged("Cell48");
                }
            }
        }

        public int Cell49
        {
            get
            {
                return _sudoku[5, 2];
            }
            set
            {
                if (value != _sudoku[5, 2])
                {
                    _sudoku[5, 2] = value;
                    OnPropertyChanged("Cell49");
                }
            }
        }

        public int Cell57
        {
            get
            {
                return _sudoku[5, 3];
            }
            set
            {
                if (value != _sudoku[5, 3])
                {
                    _sudoku[5, 3] = value;
                    OnPropertyChanged("Cell57");
                }
            }
        }

        public int Cell58
        {
            get
            {
                return _sudoku[5, 4];
            }
            set
            {
                if (value != _sudoku[5, 4])
                {
                    _sudoku[5, 4] = value;
                    OnPropertyChanged("Cell58");
                }
            }
        }

        public int Cell59
        {
            get
            {
                return _sudoku[5, 5];
            }
            set
            {
                if (value != _sudoku[5, 5])
                {
                    _sudoku[5, 5] = value;
                    OnPropertyChanged("Cell59");
                }
            }
        }

        public int Cell67
        {
            get
            {
                return _sudoku[5, 6];
            }
            set
            {
                if (value != _sudoku[5, 6])
                {
                    _sudoku[5, 6] = value;
                    OnPropertyChanged("Cell67");
                }
            }
        }

        public int Cell68
        {
            get
            {
                return _sudoku[5, 7];
            }
            set
            {
                if (value != _sudoku[5, 7])
                {
                    _sudoku[5, 7] = value;
                    OnPropertyChanged("Cell68");
                }
            }
        }

        public int Cell69
        {
            get
            {
                return _sudoku[5, 8];
            }
            set
            {
                if (value != _sudoku[5, 8])
                {
                    _sudoku[5, 8] = value;
                    OnPropertyChanged("Cell69");
                }
            }
        }



        public int Cell71
        {
            get
            {
                return _sudoku[6, 0];
            }
            set
            {
                if (value != _sudoku[6, 0])
                {
                    _sudoku[6, 0] = value;
                    OnPropertyChanged("Cell71");
                }
            }
        }

        public int Cell72
        {
            get
            {
                return _sudoku[6, 1];
            }
            set
            {
                if (value != _sudoku[6, 1])
                {
                    _sudoku[6, 1] = value;
                    OnPropertyChanged("Cell72");
                }
            }
        }

        public int Cell73
        {
            get
            {
                return _sudoku[6, 2];
            }
            set
            {
                if (value != _sudoku[6, 2])
                {
                    _sudoku[6, 2] = value;
                    OnPropertyChanged("Cell73");
                }
            }
        }

        public int Cell81
        {
            get
            {
                return _sudoku[6, 3];
            }
            set
            {
                if (value != _sudoku[6, 3])
                {
                    _sudoku[6, 3] = value;
                    OnPropertyChanged("Cell81");
                }
            }
        }

        public int Cell82
        {
            get
            {
                return _sudoku[6, 4];
            }
            set
            {
                if (value != _sudoku[6, 4])
                {
                    _sudoku[6, 4] = value;
                    OnPropertyChanged("Cell82");
                }
            }
        }

        public int Cell83
        {
            get
            {
                return _sudoku[6, 5];
            }
            set
            {
                if (value != _sudoku[6, 5])
                {
                    _sudoku[6, 5] = value;
                    OnPropertyChanged("Cell83");
                }
            }
        }

        public int Cell91
        {
            get
            {
                return _sudoku[6, 6];
            }
            set
            {
                if (value != _sudoku[6, 6])
                {
                    _sudoku[6, 6] = value;
                    OnPropertyChanged("Cell91");
                }
            }
        }

        public int Cell92
        {
            get
            {
                return _sudoku[6, 7];
            }
            set
            {
                if (value != _sudoku[6, 7])
                {
                    _sudoku[6, 7] = value;
                    OnPropertyChanged("Cell92");
                }
            }
        }

        public int Cell93
        {
            get
            {
                return _sudoku[6, 8];
            }
            set
            {
                if (value != _sudoku[6, 8])
                {
                    _sudoku[6, 8] = value;
                    OnPropertyChanged("Cell93");
                }
            }
        }




        public int Cell74
        {
            get
            {
                return _sudoku[7, 0];
            }
            set
            {
                if (value != _sudoku[7, 0])
                {
                    _sudoku[7, 0] = value;
                    OnPropertyChanged("Cell74");
                }
            }
        }

        public int Cell75
        {
            get
            {
                return _sudoku[7, 1];
            }
            set
            {
                if (value != _sudoku[7, 1])
                {
                    _sudoku[7, 1] = value;
                    OnPropertyChanged("Cell75");
                }
            }
        }

        public int Cell76
        {
            get
            {
                return _sudoku[7, 2];
            }
            set
            {
                if (value != _sudoku[7, 2])
                {
                    _sudoku[7, 2] = value;
                    OnPropertyChanged("Cell76");
                }
            }
        }

        public int Cell84
        {
            get
            {
                return _sudoku[7, 3];
            }
            set
            {
                if (value != _sudoku[7, 3])
                {
                    _sudoku[7, 3] = value;
                    OnPropertyChanged("Cell84");
                }
            }
        }

        public int Cell85
        {
            get
            {
                return _sudoku[7, 4];
            }
            set
            {
                if (value != _sudoku[7, 4])
                {
                    _sudoku[7, 4] = value;
                    OnPropertyChanged("Cell85");
                }
            }
        }

        public int Cell86
        {
            get
            {
                return _sudoku[7, 5];
            }
            set
            {
                if (value != _sudoku[7, 5])
                {
                    _sudoku[7, 5] = value;
                    OnPropertyChanged("Cell86");
                }
            }
        }

        public int Cell94
        {
            get
            {
                return _sudoku[7, 6];
            }
            set
            {
                if (value != _sudoku[7, 6])
                {
                    _sudoku[7, 6] = value;
                    OnPropertyChanged("Cell94");
                }
            }
        }

        public int Cell95
        {
            get
            {
                return _sudoku[7, 7];
            }
            set
            {
                if (value != _sudoku[7, 7])
                {
                    _sudoku[7, 7] = value;
                    OnPropertyChanged("Cell95");
                }
            }
        }

        public int Cell96
        {
            get
            {
                return _sudoku[7, 8];
            }
            set
            {
                if (value != _sudoku[7, 8])
                {
                    _sudoku[7, 8] = value;
                    OnPropertyChanged("Cell96");
                }
            }
        }




        public int Cell77
        {
            get
            {
                return _sudoku[8, 0];
            }
            set
            {
                if (value != _sudoku[8, 0])
                {
                    _sudoku[8, 0] = value;
                    OnPropertyChanged("Cell77");
                }
            }
        }

        public int Cell78
        {
            get
            {
                return _sudoku[8, 1];
            }
            set
            {
                if (value != _sudoku[8, 1])
                {
                    _sudoku[8, 1] = value;
                    OnPropertyChanged("Cell78");
                }
            }
        }

        public int Cell79
        {
            get
            {
                return _sudoku[8, 2];
            }
            set
            {
                if (value != _sudoku[8, 2])
                {
                    _sudoku[8, 2] = value;
                    OnPropertyChanged("Cell79");
                }
            }
        }

        public int Cell87
        {
            get
            {
                return _sudoku[8, 3];
            }
            set
            {
                if (value != _sudoku[8, 3])
                {
                    _sudoku[8, 3] = value;
                    OnPropertyChanged("Cell87");
                }
            }
        }

        public int Cell88
        {
            get
            {
                return _sudoku[8, 4];
            }
            set
            {
                if (value != _sudoku[8, 4])
                {
                    _sudoku[8, 4] = value;
                    OnPropertyChanged("Cell88");
                }
            }
        }

        public int Cell89
        {
            get
            {
                return _sudoku[8, 5];
            }
            set
            {
                if (value != _sudoku[8, 5])
                {
                    _sudoku[8, 5] = value;
                    OnPropertyChanged("Cell89");
                }
            }
        }

        public int Cell97
        {
            get
            {
                return _sudoku[8, 6];
            }
            set
            {
                if (value != _sudoku[8, 6])
                {
                    _sudoku[8, 6] = value;
                    OnPropertyChanged("Cell97");
                }
            }
        }

        public int Cell98
        {
            get
            {
                return _sudoku[8, 7];
            }
            set
            {
                if (value != _sudoku[8, 7])
                {
                    _sudoku[8, 7] = value;
                    OnPropertyChanged("Cell98");
                }
            }
        }

        public int Cell99
        {
            get
            {
                return _sudoku[8, 8];
            }
            set
            {
                if (value != _sudoku[8, 8])
                {
                    _sudoku[8, 8] = value;
                    OnPropertyChanged("Cell99");
                }
            }
        }


        #endregion
    }
}

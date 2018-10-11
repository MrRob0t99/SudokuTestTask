using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using TestTask.My;


namespace TestTask
{
    public partial class MainWindow : Window
    {
        public ApplicationViewModel ApplicationViewModel { get; set; } = new ApplicationViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = ApplicationViewModel;
            Res();
        }

        public void Res()
        {
            var grid = new Grid();
            var button = new Button();
            int col = 0;
            int row = 0;
            Border brdr = new Border()
            {
                BorderThickness = new Thickness()
                {
                    Bottom = 1,
                    Left = 1,
                    Right = 1,
                    Top = 1
                },
                BorderBrush = new SolidColorBrush(Colors.Black)
            };

            for (int i = 1; i < 10; i++)
            {
                int innerCol = 0;
                int innerRow = 0;
                for (int j = 0; j < 3; j++)
                {
                    grid.ColumnDefinitions.Add(new ColumnDefinition());
                    grid.RowDefinitions.Add(new RowDefinition());
                }

                grid.ShowGridLines = true;
                for (int j = 1; j < 10; j++)
                {
                    grid.Children.Add(button);
                    button.Name = "Cell" + i + j;
                    Binding binding = new Binding();
                    binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                    binding.Mode = BindingMode.TwoWay;
                    binding.Path = new PropertyPath("Cell" + i + j);
                    button.SetBinding(Button.ContentProperty, binding);
                    button.SetBinding(Button.CommandProperty, new Binding("ShowCommand"));
                    button.SetValue(Button.CommandParameterProperty,"Cell" + i + j);
                    Grid.SetRow(button, innerRow);
                    Grid.SetColumn(button, innerCol);
                    innerCol++;

                    if (j != 0 && j % 3 == 0)
                        innerRow++;

                    if (innerCol == 3)
                        innerCol = 0;

                    button = new Button();
                }

                myGrid.Children.Add(grid);
                Grid.SetRow(grid, row);
                Grid.SetColumn(grid, col);
                col++;
                if (i != 0 && i % 3 == 0)
                    row++;
                if (col == 3)
                    col = 0;
                grid = new Grid();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}

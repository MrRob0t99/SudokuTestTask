using System.Windows;
using System.Windows.Controls;


namespace TestTask
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Res();
        }

        public void Res()
        {
            var grid = new Grid();
            var button = new Button();
            int col = 0;
            int row = 0;
            for (int i = 1; i < 10; i++)
            {
                int innerCol = 0;
                int innerRow = 0;
                for (int j = 0; j < 3; j++)
                {
                    grid.ColumnDefinitions.Add(new ColumnDefinition() );
                    grid.RowDefinitions.Add(new RowDefinition());
                }

                grid.ShowGridLines = true;
                for (int j = 1; j < 10; j++)
                {
                    grid.Children.Add(button); 
                    button.Content = "Binding Cell";
                    Grid.SetRow(button, innerRow);
                    Grid.SetColumn(button, innerCol);
                    innerCol++;
                    if (j != 0 && j % 3 == 0)
                        innerRow++;
                    if (innerCol == 3)
                        innerCol = 0;
                    button = new Button();
                }

                col++;
                if (i != 0 && i % 3 == 0)
                    row++;
                if (col == 3)
                    col = 0;
                myGrid.Children.Add(grid);
                Grid.SetRow(grid, row);
                Grid.SetColumn(grid, col);
                grid = new Grid();
            }
            //var button = myGrid.Children
            //    .Cast<Button>()
            //    .First(e => Grid.GetRow(e) == 0 && Grid.GetColumn(e) == 0);

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

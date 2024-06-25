using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Game2048;

public partial class GameWindow : Window
{
    //public string[,] Array { get; set; }
    public GameWindow()
    {
        InitializeComponent();
        PlayingArea.ItemsSource = ListOfCells.cells.ToArray();
        //for (int i = 0; i < Array.GetLength(0); i++)
        //{
        //    for (int j = 0; j < Array.GetLength(1); j++)
        //    {

        //    }
        //}
    }
}
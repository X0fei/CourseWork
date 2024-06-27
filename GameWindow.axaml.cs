using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;

namespace Game2048;

public partial class GameWindow : Window
{
    bool win = false;
    public List<Border> borders = [
        new Border()
        {
            Name = "Block00"
        }
    ];
    public GameWindow()
    {
        InitializeComponent();
        //PlayingArea.ItemsSource = ListOfCells.cells.ToArray();
        Block00.Text = Cells.Arr[0, 0].ToString();
        Block01.Text = Cells.Arr[0, 1].ToString();
        Block02.Text = Cells.Arr[0, 2].ToString();
        Block03.Text = Cells.Arr[0, 3].ToString();
        Block10.Text = Cells.Arr[1, 0].ToString();
        Block11.Text = Cells.Arr[1, 1].ToString();
        Block12.Text = Cells.Arr[1, 2].ToString();
        Block13.Text = Cells.Arr[1, 3].ToString();
        Block20.Text = Cells.Arr[2, 0].ToString();
        Block21.Text = Cells.Arr[2, 1].ToString();
        Block22.Text = Cells.Arr[2, 2].ToString();
        Block23.Text = Cells.Arr[2, 3].ToString();
        Block30.Text = Cells.Arr[3, 0].ToString();
        Block31.Text = Cells.Arr[3, 1].ToString();
        Block33.Text = Cells.Arr[3, 3].ToString();
        Block32.Text = Cells.Arr[3, 2].ToString();
        WinCheck();
        if (win != true)
            FailCheck();
        //if (Cells.Arr[0, 0] == null)
        //{
        //    Border00.Background = Avalonia.Media.Brush.Parse("#cdc2b3");
        //}
        foreach (Border border in borders)
        {
            if (Cells.Arr[0, 0] == null)
            {
                border.Background = Avalonia.Media.Brush.Parse("#cdc2b3");
            }
        }
    }
    public void MoveRight(object sender, RoutedEventArgs args)
    {
        foreach (Cells row in ListOfCells.cells)
        {
            if (row.Cell4 != null)
            {
                if (row.Cell4 == row.Cell3)
                {
                    row.Cell4 += row.Cell3;
                    row.Cell3 = null;
                }
                else if (row.Cell3 == null)
                {
                    if (row.Cell4 == row.Cell2)
                    {
                        row.Cell4 += row.Cell2;
                        row.Cell2 = null;
                    }
                    else if (row.Cell2 == null)
                    {
                        if (row.Cell4 == row.Cell1)
                        {
                            row.Cell4 += row.Cell1;
                            row.Cell1 = null;
                        }
                    }
                }
            }
            if (row.Cell3 != null)
            {
                if (row.Cell3 == row.Cell2)
                {
                    row.Cell3 += row.Cell2;
                    row.Cell2 = null;
                }
                else if (row.Cell2 == null)
                {
                    if (row.Cell3 == row.Cell1)
                    {
                        row.Cell3 += row.Cell1;
                        row.Cell1 = null;
                    }
                }
                if (row.Cell4 == null)
                {
                    row.Cell4 = row.Cell3;
                    row.Cell3 = null;
                }
            }
            if (row.Cell2 != null)
            {
                if (row.Cell2 == row.Cell1)
                {
                    row.Cell2 += row.Cell1;
                    row.Cell1 = null;
                }
                if (row.Cell3 == null)
                {
                    row.Cell3 = row.Cell2;
                    row.Cell2 = null;
                    if (row.Cell4 == null)
                    {
                        row.Cell4 = row.Cell3;
                        row.Cell3 = null;
                    }
                }
            }
            if (row.Cell1 != null)
            {
                if (row.Cell2 == null)
                {
                    row.Cell2 = row.Cell1;
                    row.Cell1 = null;
                    if (row.Cell3 == null)
                    {
                        row.Cell3 = row.Cell2;
                        row.Cell2 = null;
                        if (row.Cell4 == null)
                        {
                            row.Cell4 = row.Cell3;
                            row.Cell3 = null;
                        }
                    }
                }
            }
        }
        GameWindow gameWindow = new();
        gameWindow.Show();
        Close();
    }
    public void MoveLeft(object sender, RoutedEventArgs args)
    {
        foreach (Cells row in ListOfCells.cells)
        {
            if (row.Cell1 != null)
            {
                if (row.Cell1 == row.Cell2)
                {
                    row.Cell1 += row.Cell2;
                    row.Cell2 = null;
                }
                else if (row.Cell2 == null)
                {
                    if (row.Cell1 == row.Cell3)
                    {
                        row.Cell1 += row.Cell3;
                        row.Cell3 = null;
                    }
                    else if (row.Cell3 == null)
                    {
                        if (row.Cell1 == row.Cell4)
                        {
                            row.Cell1 += row.Cell4;
                            row.Cell4 = null;
                        }
                    }
                }
            }
            if (row.Cell2 != null)
            {
                if (row.Cell2 == row.Cell3)
                {
                    row.Cell2 += row.Cell3;
                    row.Cell3 = null;
                }
                else if (row.Cell3 == null)
                {
                    if (row.Cell2 == row.Cell4)
                    {
                        row.Cell2 += row.Cell4;
                        row.Cell4 = null;
                    }
                }
                if (row.Cell1 == null)
                {
                    row.Cell1 = row.Cell2;
                    row.Cell2 = null;
                }
            }
            if (row.Cell3 != null)
            {
                if (row.Cell3 == row.Cell4)
                {
                    row.Cell3 += row.Cell4;
                    row.Cell4 = null;
                }
                if (row.Cell2 == null)
                {
                    row.Cell2 = row.Cell3;
                    row.Cell3 = null;
                    if (row.Cell1 == null)
                    {
                        row.Cell1 = row.Cell2;
                        row.Cell2 = null;
                    }
                }
            }
            if (row.Cell4 != null)
            {
                if (row.Cell3 == null)
                {
                    row.Cell3 = row.Cell4;
                    row.Cell4 = null;
                    if (row.Cell2 == null)
                    {
                        row.Cell2 = row.Cell3;
                        row.Cell3 = null;
                        if (row.Cell1 == null)
                        {
                            row.Cell1 = row.Cell2;
                            row.Cell2 = null;
                        }
                    }
                }
            }
        }
        GameWindow gameWindow = new();
        gameWindow.Show();
        Close();
    }
    public void WinCheck()
    {
        foreach (Cells row in ListOfCells.cells)
        {
            if (row.Cell1 == 2048 || row.Cell2 == 2048 || row.Cell3 == 2048 || row.Cell4 == 2048)
            {
                Victory.IsVisible = true;
                RightButton.IsVisible = false;
                LeftButton.IsVisible = false;
                UpButton.IsVisible = false;
                DownButton.IsVisible = false;
                win = true;
            }
        }
    }
    public void FailCheck()
    {
        bool checking = true;
        foreach(Cells row in ListOfCells.cells)
        {
            if (row.Cell1 == null || row.Cell2 == null || row.Cell3 == null || row.Cell4 == null)
            {
                checking = false;
            }
        }
        if (checking == true && ListOfCells.cells[0].Cell1 != ListOfCells.cells[0].Cell2 &&
            ListOfCells.cells[0].Cell1 != ListOfCells.cells[1].Cell1 &&
            ListOfCells.cells[0].Cell2 != ListOfCells.cells[0].Cell3 &&
            ListOfCells.cells[0].Cell2 != ListOfCells.cells[1].Cell2 &&
            ListOfCells.cells[0].Cell3 != ListOfCells.cells[0].Cell4 &&
            ListOfCells.cells[0].Cell3 != ListOfCells.cells[1].Cell3 &&
            ListOfCells.cells[0].Cell4 != ListOfCells.cells[1].Cell4 &&
            ListOfCells.cells[1].Cell1 != ListOfCells.cells[1].Cell2 &&
            ListOfCells.cells[1].Cell1 != ListOfCells.cells[2].Cell1 &&
            ListOfCells.cells[1].Cell2 != ListOfCells.cells[1].Cell3 &&
            ListOfCells.cells[1].Cell2 != ListOfCells.cells[2].Cell2 &&
            ListOfCells.cells[1].Cell3 != ListOfCells.cells[1].Cell4 &&
            ListOfCells.cells[1].Cell3 != ListOfCells.cells[2].Cell3 &&
            ListOfCells.cells[1].Cell4 != ListOfCells.cells[2].Cell4 &&
            ListOfCells.cells[2].Cell1 != ListOfCells.cells[2].Cell2 &&
            ListOfCells.cells[2].Cell1 != ListOfCells.cells[3].Cell1 &&
            ListOfCells.cells[2].Cell2 != ListOfCells.cells[2].Cell3 &&
            ListOfCells.cells[2].Cell2 != ListOfCells.cells[3].Cell2 &&
            ListOfCells.cells[2].Cell3 != ListOfCells.cells[2].Cell4 &&
            ListOfCells.cells[2].Cell3 != ListOfCells.cells[3].Cell3 &&
            ListOfCells.cells[2].Cell4 != ListOfCells.cells[3].Cell4 &&
            ListOfCells.cells[3].Cell1 != ListOfCells.cells[3].Cell2 &&
            ListOfCells.cells[3].Cell2 != ListOfCells.cells[3].Cell3 &&
            ListOfCells.cells[3].Cell3 != ListOfCells.cells[3].Cell4)
        {
            Fail.IsVisible = true;
            RightButton.IsVisible = false;
            LeftButton.IsVisible = false;
            UpButton.IsVisible = false;
            DownButton.IsVisible = false;
        }
    }
}
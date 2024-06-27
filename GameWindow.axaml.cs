using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
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
        Filling();
        WinOrFailCheck();
        //WinCheck();
        //if (win != true)
        //    FailCheck();
        //if (Cells.Arr[0, 0] == null)
        //{
        //    Border00.Background = Avalonia.Media.Brush.Parse("#cdc2b3");
        //}
        //foreach (Border border in borders)
        //{
        //    if (Cells.Arr[0, 0] == null)
        //    {
        //        border.Background = Avalonia.Media.Brush.Parse("#cdc2b3");
        //    }
        //}
    }
    public void Filling()
    {
        int newCells = 0;
        int filledCells = 0;
        for (int i = 0; i < Cells.Arr.GetLength(0); i++)
        {
            for (int j = 0; j <  Cells.Arr.GetLength(1); j++)
            {
                if (Cells.Arr[i, j] != null)
                {
                    filledCells++;
                }
            }
        }
        if (filledCells > 0)
        {
            newCells++;
        }
        if (filledCells == 16)
        {
            newCells = 2;
        }
        while (newCells < 2)
        {
            Random random = new Random();
            int x = random.Next(0, 4);
            int y = random.Next(0, 4);
            if (Cells.Arr[x, y] == null)
            {
                Cells.Arr[x, y] = 2;
                newCells++;
            }
        }
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
    }
    public void MoveLeft(object sender, RoutedEventArgs args)
    {
        //foreach (Cells row in ListOfCells.cells)
        //{
        //    if (row.Cell1 != null)
        //    {
        //        if (row.Cell1 == row.Cell2)
        //        {
        //            row.Cell1 += row.Cell2;
        //            row.Cell2 = null;
        //        }
        //        else if (row.Cell2 == null)
        //        {
        //            if (row.Cell1 == row.Cell3)
        //            {
        //                row.Cell1 += row.Cell3;
        //                row.Cell3 = null;
        //            }
        //            else if (row.Cell3 == null)
        //            {
        //                if (row.Cell1 == row.Cell4)
        //                {
        //                    row.Cell1 += row.Cell4;
        //                    row.Cell4 = null;
        //                }
        //            }
        //        }
        //    }
        //    if (row.Cell2 != null)
        //    {
        //        if (row.Cell2 == row.Cell3)
        //        {
        //            row.Cell2 += row.Cell3;
        //            row.Cell3 = null;
        //        }
        //        else if (row.Cell3 == null)
        //        {
        //            if (row.Cell2 == row.Cell4)
        //            {
        //                row.Cell2 += row.Cell4;
        //                row.Cell4 = null;
        //            }
        //        }
        //        if (row.Cell1 == null)
        //        {
        //            row.Cell1 = row.Cell2;
        //            row.Cell2 = null;
        //        }
        //    }
        //    if (row.Cell3 != null)
        //    {
        //        if (row.Cell3 == row.Cell4)
        //        {
        //            row.Cell3 += row.Cell4;
        //            row.Cell4 = null;
        //        }
        //        if (row.Cell2 == null)
        //        {
        //            row.Cell2 = row.Cell3;
        //            row.Cell3 = null;
        //            if (row.Cell1 == null)
        //            {
        //                row.Cell1 = row.Cell2;
        //                row.Cell2 = null;
        //            }
        //        }
        //    }
        //    if (row.Cell4 != null)
        //    {
        //        if (row.Cell3 == null)
        //        {
        //            row.Cell3 = row.Cell4;
        //            row.Cell4 = null;
        //            if (row.Cell2 == null)
        //            {
        //                row.Cell2 = row.Cell3;
        //                row.Cell3 = null;
        //                if (row.Cell1 == null)
        //                {
        //                    row.Cell1 = row.Cell2;
        //                    row.Cell2 = null;
        //                }
        //            }
        //        }
        //    }
        //}
        for (int i = 0; i < Cells.Arr.GetLength(0); i++) //÷икл дл€ прохода по всем строкам по очереди
        {
            for (int j = 0; j < Cells.Arr.GetLength(1); j++) //÷икл дл€ прохода по всем столбцам в строке по очереди
            {
                if (Cells.Arr[i, j] != null) //”словие на заполненность €чейки
                {
                    if (j < Cells.Arr.GetLength(1) - 1) //”словие на то, что €чейка Ќ≈ последн€€, так как последнюю €чейку не сравнить со следующими €чейками, потому что их нет
                    {
                        for (int k = j + 1; k < Cells.Arr.GetLength(1); k++) //ѕроходимс€ по всем €чейкам справа от текущей
                        {
                            if (Cells.Arr[i, k] == null) //ѕровер€ем на заполненность €чейки
                            {
                                continue;
                            }
                            else if (Cells.Arr[i, j] == Cells.Arr[i, k]) //—равниваем текущую €чейку с €чейкой справа от неЄ
                            {
                                Cells.Arr[i, j] += Cells.Arr[i, k];
                                Cells.Arr[i, k] = null;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    if (j > 0) //ѕровер€ем текущую €чейку на то, что она не перва€
                    {
                        int? clipboard = Cells.Arr[i, j]; //Ѕуфер дл€ текущей €чейки
                        for (int k = j - 1; k >= 0; k--) //ѕроходимс€ по всем пустым €чейкам слева от текущей
                        {
                            if (Cells.Arr[i, k] == null)
                            {
                                Cells.Arr[i, k] = clipboard; //ѕередвигаем
                                Cells.Arr[i, k + 1] = null;
                            }
                        }
                    }
                }
            }
        }
        GameWindow gameWindow = new();
        gameWindow.Show();
        Close();
    }
    public void MoveRight(object sender, RoutedEventArgs args)
    {
        //foreach (Cells row in ListOfCells.cells)
        //{
        //    if (row.Cell4 != null)
        //    {
        //        if (row.Cell4 == row.Cell3)
        //        {
        //            row.Cell4 += row.Cell3;
        //            row.Cell3 = null;
        //        }
        //        else if (row.Cell3 == null)
        //        {
        //            if (row.Cell4 == row.Cell2)
        //            {
        //                row.Cell4 += row.Cell2;
        //                row.Cell2 = null;
        //            }
        //            else if (row.Cell2 == null)
        //            {
        //                if (row.Cell4 == row.Cell1)
        //                {
        //                    row.Cell4 += row.Cell1;
        //                    row.Cell1 = null;
        //                }
        //            }
        //        }
        //    }
        //    if (row.Cell3 != null)
        //    {
        //        if (row.Cell3 == row.Cell2)
        //        {
        //            row.Cell3 += row.Cell2;
        //            row.Cell2 = null;
        //        }
        //        else if (row.Cell2 == null)
        //        {
        //            if (row.Cell3 == row.Cell1)
        //            {
        //                row.Cell3 += row.Cell1;
        //                row.Cell1 = null;
        //            }
        //        }
        //        if (row.Cell4 == null)
        //        {
        //            row.Cell4 = row.Cell3;
        //            row.Cell3 = null;
        //        }
        //    }
        //    if (row.Cell2 != null)
        //    {
        //        if (row.Cell2 == row.Cell1)
        //        {
        //            row.Cell2 += row.Cell1;
        //            row.Cell1 = null;
        //        }
        //        if (row.Cell3 == null)
        //        {
        //            row.Cell3 = row.Cell2;
        //            row.Cell2 = null;
        //            if (row.Cell4 == null)
        //            {
        //                row.Cell4 = row.Cell3;
        //                row.Cell3 = null;
        //            }
        //        }
        //    }
        //    if (row.Cell1 != null)
        //    {
        //        if (row.Cell2 == null)
        //        {
        //            row.Cell2 = row.Cell1;
        //            row.Cell1 = null;
        //            if (row.Cell3 == null)
        //            {
        //                row.Cell3 = row.Cell2;
        //                row.Cell2 = null;
        //                if (row.Cell4 == null)
        //                {
        //                    row.Cell4 = row.Cell3;
        //                    row.Cell3 = null;
        //                }
        //            }
        //        }
        //    }
        //}
        for (int i = Cells.Arr.GetLength(0) - 1; i >= 0; i--)
        {
            for (int j = Cells.Arr.GetLength(1) - 1; j >= 0; j--)
            {
                if (Cells.Arr[i, j] != null)
                {
                    if (j > 0)
                    {
                        for (int k = j - 1; k >= 0; k--)
                        {
                            if (Cells.Arr[i, k] == null)
                            {
                                continue;
                            }
                            else if (Cells.Arr[i, j] == Cells.Arr[i, k])
                            {
                                Cells.Arr[i, j] += Cells.Arr[i, k];
                                Cells.Arr[i, k] = null;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    if (j < Cells.Arr.GetLength(1) - 1)
                    {
                        int? clipboard = Cells.Arr[i, j];
                        for (int k = j + 1; k < Cells.Arr.GetLength(1); k++)
                        {
                            if (Cells.Arr[i, k] == null)
                            {
                                Cells.Arr[i, k] = clipboard;
                                Cells.Arr[i, k - 1] = null;
                            }
                        }
                    }
                }
            }
        }
        GameWindow gameWindow = new();
        gameWindow.Show();
        Close();
    }
    public void MoveUp(object sender, RoutedEventArgs args)
    {
        for (int j = 0; j < Cells.Arr.GetLength(1); j++)
        {
            for (int i = 0; i < Cells.Arr.GetLength(0); i++)
            {
                if (Cells.Arr[i, j] != null)
                {
                    if (i < Cells.Arr.GetLength(0) - 1)
                    {
                        for (int k = i + 1; k < Cells.Arr.GetLength(0); k++)
                        {
                            if (Cells.Arr[k, j] == null)
                            {
                                continue;
                            }
                            else if (Cells.Arr[i, j] == Cells.Arr[k, j])
                            {
                                Cells.Arr[i, j] += Cells.Arr[k, j];
                                Cells.Arr[k, j] = null;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    if (i > 0)
                    {
                        int? clipboard = Cells.Arr[i, j];
                        for (int k = i - 1; k >= 0; k--)
                        {
                            if (Cells.Arr[k, j] == null)
                            {
                                Cells.Arr[k, j] = clipboard;
                                Cells.Arr[k + 1, j] = null;
                            }
                        }
                    }
                }
            }
        }
        GameWindow gameWindow = new();
        gameWindow.Show();
        Close();
    }
    public void MoveDown(object sender, RoutedEventArgs args)
    {
        for (int j = Cells.Arr.GetLength(1) - 1; j >= 0; j--)
        {
            for (int i = Cells.Arr.GetLength(0) - 1; i >= 0; i--)
            {
                if (Cells.Arr[i, j] != null)
                {
                    if (i > 0)
                    {
                        for (int k = i - 1; k >= 0; k--)
                        {
                            if (Cells.Arr[k, j] == null)
                            {
                                continue;
                            }
                            else if (Cells.Arr[i, j] == Cells.Arr[k, j])
                            {
                                Cells.Arr[i, j] += Cells.Arr[k, j];
                                Cells.Arr[k, j] = null;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    if (i < Cells.Arr.GetLength(0) - 1)
                    {
                        int? clipboard = Cells.Arr[i, j]; //Ѕуфер дл€ текущей €чейки
                        for (int k = i + 1; k < Cells.Arr.GetLength(0); k++) //ѕроходимс€ по всем пустым €чейкам слева от текущей
                        {
                            if (Cells.Arr[k, j] == null)
                            {
                                Cells.Arr[k, j] = clipboard; //ѕередвигаем
                                Cells.Arr[k - 1, j] = null;
                            }
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
    public void WinOrFailCheck()
    {
        for (int i = 0; i < Cells.Arr.GetLength(0); i++)
        {
            for (int j = 0; j < Cells.Arr.GetLength(1); j++)
            {
                if (Cells.Arr[i, j] == 2048)
                {
                    Victory.IsVisible = true;
                    RightButton.IsVisible = false;
                    LeftButton.IsVisible = false;
                    UpButton.IsVisible = false;
                    DownButton.IsVisible = false;
                    break;
                }
            }
            if (Victory.IsVisible == true)
            {
                break;
            }
        }
        if (Victory.IsVisible == false)
        {
            bool canMove = false;
            for (int i = 0; i < Cells.Arr.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.Arr.GetLength(1) - 1; j++)
                {
                    if (Cells.Arr[i, j] == null || Cells.Arr[i, j + 1] == null || Cells.Arr[i, j] == Cells.Arr[i, j + 1])
                    {
                        canMove = true;
                    }
                }
            }
            for (int j = 0; j < Cells.Arr.GetLength(1); j++)
            {
                for (int i = 0; i < Cells.Arr.GetLength(0) - 1; i++)
                {
                    if (Cells.Arr[i, j] == null || Cells.Arr[i + 1, j] == null || Cells.Arr[i, j] == Cells.Arr[i + 1, j])
                    {
                        canMove = true;
                    }
                }
            }
            if (canMove == false)
            {
                Fail.IsVisible = true;
                RightButton.IsVisible = false;
                LeftButton.IsVisible = false;
                UpButton.IsVisible = false;
                DownButton.IsVisible = false;
            }
        }
    }
}
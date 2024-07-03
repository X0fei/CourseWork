using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;

namespace Game2048;

public partial class GameWindow : Window
{
    public GameWindow()
    {
        InitializeComponent();
        NewBlock();
        Filling();
        WinOrFailCheck();
    }
    public GameWindow(bool move)
    {
        InitializeComponent();
        NewBlock(move);
        Filling();
        WinOrFailCheck();
    }
    public void NewBlock()
    {
        int newCells = 0;
        int filledCells = 0;
        for (int i = 0; i < Cells.Arr.GetLength(0); i++)
        {
            for (int j = 0; j < Cells.Arr.GetLength(1); j++)
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
            Random random = new();
            int x = random.Next(0, 4);
            int y = random.Next(0, 4);
            if (Cells.Arr[x, y] == null)
            {
                Cells.Arr[x, y] = 2;
                newCells++;
            }
        }
    }
    public void NewBlock(bool move)
    {
        if (move)
        {
            int newCells = 0;
            int filledCells = 0;
            for (int i = 0; i < Cells.Arr.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.Arr.GetLength(1); j++)
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
                Random random = new();
                int x = random.Next(0, 4);
                int y = random.Next(0, 4);
                if (Cells.Arr[x, y] == null)
                {
                    Cells.Arr[x, y] = 2;
                    newCells++;
                }
            }
        }
    }

    public void Filling()
    {
        for (int i = 0; i < Cells.Arr.GetLength(0); i++)
        {
            for (int j = 0; j < Cells.Arr.GetLength(1); j++)
            {
                TextBlock block = this.FindControl<TextBlock>($"Block{i}{j}");
                Border border = this.FindControl<Border>($"Border{i}{j}");
                block.Text = Cells.Arr[i, j].ToString();
                switch (Cells.Arr[i, j])
                {
                    case 2:
                        border.Background = Avalonia.Media.Brush.Parse("#eee4db");
                        block.Foreground = Avalonia.Media.Brush.Parse("#776e65");
                        break;
                    case 4:
                        border.Background = Avalonia.Media.Brush.Parse("#efe1c7");
                        block.Foreground = Avalonia.Media.Brush.Parse("#776e65");
                        break;
                    case 8:
                        border.Background = Avalonia.Media.Brush.Parse("#f2b179");
                        block.Foreground = Avalonia.Media.Brush.Parse("#fdfaf3");
                        break;
                    case 16:
                        border.Background = Avalonia.Media.Brush.Parse("#f69663");
                        block.Foreground = Avalonia.Media.Brush.Parse("#faf6f3");
                        break;
                    case 32:
                        border.Background = Avalonia.Media.Brush.Parse("#f08261");
                        block.Foreground = Avalonia.Media.Brush.Parse("#f4f3ef");
                        break;
                    case 64:
                        border.Background = Avalonia.Media.Brush.Parse("#f65e3b");
                        block.Foreground = Avalonia.Media.Brush.Parse("#f9f6f2");
                        break;
                    case 128:
                        border.Background = Avalonia.Media.Brush.Parse("#edd072");
                        block.Foreground = Avalonia.Media.Brush.Parse("#f7f7f5");
                        break;
                    case 256:
                        border.Background = Avalonia.Media.Brush.Parse("#edcc61");
                        block.Foreground = Avalonia.Media.Brush.Parse("#f9f6f2");
                        break;
                    case 512:
                        border.Background = Avalonia.Media.Brush.Parse("#edc94f");
                        block.Foreground = Avalonia.Media.Brush.Parse("#f8f5ee");
                        break;
                    case 1024:
                        border.Background = Avalonia.Media.Brush.Parse("#edc53f");
                        block.Foreground = Avalonia.Media.Brush.Parse("#f9f6f2");
                        block.FontSize = 28;
                        break;
                    case 2048:
                        border.Background = Avalonia.Media.Brush.Parse("#edc22e");
                        block.Foreground = Avalonia.Media.Brush.Parse("#f9f6f2");
                        block.FontSize = 28;
                        break;
                    default:
                        border.Background = Avalonia.Media.Brush.Parse("#cdc2b3");
                        break;
                }
            }
        }
    }
    public bool MoveLeftCheck()
    {
        bool canMove = false;
        for (int i = 0;  i < Cells.Arr.GetLength(0); i++)
        {
            for (int j = 0; j < Cells.Arr.GetLength(1) - 1; j++)
            {
                if (Cells.Arr[i, j] == Cells.Arr[i, j + 1] || Cells.Arr[i, j] == null)
                {
                    canMove = true;
                    break;
                }
            }
        }
        return canMove;
    }
    public bool MoveRightCheck()
    {
        bool canMove = false;
        for (int i = Cells.Arr.GetLength(0) - 1; i >= 0; i--)
        {
            for (int j = Cells.Arr.GetLength(1) - 1; j > 0; j--)
            {
                if (Cells.Arr[i, j] == Cells.Arr[i, j - 1] || Cells.Arr[i, j] == null)
                {
                    canMove = true;
                    break;
                }
            }
        }
        return canMove;
    }
    public bool MoveUpCheck()
    {
        bool canMove = false;
        for (int j = 0; j < Cells.Arr.GetLength(1); j++)
        {
            for (int i = 0; i < Cells.Arr.GetLength(0) - 1; i++)
            {
                if (Cells.Arr[i, j] == Cells.Arr[i + 1, j] || Cells.Arr[i, j] == null)
                {
                    canMove = true;
                    break;
                }
            }
        }
        return canMove;
    }
    public bool MoveDownCheck()
    {
        bool canMove = false;
        for (int j = Cells.Arr.GetLength(1) - 1; j >= 0; j--)
        {
            for (int i = Cells.Arr.GetLength(0) - 1; i > 0; i--)
            {
                if (Cells.Arr[i, j] == Cells.Arr[i - 1, j] || Cells.Arr[i, j] == null)
                {
                    canMove = true;
                    break;
                }
            }
        }
        return canMove;
    }
    public void MoveLeft(object sender, RoutedEventArgs args)
    {
        if (MoveLeftCheck())
        {
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
            bool move = true;
            GameWindow gameWindow = new(move);
            gameWindow.Show();
            Close();
        }
    }
    public void MoveRight(object sender, RoutedEventArgs args)
    {
        if (MoveRightCheck())
        {
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
            bool move = true;
            GameWindow gameWindow = new(move);
            gameWindow.Show();
            Close();
        }
    }
    public void MoveUp(object sender, RoutedEventArgs args)
    {
        if (MoveUpCheck())
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
            bool move = true;
            GameWindow gameWindow = new(move);
            gameWindow.Show();
            Close();
        }
    }
    public void MoveDown(object sender, RoutedEventArgs args)
    {
        if (MoveDownCheck())
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
                            int? clipboard = Cells.Arr[i, j];
                            for (int k = i + 1; k < Cells.Arr.GetLength(0); k++)
                            {
                                if (Cells.Arr[k, j] == null)
                                {
                                    Cells.Arr[k, j] = clipboard;
                                    Cells.Arr[k - 1, j] = null;
                                }
                            }
                        }
                    }
                }
            }
            bool move = true;
            GameWindow gameWindow = new(move);
            gameWindow.Show();
            Close();
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
                    PlayAgain.IsVisible = true;
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
                PlayAgain.IsVisible = true;
            }
        }
    }
    public void Restart(object sender, RoutedEventArgs args)
    {
        for (int i = 0; i < Cells.Arr.GetLength(0); i++)
        {
            for (int j = 0; j < Cells.Arr.GetLength(1); j++)
            {
                Cells.Arr[i, j] = null;
            }
        }
        GameWindow gameWindow = new();
        gameWindow.Show();
        Close();
    }
}
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Game2048
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void PlayButtonClick(object sender, RoutedEventArgs args)
        {
            GameWindow gameWindow = new();
            gameWindow.Show();
            Close();
        }
    }
}
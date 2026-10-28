using System.Windows;

namespace WpfTestApp;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void RunButton_Click(object sender, RoutedEventArgs e)
    {
        ResultTextBlock.Text = InputTextBox.Text;
    }
}

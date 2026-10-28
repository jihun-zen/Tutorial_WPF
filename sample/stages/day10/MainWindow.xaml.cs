using System.Windows;

namespace WpfTestApp;

public partial class MainWindow : Window
{
    private readonly MainViewModel viewModel = new();

    public MainWindow()
    {
        InitializeComponent();
        DataContext = viewModel;
    }

    private void RunButton_Click(object sender, RoutedEventArgs e)
    {
        viewModel.Run();
    }
}

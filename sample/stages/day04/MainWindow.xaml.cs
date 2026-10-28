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
        string input = InputTextBox.Text.Trim();

        if (string.IsNullOrWhiteSpace(input))
        {
            ResultTextBlock.Text = "표시할 결과가 없습니다.";
            StatusTextBlock.Text = "텍스트를 먼저 입력해 주세요.";
            return;
        }

        ResultTextBlock.Text = input;
        StatusTextBlock.Text = "입력한 텍스트를 표시했습니다.";
    }
}

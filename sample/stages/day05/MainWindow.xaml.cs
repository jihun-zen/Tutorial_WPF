using System.Windows;

namespace WpfTestApp;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        PostsGrid.ItemsSource = new List<Post>
        {
            new Post { Id = 1, Title = "첫 번째 예제 게시글" },
            new Post { Id = 2, Title = "두 번째 예제 게시글" }
        };
    }

    private void RunButton_Click(object sender, RoutedEventArgs e)
    {
        string text = InputTextBox.Text.Trim();
        ResultTextBlock.Text = string.IsNullOrWhiteSpace(text) ? "표시할 결과가 없습니다." : text;
        StatusTextBlock.Text = "입력값을 확인했습니다. 표는 고정 예제입니다.";
    }
}

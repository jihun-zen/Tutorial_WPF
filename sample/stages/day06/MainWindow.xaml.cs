using System.Windows;

namespace WpfTestApp;

public partial class MainWindow : Window
{
    public string Result { get; set; } = "바인딩으로 읽은 첫 번째 결과입니다.";
    public List<Post> Posts { get; } = new()
    {
        new Post { Id = 1, Title = "첫 번째 예제 게시글" },
        new Post { Id = 2, Title = "두 번째 예제 게시글" }
    };

    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
    }

    private void RunButton_Click(object sender, RoutedEventArgs e)
    {
        Result = InputTextBox.Text.Trim();
        StatusTextBlock.Text = "C# Result 값은 바뀌었지만 변경 알림은 아직 없습니다.";
    }
}

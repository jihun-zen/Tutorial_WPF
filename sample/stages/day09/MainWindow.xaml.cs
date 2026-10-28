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
        string text = viewModel.Input.Trim();
        if (string.IsNullOrWhiteSpace(text))
        {
            viewModel.Result = "표시할 결과가 없습니다.";
            viewModel.Status = "텍스트를 먼저 입력해 주세요.";
            return;
        }

        viewModel.Posts[0].Title = text;
        viewModel.Posts.Add(new Post { Id = viewModel.Posts.Count + 1, Title = text });
        viewModel.Result = text;
        viewModel.Status = "첫 행의 제목을 수정하고 새 행을 추가했습니다.";
    }
}

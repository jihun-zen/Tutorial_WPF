using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;

namespace WpfTestApp;

public partial class MainWindow : Window, INotifyPropertyChanged
{
    private string input = "안녕하세요, WPF";
    public string Input
    {
        get => input;
        set
        {
            input = value;
            Notify(nameof(Input));
        }
    }

    private string result = "아직 실행하지 않았습니다.";
    public string Result
    {
        get => result;
        private set
        {
            result = value;
            Notify(nameof(Result));
        }
    }

    private string status = "입력 후 실행 버튼을 누르세요.";
    public string Status
    {
        get => status;
        private set
        {
            status = value;
            Notify(nameof(Status));
        }
    }

    public ObservableCollection<Post> Posts { get; } = new()
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
        Run();
    }

    public void Run()
    {
        string text = Input.Trim();
        if (string.IsNullOrWhiteSpace(text))
        {
            Result = "표시할 결과가 없습니다.";
            Status = "텍스트를 먼저 입력해 주세요.";
            return;
        }

        Posts[0].Title = text;
        Posts.Add(new Post { Id = Posts.Count + 1, Title = text });
        Result = text;
        Status = "첫 행의 제목을 수정하고 새 행을 추가했습니다.";
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void Notify(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

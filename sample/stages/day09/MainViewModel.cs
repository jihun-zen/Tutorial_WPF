using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfTestApp;

public class MainViewModel : INotifyPropertyChanged
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
        set
        {
            result = value;
            Notify(nameof(Result));
        }
    }

    private string status = "입력 후 실행 버튼을 누르세요.";
    public string Status
    {
        get => status;
        set
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

    public event PropertyChangedEventHandler? PropertyChanged;

    private void Notify(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

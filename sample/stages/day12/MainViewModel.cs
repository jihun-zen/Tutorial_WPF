using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WpfTestApp;

public class MainViewModel : ObservableObject
{
    private string input = "안녕하세요, WPF";
    public string Input
    {
        get => input;
        set
        {
            if (SetProperty(ref input, value))
            {
                RunCommand.NotifyCanExecuteChanged();
            }
        }
    }

    private string result = "아직 실행하지 않았습니다.";
    public string Result
    {
        get => result;
        private set => SetProperty(ref result, value);
    }

    private string status = "입력 후 실행 버튼을 누르세요.";
    public string Status
    {
        get => status;
        private set => SetProperty(ref status, value);
    }

    public ObservableCollection<Post> Posts { get; } = new();

    public IRelayCommand RunCommand { get; }

    public MainViewModel()
    {
        RunCommand = new RelayCommand(Run, CanRun);
    }

    private bool CanRun()
    {
        return !string.IsNullOrWhiteSpace(Input);
    }

    private void Run()
    {
        string text = Input.Trim();
        if (string.IsNullOrWhiteSpace(text))
        {
            Result = "표시할 결과가 없습니다.";
            Status = "텍스트를 먼저 입력해 주세요.";
            return;
        }

        Posts.Clear();
        Posts.Add(new Post { Id = 1, Title = text });
        Result = text;
        Status = "입력한 텍스트를 예제 행으로 표시했습니다.";
    }
}

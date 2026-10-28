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

    public IAsyncRelayCommand RunCommand { get; }

    public MainViewModel()
    {
        RunCommand = new AsyncRelayCommand(RunAsync, CanRun);
    }

    private bool CanRun()
    {
        return !string.IsNullOrWhiteSpace(Input);
    }

    private async Task RunAsync()
    {
        string text = Input.Trim();
        Posts.Clear();
        Result = "처리 중입니다.";
        Status = "2초를 기다리는 동안에도 창을 움직일 수 있습니다.";

        await Task.Delay(2000);

        Posts.Add(new Post { Id = 1, Title = text });
        Result = "1건을 표시했습니다.";
        Status = "대기가 끝났습니다.";
    }
}

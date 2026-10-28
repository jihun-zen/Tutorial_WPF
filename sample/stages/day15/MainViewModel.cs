using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace WpfTestApp;

public class MainViewModel : ObservableObject
{
    private static readonly HttpClient client = new()
    {
        Timeout = TimeSpan.FromSeconds(15)
    };

    private string input = "https://jsonplaceholder.typicode.com/posts?userId=1";
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
        Posts.Clear();
        Result = "아직 표시할 결과가 없습니다.";

        if (!Uri.TryCreate(Input.Trim(), UriKind.Absolute, out Uri? uri)
            || (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
        {
            Status = "http 또는 https로 시작하는 API URL을 입력해 주세요.";
            return;
        }

        Status = "API 응답을 기다리는 중입니다.";

        try
        {
            List<Post>? posts = await client.GetFromJsonAsync<List<Post>>(
                uri);
            if (posts is null)
            {
                throw new JsonException("게시글 배열이 필요합니다.");
            }

            foreach (Post post in posts)
            {
                Posts.Add(post);
            }

            Result = $"결과 {Posts.Count}건";
            Status = "GET 요청을 완료했습니다.";
        }
        catch (HttpRequestException)
        {
            Status = "요청에 실패했습니다. URL, 인터넷 연결, HTTP 응답 상태를 확인하세요.";
        }
        catch (JsonException)
        {
            Status = "응답이 예상한 게시글 JSON 배열 형식이 아닙니다.";
        }
        catch (OperationCanceledException)
        {
            Status = "요청 시간이 초과되었습니다. 잠시 후 다시 실행하세요.";
        }
    }
}

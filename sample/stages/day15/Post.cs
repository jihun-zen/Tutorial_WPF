namespace WpfTestApp;

// JSON 응답을 이 C# 클래스의 속성으로 읽어 옵니다.
public class Post
{
    public int UserId { get; set; }
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Body { get; set; } = "";
}

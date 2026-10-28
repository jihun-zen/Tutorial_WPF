using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfTestApp;

public class Post : ObservableObject
{
    public int Id { get; set; }

    private string title = "";
    public string Title
    {
        get => title;
        set => SetProperty(ref title, value);
    }
}

using System.ComponentModel;

namespace WpfTestApp;

public class Post : INotifyPropertyChanged
{
    public int Id { get; set; }

    private string title = "";
    public string Title
    {
        get => title;
        set
        {
            title = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}

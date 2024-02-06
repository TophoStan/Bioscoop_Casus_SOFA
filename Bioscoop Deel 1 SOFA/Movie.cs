
namespace Bioscoop_Deel_1_SOFA;

public class Movie
{
    private string Title { get; set; } = string.Empty;

    public Movie(string title)
    {
        Title = title;
    }

    public string getTitle()
    {
        return Title;
    }


    public override string ToString()
    {
        return "Titlename: " + Title;
    }
}

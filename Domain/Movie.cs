namespace Domain;
public class Movie
{
    public string title { get; }

    public Movie(string title)
    {
        this.title = title;
    }

    public void AddScreening(MovieScreening movieScreening)
    {

    }

    public override string ToString()
    {
        return $"Movie Title: {title}";
    }
}

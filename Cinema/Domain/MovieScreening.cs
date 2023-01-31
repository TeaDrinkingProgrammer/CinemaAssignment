using System.Text;

namespace Domain;
public class MovieScreening
{
    public DateTime dateAndTime {get;}
    public double pricePerSeat { get; }

    public Movie movie {get;}

    public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
    {
        this.dateAndTime = dateAndTime;
        this.pricePerSeat = pricePerSeat;
        this.movie = movie;
    }

    public override string ToString()
    {
        var s = new StringBuilder();
        s.AppendLine($"Price per seat: {pricePerSeat}");
        s.AppendLine($"Time: {dateAndTime.ToString()}");
        return s.ToString();
    }
}

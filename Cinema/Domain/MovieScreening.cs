namespace Domain;
public class MovieScreening
{
    DateTime dateAndTime;
    double pricePerSeat { get; }

    Movie movie;

    public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
    {
        this.dateAndTime = dateAndTime;
        this.pricePerSeat = pricePerSeat;
        this.movie = movie;
    }

    public override string ToString()
    {
        return base.ToString();
    }
}

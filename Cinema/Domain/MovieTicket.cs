namespace Domain;
public class MovieTicket
{
    int rowNr;
    int seatNr;
    bool isPremium { get; }

    MovieScreening movieScreening;

    public MovieTicket(MovieScreening movieScreening, bool isPremiumReservation, int seatRow, int seatNr)
    {
        this.isPremium = isPremiumReservation;
        this.rowNr = seatRow;
        this.seatNr = seatNr;
        this.movieScreening = movieScreening;
    }

    public double GetPrice()
    {

    }

    public override string ToString()
    {
        return base.ToString();
    }
}

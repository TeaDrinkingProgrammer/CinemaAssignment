using System.Text;

namespace Domain;
public class MovieTicket
{
    public int rowNr {get;}
    public int seatNr { get; }
    public bool isPremium { get; }

    public MovieScreening movieScreening {get;}

    public MovieTicket(MovieScreening movieScreening, bool isPremiumReservation, int seatRow, int seatNr)
    {
        this.isPremium = isPremiumReservation;
        this.rowNr = seatRow;
        this.seatNr = seatNr;
        this.movieScreening = movieScreening;
    }

    // public double GetPrice()
    // {

    // }

    public override string ToString()
    {
        var s = new StringBuilder();
        s.AppendLine($"Row and Seat: {rowNr}:{seatNr}");
        return s.ToString();
    }
}

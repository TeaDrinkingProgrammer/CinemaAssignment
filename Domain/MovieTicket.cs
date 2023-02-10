using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Domain;
public class MovieTicket
{
    public int rowNr { get; }
    public int seatNr { get; }
    public PriceCalculator priceCalculator { get; }

    public MovieScreening movieScreening { get; }

    public MovieTicket(MovieScreening movieScreening, PriceCalculator priceCalculator, int seatRow, int seatNr)
    {
        this.rowNr = seatRow;
        this.seatNr = seatNr;
        this.movieScreening = movieScreening;
        this.priceCalculator = priceCalculator;
    }

    public decimal GetPrice()
    {
        return this.priceCalculator.GetPrice(this.movieScreening.pricePerSeat);
    }

    public override string ToString()
    {
        var s = new StringBuilder();
        s.AppendLine($"Row and Seat: {rowNr}:{seatNr}");
        return s.ToString();
    }
}

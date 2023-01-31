namespace Domain;
public class MovieTicket
{
    int rowNr;
    int seatNr;
    public bool isPremium { get; }
    public bool isStudentOrder { get; }

    MovieScreening movieScreening;

    public MovieTicket(MovieScreening movieScreening, bool isPremiumReservation, int seatRow, int seatNr, bool isStudentOrder)
    {
        this.isPremium = isPremiumReservation;
        this.rowNr = seatRow;
        this.seatNr = seatNr;
        this.movieScreening = movieScreening;
        this.isStudentOrder = isStudentOrder;
    }

    public double GetPrice()
    {
        if (this.isPremium && this.isStudentOrder)
        {
            return this.movieScreening.pricePerSeat + 2;
        }
        if (this.isPremium)
        {
            return this.movieScreening.pricePerSeat + 3;
        }
        return this.movieScreening.pricePerSeat;
    }

    public override string ToString()
    {
        return base.ToString();
    }
}

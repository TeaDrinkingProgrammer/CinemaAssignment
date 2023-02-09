﻿using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Domain;
public class MovieTicket
{
    public int rowNr { get; }
    public int seatNr { get; }
    public bool isPremium { get; }
    public bool isStudentOrder { get; }

    public MovieScreening movieScreening { get; }

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
        return this.movieScreening.pricePerSeat + (this.isPremium ? (this.isStudentOrder ? 2 : 3) : 0);
    }

    public override string ToString()
    {
        var s = new StringBuilder();
        s.AppendLine($"Row and Seat: {rowNr}:{seatNr}");
        s.AppendLine($"Student discount: {(isStudentOrder ? "yes" : "no")}");
        return s.ToString();
    }
}

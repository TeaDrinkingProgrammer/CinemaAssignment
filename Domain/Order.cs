using System.Text;
using System.Text.Json;

namespace Domain;
public class Order
{
    public int orderNr { get; }

    public List<MovieTicket> movieTickets { get; } = new List<MovieTicket>();

    public Order(int orderNr)
    {
        this.orderNr = orderNr;
    }
    public void AddSeatReservation(MovieTicket ticket)
    {
        this.movieTickets.Add(ticket);
    }

    public decimal CalculatePrice()
    {
        Decimal totalPrice = 0.0m;
        bool containsStudentTicket = false;

        foreach (var (ticket, ticketNumber) in movieTickets.Select((v, i) => (v, i)))
        {
            if (ticket.priceCalculator.GetType() == typeof(StudentPriceCalculator))
            {
                containsStudentTicket = true;
            }

            var dayOfTheWeek = ticket.movieScreening.dateAndTime.DayOfWeek;
            if (
                (ticketNumber + 1) % 2 == 0 
                && 
                (containsStudentTicket || (DayOfWeek.Monday <= dayOfTheWeek && dayOfTheWeek <= DayOfWeek.Thursday))
             ) {
                    break;
            }

            var ticketPrice = ticket.GetPrice();
            totalPrice = totalPrice + ticketPrice;
        }

        if (movieTickets.Count >= 6)
        {
            return totalPrice * 0.9m;
        }

        return totalPrice;

    }

    public void Export(ExportMethod exportMethod)
    {
        exportMethod.export(this);
    }
}
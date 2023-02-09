using System.Text;
using System.Text.Json;

namespace Domain;
public class Order
{
    int orderNr { get; }

    public List<MovieTicket> movieTickets { get; } = new List<MovieTicket>();

    public Order(int orderNr)
    {
        this.orderNr = orderNr;
    }
    public void AddSeatReservation(MovieTicket ticket)
    {
        this.movieTickets.Add(ticket);
    }

    public double CalculatePrice()
    {
        var totalPrice = 0.0;
        bool containsStudentTicket = false;

        foreach (var (ticket, ticketNumber) in movieTickets.Select((v, i) => (v, i)))
        {
            if (ticket.isStudentOrder)
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
            return totalPrice * 0.9;
        }

        return totalPrice;

    }

    public void Export(TicketExportFormat exportFormat)
    {

        if (exportFormat == TicketExportFormat.JSON)
        {
            System.IO.File.WriteAllText(
                @"export.json",
                JsonSerializer.Serialize(
                    this,
                    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true }
                    )
                );
            return;
        }

        if (exportFormat == TicketExportFormat.PLAINTEXT)
        {
            StringBuilder s = new StringBuilder().AppendLine($"OrderNr: {this.orderNr}");

            s.AppendLine("");

            foreach (var (ticket, ticketNumber) in this.movieTickets.Select((v, i) => (v, i)))
            {
                s.AppendLine("----");
                s.AppendLine("");

                s.AppendLine($"Ticket {ticketNumber}:");
                s.AppendLine("");
                s.AppendLine(ticket.movieScreening.movie.ToString());
                s.AppendLine(ticket.movieScreening.ToString());
                s.AppendLine(ticket.ToString());
            }
            System.IO.File.WriteAllText(@"export.txt", s.ToString());
        }
    }
}
namespace Domain;
public class Order
{
    int orderNr { get; }

    List<MovieTicket> movieTickets = new List<MovieTicket>();

    public Order(int orderNr)
    {
        this.orderNr = orderNr;
    }
    public void AddSeatReservation(MovieTicket ticket)
    {

    }

    public double CalculatePrice()
    {
        var totalPrice;
        var ticketPrice;
        bool containsStudentTicket = false;

        foreach(MovieTicket ticket in movieTickets)
        {
            if(ticket.isStudentOrder)
            {
                containsStudentTicket= true;
            }
            ticketPrice = ticket.GetPrice();
            totalPrice = totalPrice + ticketPrice;
        }

        if(movieTickets.Count >= 2)
        {
            if (containsStudentTicket ||
                DateTime.Today.DayOfWeek = DayOfWeek.Monday ||
                DateTime.Today.DayOfWeek = DayOfWeek.Tuesday ||
                DateTime.Today.DayOfWeek = DayOfWeek.Wednesday ||
                DateTime.Today.DayOfWeek = DayOfWeek.Thursday)
            {
                return totalPrice = totalPrice - ticketPrice;
            }
        }

        if (movieTickets.Count >= 6)
        {
            return totalPrice = totalPrice - (totalPrice * 0, 1)
        }
        return totalPrice;

    }

    public void Export(TicketExportFormat exportFormat)
    {

    }

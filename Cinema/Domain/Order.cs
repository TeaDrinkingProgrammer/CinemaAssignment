namespace Domain;
public class Order
{
    int orderNr { get; }
    bool isStudentOrder { get; }

    List<MovieTicket> movieTickets = new List<MovieTicket>();

    public Order(int orderNr, bool isStudentOrder)
    {
        this.orderNr = orderNr;
        this.isStudentOrder = isStudentOrder;
    }
    public void AddSeatReservation(MovieTicket ticket)
    {

    }

    public double CalculatePrice()
    {

    }

    public void Export(TicketExportFormat exportFormat)
    {

    }

using System.Text;

namespace Domain;
public class TXTExport: ExportMethod
{
    
    override public void export(Order order){
            StringBuilder s = new StringBuilder().AppendLine($"OrderNr: {order.orderNr}");

            s.AppendLine("");

            foreach (var (ticket, ticketNumber) in order.movieTickets.Select((v, i) => (v, i)))
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

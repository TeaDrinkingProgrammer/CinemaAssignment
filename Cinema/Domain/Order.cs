using System.Text;
using System.Text.Json;
using System.Collections.Generic;

namespace Domain;
public class Order
{
    public int orderNr { get; }
    public bool isStudentOrder { get; }

    public List<MovieTicket> movieTickets {get;} = new List<MovieTicket>();

    public Order(int orderNr, bool isStudentOrder)
    {
        this.orderNr = orderNr;
        this.isStudentOrder = isStudentOrder;
    }
    public void AddSeatReservation(MovieTicket ticket)
    {
        this.movieTickets.Add(ticket);
    }

    // public double CalculatePrice()
    // {

    // }

    public void Export(TicketExportFormat exportFormat)
    {
        
        if (exportFormat == TicketExportFormat.JSON) {
            System.IO.File.WriteAllText(
                @"export.json", 
                JsonSerializer.Serialize(
                    this,
                    new JsonSerializerOptions(){ PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true }
                    )
                );
            return;
        }

        if (exportFormat == TicketExportFormat.PLAINTEXT) {
            StringBuilder s = new StringBuilder().AppendLine( $"OrderNr: {this.orderNr}");
            if (this.isStudentOrder) {
                s.AppendLine("Studentenorder");
            }
            
            s.AppendLine("");
            
            foreach (var (ticket, ticketNumber) in this.movieTickets.Select((v, i)=> (v, i))) {
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
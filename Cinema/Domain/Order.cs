using System.Text;
using System.Text.Json;
using System.Collections.Generic;
using System;

namespace Domain;
public class Order
{
    int orderNr { get; }

    public List<MovieTicket> movieTickets {get;} = new List<MovieTicket>();

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
        var ticketPrice = 0.0;
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
            if (containsStudentTicket || (DayOfWeek.Monday <= DateTime.Today.DayOfWeek && DateTime.Today.DayOfWeek <= DayOfWeek.Thursday))
            {
                return totalPrice = totalPrice - ticketPrice;
            }
        }

        if (movieTickets.Count >= 6)
        {
            return totalPrice = totalPrice - (totalPrice * 0.1);
        }
        return totalPrice;

    }

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
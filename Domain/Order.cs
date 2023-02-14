using System.Text;
using System.Text.Json;
using Domain.Observer;
using Domain.OrderState;

namespace Domain;
public class Order : Observable
{
    public int orderNr { get; }

    public List<MovieTicket> movieTickets { get; } = new List<MovieTicket>();
    public IOrderState OrderState { get; set; }
    public NewOrderState NewOrderState { get;}
    public ReservedOrderState ReservedOrderState { get; }
    public ProvisionalOrderState ProvisionalOrderState { get; }
    public PayedOrderState PayedOrderState { get; }
    public CancelledOrderState CancelledOrderState { get; }
    public Order(int orderNr)
    {
        this.orderNr = orderNr;
        OrderState = new NewOrderState(this);
        
        NewOrderState = new NewOrderState(this);
        ReservedOrderState = new ReservedOrderState(this);
        ProvisionalOrderState = new ProvisionalOrderState(this);
        PayedOrderState = new PayedOrderState(this);
        CancelledOrderState = new CancelledOrderState(this);
    }

    public void SubmitChanges()
    {
        OrderState.SubmitChanges();
    }
    
    public void Cancel()
    {
        OrderState.Cancel();
    }

    public void Provision()
    {
        OrderState.Provision();
    }

    public void Pay()
    {
        OrderState.Pay();
    }

    public void AddSeatReservation(MovieTicket movieTicket)
    {
        OrderState.AddSeatReservation(movieTicket);
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

    public void AddObserver(IObserver observer)
    {
        if (Observers.Count != 0)
        {
            Console.WriteLine("Cannot add another medium!");
            return;
        }
        
        Observers.Add(observer);
    }

    public void Export(ExportMethod exportMethod)
    {
        exportMethod.export(this);
    }
}
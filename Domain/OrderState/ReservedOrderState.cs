namespace Domain.OrderState;

public class ReservedOrderState : IOrderState
{
    private Order Order;
    
    public ReservedOrderState(Order order)
    {
        Order = order;
    }
    
    public void SubmitChanges()
    {
        Console.WriteLine("Your order is already reserved");
    }

    public void Cancel()
    {
        Console.WriteLine("You cannot cancel");
    }

    public void Pay()
    {
        Order.OrderState = Order.PayedOrderState;
    }

    public void Provision()
    {
        Order.OrderState = Order.ProvisionalOrderState;
    }

    public void AddSeatReservation(MovieTicket movieTicket)
    {
        Order.movieTickets.Add(movieTicket);
    }
}
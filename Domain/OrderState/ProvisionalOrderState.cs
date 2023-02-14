namespace Domain.OrderState;

public class ProvisionalOrderState : IOrderState
{
    private Order Order;
    
    public ProvisionalOrderState(Order order)
    {
        Order = order;
    }
    
    public void SubmitChanges()
    {
        Order.OrderState = Order.NewOrderState;
    }

    public void Cancel()
    {
        Console.WriteLine("Cancelling order..");
        Order.OrderState = Order.CancelledOrderState;
    }

    public void Pay()
    {
        Console.WriteLine("Purchasing tickets..");
        Order.OrderState = Order.PayedOrderState;
    }

    public void Provision()
    {
        Console.WriteLine("Order is already provisioned");
    }

    public void AddSeatReservation(MovieTicket movieTicket)
    {
        Order.movieTickets.Add(movieTicket);
        Order.OrderState = Order.ReservedOrderState;
    }
}
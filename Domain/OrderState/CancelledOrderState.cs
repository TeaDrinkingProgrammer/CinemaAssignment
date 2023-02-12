namespace Domain.OrderState;

public class CancelledOrderState : IOrderState
{
    private Order Order;
    
    public CancelledOrderState(Order order)
    {
        Order = order;
    }
    
    public void SubmitChanges()
    {
        Console.WriteLine("You cannot submit changes: order is cancelled");
    }

    public void Cancel()
    {
        Console.WriteLine("You cannot cancel: Your order has already been cancelled");
    }

    public void Pay()
    {
        Console.WriteLine("Cannot pay: order is cancelled");
    }

    public void Provision()
    {
        Console.WriteLine("Cannot provision: order is already cancelled");
    }

    public void AddSeatReservation(MovieTicket movieTicket)
    {
        Console.WriteLine("Cannot add ticket: order is already cancelled");
    }
}
namespace Domain.OrderState;

public class NewOrderState : IOrderState
{
    private Order Order;
    
    public NewOrderState(Order order)
    {
        Order = order;
    }
    
    public void SubmitChanges()
    {
        Console.WriteLine("Submitting changes...");
        Order.OrderState = Order.ReservedOrderState;
    }

    public void Cancel()
    {
        Console.WriteLine("You have not submitted anything yet");
    }

    public void Pay()
    {
        Console.WriteLine("First submit you order before you can pay");
    }

    public void Provision()
    {
        Console.WriteLine("First submit you order before you provision");
    }

    public void AddSeatReservation(MovieTicket movieTicket)
    {
        Order.movieTickets.Add(movieTicket);
    }
}
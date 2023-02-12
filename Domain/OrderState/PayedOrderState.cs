namespace Domain.OrderState;

public class PayedOrderState : IOrderState
{
    private Order Order;
    
    public PayedOrderState(Order order)
    {
        Order = order;
    }
    
    public void SubmitChanges()
    {
        Console.WriteLine("You have already payed, make a new reservation");
    }

    public void Cancel()
    {
        Console.WriteLine("You cannot cancel");
    }

    public void Pay()
    {
        Console.WriteLine("You have already payed");
    }

    public void Provision()
    {
        Console.WriteLine("Cannot provision: you have already payed");
    }

    public void AddSeatReservation(MovieTicket movieTicket)
    {
        Console.WriteLine("Cannot add seat reservation: you have already purchased all seats");
    }
}
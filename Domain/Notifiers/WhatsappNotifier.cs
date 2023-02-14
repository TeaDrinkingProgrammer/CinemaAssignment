using Domain.Observer;

namespace Domain.Notifications;

public class WhatsappNotifier : IObserver
{
    private Order Order;
    
    public WhatsappNotifier(Order order)
    {
        Order = order;
        Order.AddObserver(this);
    }
    public void update()
    {
        Console.WriteLine("Sending Whatsapp message");
    }
}
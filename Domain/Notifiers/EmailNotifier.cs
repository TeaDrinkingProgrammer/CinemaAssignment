using Domain.Observer;
using Domain.OrderState;

namespace Domain.Notifications;

public class EmailNotifier : IObserver
{
    private Order Order;
    public EmailNotifier(Order order)
    {
        Order = order;
        Order.AddObserver(this);
    }
    public void update()
    {
        Console.WriteLine("Sending email");
    }
}
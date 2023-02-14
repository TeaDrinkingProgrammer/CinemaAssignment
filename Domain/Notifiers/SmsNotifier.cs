using Domain.Observer;
using Domain.OrderState;

namespace Domain.Notifications;

public class SmsNotifier : IObserver
{
    private Order Order;
    public SmsNotifier(Order order)
    {
        Order = order;
        Order.AddObserver(this);
    }
    public void update()
    {
        Console.WriteLine("Sending SMS");
    }
}
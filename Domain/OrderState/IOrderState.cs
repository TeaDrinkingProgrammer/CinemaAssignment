namespace Domain.OrderState;

public interface IOrderState
{
    public void SubmitChanges();
    public void Cancel();
    public void Pay();
    public void Provision();
    public void AddSeatReservation(MovieTicket movieTicket);
}
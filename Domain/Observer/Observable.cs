namespace Domain.Observer;

public abstract class Observable
{
    public List<IObserver> Observers = new();

    public void AddObserver(IObserver observable)
    {
        Observers.Add(observable);
    }

    public void RemoveObserver(IObserver observable)
    {
        Observers.Remove(observable);
    }

    public void NotifyObservers()
    {
        Observers.ForEach(observer => observer.update());
    }
}
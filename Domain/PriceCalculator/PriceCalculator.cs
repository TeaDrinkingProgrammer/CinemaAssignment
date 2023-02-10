namespace Domain;
public abstract class PriceCalculator
{
    protected bool isPremium;
    protected decimal basePrice;
    protected DateTime showingDate;

    protected PriceCalculator(bool isPremium)
    {
        this.isPremium = isPremium;
    }

    abstract public decimal GetPrice(decimal basePrice);
}

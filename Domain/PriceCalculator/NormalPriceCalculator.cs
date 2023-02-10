namespace Domain;
public class NormalPriceCalculator : PriceCalculator
{
    public NormalPriceCalculator(bool isPremium) 
    : base(isPremium) 
{
}
    override public decimal GetPrice(decimal basePrice){
        if (this.isPremium) {
            return basePrice + 3;
        }
        return basePrice;
    }
}

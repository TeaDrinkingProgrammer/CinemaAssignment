namespace Domain;
public class StudentPriceCalculator : PriceCalculator
{
    public StudentPriceCalculator(bool isPremium) 
    : base(isPremium) 
{
}
    override public decimal GetPrice(decimal basePrice){
        if (this.isPremium) {
            return basePrice + 2;
        }
        return basePrice;
    }
}

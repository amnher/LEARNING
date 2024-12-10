VendingMachine vendingMachine = new AnimalFeedVendingMachine();
Console.WriteLine(vendingMachine.Dispense(2.00M));


class VendingMachine
{
    public virtual string Item { get; }
    protected virtual bool CheckAmount(decimal money)
    {
        return false;
    }
    public string Dispense(decimal money)
    {
        if (CheckAmount(money)) return Item;
        else return "Please enter the right amount";
    }
}

class AnimalFeedVendingMachine : VendingMachine
{
    public override string Item
    {
        get { return "a handful of animal feed"; }
    }
    protected override bool CheckAmount(decimal money)
    {
        return money >= 1.25M;
    }
}
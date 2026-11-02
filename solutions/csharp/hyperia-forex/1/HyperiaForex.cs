public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    //equality operators
    public static bool operator ==(CurrencyAmount structA, CurrencyAmount structB) =>
	structA.currency == structB.currency ?
            structA.amount == structB.amount :
	    throw new ArgumentException();	

    public static bool operator !=(CurrencyAmount structA, CurrencyAmount structB) =>
	!(structA == structB);

    public override bool Equals(object? obj)
    {
	if(obj is CurrencyAmount otherAmount)
	    return otherAmount.currency == currency ?
		otherAmount.amount == amount :
		throw new ArgumentException();
	else
	    return false;
    }

    public override int GetHashCode() => HashCode.Combine(amount, currency);
	
    //comparison operators
    public static bool operator >(CurrencyAmount structA, CurrencyAmount structB) =>
	structA.currency == structB.currency ?
            structA.amount > structB.amount :
	    throw new ArgumentException();

    public static bool operator <(CurrencyAmount structA, CurrencyAmount structB) =>
	structA.currency == structB.currency ?
            structA.amount < structB.amount :
	    throw new ArgumentException();

    //arithmetic operators
    public static CurrencyAmount operator +(CurrencyAmount structA, CurrencyAmount structB) =>
	structA.currency == structB.currency ?
	    new CurrencyAmount(structA.amount + structB.amount, structA.currency) :
	    throw new ArgumentException();

    public static CurrencyAmount operator -(CurrencyAmount structA, CurrencyAmount structB) =>
	structA.currency == structB.currency ?
	    new CurrencyAmount(structA.amount - structB.amount, structA.currency) :
	    throw new ArgumentException();
    
    public static CurrencyAmount operator *(CurrencyAmount structA, CurrencyAmount structB) =>
	structA.currency == structB.currency ?
	    new CurrencyAmount(structA.amount * structB.amount, structA.currency) :
	    throw new ArgumentException();
    
    public static CurrencyAmount operator /(CurrencyAmount structA, CurrencyAmount structB) =>
	(structA.currency == structB.currency && structB.amount != 0) ?
	    new CurrencyAmount(structA.amount / structB.amount, structA.currency) :
	    throw new ArgumentException();
    
    //conversion operators
    public static explicit operator double(CurrencyAmount currencyAmount) =>
	(double)currencyAmount.amount;

    public static implicit operator decimal(CurrencyAmount currencyAmount) =>
	(decimal)currencyAmount.amount;	
}

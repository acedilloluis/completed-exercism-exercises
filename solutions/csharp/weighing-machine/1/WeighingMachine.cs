class WeighingMachine
{
    // TODO: define the 'Precision' property
    public int Precision { get; }

    // TODO: define the 'Weight' property
    private double _weight;
    public double Weight
    {
        get { return _weight; }
        set 
        { 
            if (value >= 0)
                _weight = value;
            else
                throw new ArgumentOutOfRangeException();
        }
    }

    // TODO: define the 'TareAdjustment' property
    public double TareAdjustment { get; set; } = 5;

    // TODO: define the 'DisplayWeight' property
    public string DisplayWeight
    {
        get { return ($"{(this.Weight - this.TareAdjustment).ToString($"F{this.Precision}")} kg"); }
    }

    public WeighingMachine(int precision) =>
        this.Precision = precision;
}

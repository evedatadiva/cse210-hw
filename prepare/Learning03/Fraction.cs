using System;

public class Fraction
{
    private int numerator;
    private int denominator;

    
    public Fraction()
    {
        this.numerator = 1;
        this.denominator = 1;
    }

    public Fraction(int numerator)
    {
        this.numerator = numerator;
        this.denominator = 1;
    }

    public Fraction(int numerator, int denominator)
    {
        this.numerator = numerator;
        if (denominator != 0)
            this.denominator = denominator;
        else
            throw new ArgumentException("Denominator cannot be zero.");
    }

    
    public string GetFractionString()
    {
        return $"{numerator}/{denominator}";
    }

    
    public double GetDecimalValue()
    {
        return (double)numerator / denominator;
    }
}
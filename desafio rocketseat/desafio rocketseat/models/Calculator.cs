namespace desafio_rocketseat.models;

public class Calculator
{
    public double Value1 { get; set; }
    public double Value2 { get; set; }

    
    public Calculator(double value1, double value2)
    {
        Value1 = value1;
        Value2 = value2;
    }
    

    public double Sum()
    {
        return Value1 + Value2;
    }
    
    public double Subtraction()
    {
        return Value1 - Value2;
    }
    
    public double Multiplication()
    {
        return Value1 * Value2;
    }

    public double Division()
    {
        if (Value2 == 0)
            return 0;
        
        return Value1 / Value2;
    }
    
    public double Average(){
        return (Value1 + Value2) / 2.0;
    }
}
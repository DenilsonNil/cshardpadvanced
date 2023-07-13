using System;

/**
 * A vantagem dos delegates genéricos é não precisar criar um delegate como uma classe separada.**/

class DelegateGenerico
{
    void TestDelegateGenerico()
    {

        Temperature t = new Temperature();

        //Definição dos delegates genéricose referenciar os métodos. Delegate do tipo Func podem referenciar métodos que tenham retorno.
        Func<double, double> convertToCelsius = t.ToCelsius;
        Func<double, double> convertToFahrenheit = t.ToFahrenheit;

        double celsius = convertToCelsius(90);
        double fahrenheit = convertToFahrenheit(25);

        Console.WriteLine(celsius);
        Console.WriteLine(fahrenheit);

        //Delegate genérico do tipo Action só pode receber métodos que retornem void
        Action<double> printCelsius = t.PrintCelsius;
        Action<double> printFahrenheit = t.PrintFahrenheit;

        printCelsius(80);
        printFahrenheit(20);
    }
}

class Temperature
{
    //1 - Definir os métodos que irão ser referenciados pelo delegate genérico
    public double ToFahrenheit(double celsius)
    {
        return (celsius * 9 / 5) + 32;
    }

    public double ToCelsius(double fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }

    public void PrintFahrenheit(double celsius)
    {
        Console.WriteLine(ToFahrenheit(celsius));
    }

    public void PrintCelsius(double fahrenheit)
    {
        Console.WriteLine(ToCelsius(fahrenheit));
    }
}

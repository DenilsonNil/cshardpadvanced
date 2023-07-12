using System;

class Casting
{
    public void TestCasting()
    {
        LetraAlfabeto la = new LetraAlfabeto('B');

        //Usabilidade. Armarzenando em uma variável do tipo char uma variável do tipo Alfabeto
        char c = (char)la;
        Console.WriteLine(c);

        LetraAlfabeto la2 = 'X';
    }
}

class LetraAlfabeto
{
    char caractere;

    public LetraAlfabeto(char caractere)
    {
        this.caractere = char.ToUpper(caractere);
    }

    public static explicit operator char(LetraAlfabeto la)
    {
        return la.caractere;
    }

    //Casting para converter um objeto de LetraAlfabeto para um char
    public static implicit operator LetraAlfabeto(char c)
    {
        return new LetraAlfabeto(c);
    }
}

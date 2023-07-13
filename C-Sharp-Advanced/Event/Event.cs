using System;
using System.Threading;

/**
 * Event é a maneira recomendada pela Microsoft de fazer callbacks
 * **/

//1 - Criar um delegate que aponte para um método que retorne void e receba um object e um EventArgs
public delegate void NumberHandler(object sender, NumberEventArgs args);

class Event
{
    void TestEvent()
    {
        NumberGenerator g = new NumberGenerator();

        //3 - Relacionando o método g_OnGenerated com o event
        g.myEvent += g_OnGenerated;
        g.Start();
    }

    //6 - Método é invocado quando o event é executado (passo 5)
    static void g_OnGenerated(object sender, NumberEventArgs args)
    {
        Console.WriteLine("Número gerado: " + args.Number);
    }
}



class NumberGenerator
{
    //2 - Obtendo uma instancia do event
    public event NumberHandler myEvent;

    Random r = new Random();

    
    public void Start()
    {
        while (true)
        {
            int n = r.Next(100);
           
            if (myEvent != null)
            {
                // 4 - Criando uma instancia de um objeto EventArgs
                NumberEventArgs args = new NumberEventArgs() { Number = n };

                // 5 - Event sendo executado.
                myEvent(this, args);
            }

            Thread.Sleep(1000);
        }
    }
}


public class NumberEventArgs : EventArgs
{
    public int Number { get; set; }
}
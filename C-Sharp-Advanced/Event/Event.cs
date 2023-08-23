using System;
using System.Threading;

/**
 * Events representam eventos.
 * Um objeto pode avisar a respeito de eventos que ocorrerem com ele.
 * Outros objetos que registram interesse no evento são notificados quando o evento ocorre.
 * Events precisam de delegates para funcionar.
 * É possível utilizar apenas delegates para obter o mesmo resultado porém o codigo fica mais complexo, 
 * ou seja, é mais interessante do que usar delegate.
 * **/

/**1 - Criar um delegate que aponte para um método que retorne void e receba um object e um EventArgs
 * O sender é o objeto que dispara o evento e o NumberEventArgs é uma classe que representa o evento e herda de EventArgs
 * **/
public delegate void NumberHandler(object sender, NumberEventArgs args);

//2 - Criar uma classe que representa o evento. Esta classe possui as caracteristicas do evento.
public class NumberEventArgs : EventArgs
{
    public int Number { get; set; }
}

//Classe qualquer que quer avisar sobre um evento ocorrido.
class NumberGenerator
{
    /**3 - Obtendo uma instancia do event usando o delegate. A sintaxe é modifcador de visibilidade + a palavra chave event, o tipo dele que é o delegate e o nome
     * O evento é a minha classe notificando alguém em algum momento.
     * **/
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

                /** 5 - Event sendo disparado, ou seja, quando eu executo eu estou avisando quem está interessado, ou seja, toda vez que acontecer tal coisa eu disparo um Evento passando eu mesmo
                 * e um EventArgs que representa o Evento em si.
                 * 
                 * **/
                myEvent(this, args);
            }

            Thread.Sleep(1000);
        }
    }
}

//Usando o Event
class Event
{

    //6 - Criar um método que possa ser apontado pelo evento e será invocado quando o event é executado, A assinatura precisa ser a mesma assinatura do delegate.
    static void g_OnGenerated(object sender, NumberEventArgs args)
    {
        Console.WriteLine("Número gerado: " + args.Number);
    }

    void TestEvent()
    {
        NumberGenerator g = new NumberGenerator();

        //7 - Relacionando o método g_OnGenerated com o event, 
        g.myEvent += g_OnGenerated;
        g.Start();
    }

    
}







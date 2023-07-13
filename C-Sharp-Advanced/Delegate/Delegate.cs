using System;
using System.Threading;


/**Delegate é a forma que o C# tem de prover uma forma de fazer callback**/

//1 - Criar o delegate com um tipo de retorno e parametro. O delegate pode apontar para métodos que contenham essa assinatura
delegate void SemaforoHandler(Cor cor);

class Delegate
{
    void TestDelegate()
    {
        Semaforo s = new Semaforo();

        for (int i = 1; i <= 3; i++)
        {
            Carro c = new Carro(i);

            //4 - Fazer o delegate receber o método da classe carro para que toda vez que o callback for chamado esse método seja invocado.
            s.AdicionarCallback(c.SemaforoAlterado);
        }

        s.Iniciar();
    }
}

enum Cor
{
    VERDE,
    VERMELHO,
    AMARELO
}



class Semaforo
{
    Cor cor = Cor.VERMELHO;

    //3 - Variável do tipo do delegate
    SemaforoHandler callbacks;

    public void Iniciar()
    {
        while (true)
        {
            if (cor == Cor.VERMELHO)
            {
                cor = Cor.VERDE;
            }
            else if (cor == Cor.VERDE)
            {
                cor = Cor.AMARELO;
            }
            else if (cor == Cor.AMARELO)
            {
                cor = Cor.VERMELHO;
            }

            Console.WriteLine("Semáforo mudou para " + cor);
            //5 - Invocar o callback e avisar os métodos que ele referencia.
            callbacks(cor);
            Thread.Sleep(2000);
        }
    }

    public void AdicionarCallback(SemaforoHandler handler)
    {
        callbacks += handler;
    }
}

class Carro
{
    int id;

    public Carro(int id)
    {
        this.id = id;
    }

    //2 - Criar um método que possa ser referenciado pelo delegate criado.
    public void SemaforoAlterado(Cor cor)
    {
        Console.WriteLine("Carro {0:d} notificado: cor {1}", id, cor);
    }
}
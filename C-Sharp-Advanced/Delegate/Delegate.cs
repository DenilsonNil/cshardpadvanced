using System;
using System.Threading;


/**Delegate é a forma que o C# tem de de fazer callback**/

/**1 - Criar o delegate com um tipo de retorno e parametro. O delegate é um tipo de dado, não precisa especificamente ser criado dentro de uma classe,
 *e 
 * pode apontar para métodos que contenham essa assinatura, ou seja, o metodos que retornam void  e recebem uma Cor como parametro 
 * podem ser chamados por este delegate.
 * **/
delegate void SemaforoHandler(Cor cor);

class Delegate
{
    void TestDelegate()
    {
        Semaforo s = new Semaforo();

        for (int i = 1; i <= 3; i++)
        {
            Carro c = new Carro(i);

            //5 - Fazer o delegate receber o método da classe carro para que toda vez que o callback for chamado esse método seja invocado.
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

    /** 3 - Variável do tipo do delegate. O delegate é um tipo de dado e precisamos de uma referencia do delegate para que possamos
     * chamar o método SemaforoAlterado.
     * **/
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
    /** 4- Em algum momento é necessario fazer com que o delegate passe a ser o observer.
     * Neste caso estamos recebendo como parametro um objeto do tipo do delegate, ou seja, qualquer metodo que 
     * retorne void e receba uma cor como parametro.
     * **/ 
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
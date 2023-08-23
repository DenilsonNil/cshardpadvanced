using System;
namespace C_Sharp_Advanced.Event
{

    /**
	 * Neste caso não é necessario ter um delegate. 
	 * Basta ter um Evento, ou seja uma classe que herde de EventArgs **/


    //1 - Criar um objeto EventArgs
    class AcordouEventArgs : EventArgs
    {

    }


    class EventGeneric
	{
		public void TesteEventGeneric()
		{
			Pessoa p = new Pessoa();

			//5 - Associando um método com o Evento
			p.AcordouEvent += PessoaAcordou;
		}

		public void PessoaAcordou(object sender, EventArgs args)
		{
			//Aqui eu tenho acessso ao objeto args que na verdade é o meu objeto EventArgs que está dentro do Evento.
		}
    }

	

	class Pessoa
	{
		//2 - Criar o event genérico com um objeto do tipo EventArgs, ou seja, aqui eu passo parametrizado o tipo de EventArgs.
		//Aqui segue a mesma logica de Event, ou seja, a classe Pessoa está disparando um Evento.
		public event EventHandler<AcordouEventArgs> AcordouEvent;

		public void Acordar()
		{
			DateTime hora = DateTime.Now;

			if(AcordouEvent != null)
			{
				//4 - Disparar o Event passando um objeto disparador e um EventArgs.
				AcordouEvent(this, new AcordouEventArgs());
			}
		}
	}

	
}


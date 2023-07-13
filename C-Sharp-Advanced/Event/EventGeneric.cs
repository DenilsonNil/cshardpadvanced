using System;
namespace C_Sharp_Advanced.Event
{
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

		}
    }

	//1 - Criar um objeto EventArgs
	class AcordouEventArgs : EventArgs
	{
		
	}

	class Pessoa
	{
		//2 - Criar o event genérico com um objeto do tipo EventArgs
		public event EventHandler<AcordouEventArgs> AcordouEvent;

		public void Acordar()
		{
			DateTime hora = DateTime.Now;

			if(AcordouEvent != null)
			{
				//4 - Disparar o Event passando um objeto e um EventArgs.
				AcordouEvent(this, new AcordouEventArgs());
			}
		}
	}

	
}


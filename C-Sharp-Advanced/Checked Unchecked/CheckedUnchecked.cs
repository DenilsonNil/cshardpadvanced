using System;
namespace C_Sharp_Advanced.CheckedUnchecked
{
	public class CheckedUnchecked
	{
		public CheckedUnchecked()
		{
		}


		void TesteCheckedUnchecked()
		{
			/**
			 * Overflow é quando estoura a capacidade de armarzenamento de um tipo de dado.
			 * O short é um tipo de dado que não consegue armarzenar a soma dos dois números, s3 fica com valor inconsistente
			 * 
			 * A aplicação executa normalmente sem erros, isso pode ser um problema, já que se isso ocorrer, valores de cálculos podem ser
			 * inconsistentes.
			 */


			short s1 = 25000;
			short s2 = 2000;
			short s3 = (short) (s1 + s2);

			Console.WriteLine(s3);


			/*Através do checked a aplicação pode me avisar que um overflow ocorreu
			 * O blocl checked é analisado durante a execução e se um overflow ocorrer uma Exception é lançada
			 * **/

			checked
			{
                short s4 = 25000;
                short s5 = 2000;
                short s6 = (short)(s4 + s5);

                Console.WriteLine(s3);
            }

			/**Habilitar a chacagem de checked para o projeto todo
			 Clicar com o botão direito do mouse sobre o projeto sem precisar declarar bloco checked
			 Esta opção pode causar problemas de performace, usar somente durante o desenvolvimento.
			 Habilite a opção check for arithmetic overflow/underflow*/


			/*Caso deseje desabilitar para alguma parte do código envolva esta parte com unchecked, 
			 * desta forma estou aceitando que o overflow pode ocorrer mesmo com a configuração de overflow ativada*/

			unchecked
			{
				//code
			}
		}
	}
}


using AgendaDeTarefas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDeTarefas.Tela
{
    public class TelaInicial
    {

        protected void MontarCabecalho(string configTela, params object[] colunas)
        {
            Console.WriteLine();
            Console.WriteLine(configTela, colunas);
            Console.WriteLine("-----------------------------------------------------------");
        }

        protected void LimparTela()
        {
            Console.ResetColor();
            Console.Clear();
        }

        protected string MensagemSucesso(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            return mensagem;
        }

        protected string MensagemErro(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            return mensagem;
        }

        protected string FormataData(DateTime data)
        {
            string recebeData = data.ToString("dd/MM/yyyy");

            return recebeData;
        }
    }
}

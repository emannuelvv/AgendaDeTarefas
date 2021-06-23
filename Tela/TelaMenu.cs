using AgendaDeTarefas.Controller;
using AgendaDeTarefas.Tela;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDeTarefas.Tela
{
    public class TelaMenu : TelaInicial
    {
        private readonly ControladorContato ControladorContato;
        private readonly ControladorTarefa ControladorTarefa;
        private readonly TelaTarefa telaTarefa;
        private readonly TelaContato telaContato;

        public TelaMenu()
        {
            ControladorContato = new ControladorContato();
            ControladorTarefa = new ControladorTarefa();

            telaTarefa = new TelaTarefa(ControladorTarefa);
            telaContato = new TelaContato(ControladorContato);

        }
        public void RetornaMenu()
        {

            string opcao;
            do
            {
                Console.WriteLine("AGENDA 2.0");
                Console.WriteLine();
                Console.WriteLine("Digite 1 para o Cadastro de Tarefas");
                Console.WriteLine("Digite 2 para o Cadastro de Contatos");
                Console.WriteLine("Digite S para Sair");
                Console.WriteLine();
                Console.Write("Opção: ");

                opcao = Console.ReadLine();



                if (opcao == "1")
                {
                    MenuTarefas();

                }
                else if (opcao == "2")
                {
                    MenuContatos();
                }

            } while (OpcaoInvalida(opcao));
        }

        private void MenuTarefas()
        {
            LimparTela();
            string opcao;
            Console.WriteLine("Digite 1 para o Cadastro de Tarefas");
            Console.WriteLine("Digite 2 para Listar Tarefas");
            Console.WriteLine("Digite 3 para Editar Tarefas");
            Console.WriteLine("Digite 4 para Excluir Tarefas");

            Console.WriteLine("Digite S para Sair");
            Console.WriteLine();
            Console.Write("Opção: ");

            opcao = Console.ReadLine();

            if (opcao == "1")
                telaTarefa.InserirTarefa();

            if (opcao == "2")
                telaTarefa.Listar();

            if (opcao == "3")
                telaTarefa.EditarTarefa();

            if (opcao == "4")
                telaTarefa.ExcluirTarefa();

            else if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                LimparTela();
            RetornaMenu();

        }

        private void MenuContatos()
        {
            LimparTela();
            string opcao;

            Console.WriteLine("Digite 1 para o Cadastro de Contatos");
            Console.WriteLine("Digite 2 para Listar Contatos");
            Console.WriteLine("Digite 3 para Editar Contatos");
            Console.WriteLine("Digite 4 para Excluir Contatos");

            Console.WriteLine("Digite S para Sair");
            Console.WriteLine();
            Console.Write("Opção: ");

            opcao = Console.ReadLine();

            if (opcao == "1")
                telaContato.InserirContato();

            if (opcao == "2")
                telaContato.ListarContatos();

            if (opcao == "3")
                telaContato.EditarContato();

            if (opcao == "4")
                telaContato.ExcluirContato();

            else if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
            LimparTela();
            RetornaMenu();

        }

        private bool OpcaoInvalida(string opcao)
        {
            if (opcao != "1" && opcao != "2" && opcao != "S" && opcao != "s")
            {
                Console.WriteLine(MensagemErro("Tecla inválida, tente novamente"));
                Console.ReadLine();
                LimparTela();
                RetornaMenu();
                return false;
            }
            else
                return true;
        }

        
    }
}

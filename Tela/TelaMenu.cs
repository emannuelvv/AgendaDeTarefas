using AgendaDeTarefas.Controladores;

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
        private readonly ControladorContato controladorContato;
        private readonly ControladorTarefa controladorTarefa;
        private readonly ControladorCompromisso controladorCompromisso;

        private readonly TelaTarefa telaTarefa;
        private readonly TelaContato telaContato;
        private readonly TelaCompromisso telaCompromisso;

        public TelaMenu()
        {
            controladorContato = new ControladorContato();
            controladorTarefa = new ControladorTarefa();
            controladorCompromisso = new ControladorCompromisso();

            telaTarefa = new TelaTarefa(controladorTarefa);
            telaContato = new TelaContato(controladorContato);
            telaCompromisso = new TelaCompromisso(controladorCompromisso, telaContato);

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
                Console.WriteLine("Digite 3 para o Cadastro de Compromissos");
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
                else if (opcao == "3")
                {
                    MenuCompromissos();
                }

            } while (OpcaoInvalidaMenu(opcao));
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
        private bool OpcaoInvalida(string opcao)
        {
            if (opcao != "1" && opcao != "2" && opcao != "3" && opcao != "S" && opcao != "s")
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

        private bool OpcaoInvalidaMenu(string opcao)
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


        private void MenuCompromissos()
        {
            LimparTela();
            string opcao;

            Console.WriteLine("Digite 1 para o Cadastro de Compromissos");
            Console.WriteLine("Digite 2 para Listar Compromissos");
            Console.WriteLine("Digite 3 para Editar Compromissos");
            Console.WriteLine("Digite 4 para Excluir Compromissos");

            Console.WriteLine("Digite S para Sair");
            Console.WriteLine();
            Console.Write("Opção: ");
            opcao = Console.ReadLine();

            if (opcao == "1")
                telaCompromisso.InserirCompromisso();

            if (opcao == "2")
                telaCompromisso.ListarCompromissos();

            if (opcao == "3")
                telaCompromisso.EditarCompromisso();

            if (opcao == "4")
                telaCompromisso.ExcluirCompromisso();

            else if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
            LimparTela();
            RetornaMenu();
        }

        

    }
}

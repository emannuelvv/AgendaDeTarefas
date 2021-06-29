
using AgendaDeTarefas.Model;
using AgendaDeTarefas.Tela;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaDeTarefas.Controladores;

namespace AgendaDeTarefas.Tela
{
    public class TelaTarefa : TelaInicial
    {
        private ControladorTarefa controladorTarefa;

        public TelaTarefa(ControladorTarefa ctrlTarefa)
        {
            controladorTarefa = ctrlTarefa;
        }

        public void InserirTarefa()
        {
            LimparTela();
            controladorTarefa.InserirTarefa(ObterInformacoes());
            Console.WriteLine(MensagemSucesso("Registrado com Sucesso"));
            LimparTela();

        }

        

        private Tarefa ObterInformacoes()
        {
            Console.Write("Informe o título da tarefa: ");
            string titulo = Console.ReadLine();

            DateTime dataCriacao = DateTime.Now;

            Console.Write("Informe a data de conclusao da tarefa: ");
            DateTime dataConclusao = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Informe o precentual da tarefa: ");
            int percentual = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Alta");
            Console.WriteLine("Normal");
            Console.WriteLine("Baixa");

            Console.Write("Informe a prioridade: ");
            string prioridade = Console.ReadLine();

            Tarefa tarefa = new Tarefa(titulo, dataCriacao, dataConclusao, percentual, prioridade);
            string resultadoValidacao = tarefa.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                return tarefa;
            }
            else
            {
                Console.WriteLine(resultadoValidacao);
                Console.ReadLine();
                LimparTela();
                ObterInformacoes();
            }
            return tarefa;
        }

        private Tarefa ObterInformacoesEdicao()
        {
            Console.Write("Informe o título da tarefa: ");
            string titulo = Console.ReadLine();

            Console.Write("Informe a data de conclusao da tarefa: ");
            DateTime dataConclusao = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Informe o precentual da tarefa: ");
            int percentual = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Alta");
            Console.WriteLine("Normal");
            Console.WriteLine("Baixa");

            Console.Write("Informe a prioridade: ");
            string prioridade = Console.ReadLine();

            Tarefa tarefa = new Tarefa(titulo, dataConclusao, percentual, prioridade);
            string resultadoValidacao = tarefa.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                return tarefa;
            }
            else
            {
                Console.WriteLine(resultadoValidacao);
                Console.ReadLine();
                ObterInformacoes();
            }
            return tarefa;
        }

        public void Listar()
        {
            Console.Clear();
            Console.WriteLine("1 - Registros pendentes");
            Console.WriteLine("2 - Registros finalizados");
            Console.WriteLine("3 - Todos os registros");

            Console.Write("Informe qual tela deseja acessar: ");
            string opcao = Console.ReadLine();

            if (opcao == "1")
            {
                ListarPendentes();
                LimparTela();

            }
            else if (opcao == "2")
            {
                ListarFinalizadas();
                LimparTela();
            }
            else if (opcao == "3")
            {
                ListarTodos();
                LimparTela();
            }
            else
            {
                Console.WriteLine("Opção inválida, tente novamente");
                Console.ReadLine();
                Console.Clear();
                Listar();
            }
        }

        private void ListarPendentes()
        {
            string configuracaoColunasTabela = "{0,-5}|{1,-20}|{2,-15}|{3,-15}|{4,-15}";
            MontarCabecalho(configuracaoColunasTabela, "ID", "TITULO", "DATA CONCLUSAO", "PERCENTUAL", "PRIORIDADE");

            List<Tarefa> tarefas = controladorTarefa.ListarTarefasPendentes();
            foreach (Tarefa tarefa in tarefas)
            {
                string recebeDataSemHoras = FormataData(tarefa.DataDeConclusao);
                Console.WriteLine(configuracaoColunasTabela, tarefa.Id, tarefa.Titulo, recebeDataSemHoras, tarefa.Percentual, tarefa.Prioridade);
            }

            Console.ReadLine();
        }

        private void ListarFinalizadas()
        {

            string configuracaoColunasTabela = "{0,-5}|{1,-20}|{2,-15}|{3,-15}|{4,-15}";
            MontarCabecalho(configuracaoColunasTabela, "ID", "TITULO", "DATA CONCLUSAO", "PERCENTUAL", "PRIORIDADE");

            List<Tarefa> tarefas = controladorTarefa.ListarTarefasFinalizadas();
            foreach (Tarefa tarefa in tarefas)
            {
                string recebeDataSemHoras = FormataData(tarefa.DataDeConclusao);
                Console.WriteLine(configuracaoColunasTabela, tarefa.Id, tarefa.Titulo, recebeDataSemHoras, tarefa.Percentual, tarefa.Prioridade);
            }

            Console.ReadLine();
        }

        private void ListarTodos()
        {
            string configuracaoColunasTabela = "{0,-5}|{1,-20}|{2,-15}|{3,-15}|{4,-15}";
            MontarCabecalho(configuracaoColunasTabela, "ID", "TITULO", "DATA CONCLUSAO", "PERCENTUAL", "PRIORIDADE");


            List<Tarefa> tarefas = controladorTarefa.ListarTodasAsTarefas();
            foreach (Tarefa tarefa in tarefas)
            {
                string recebeDataSemHoras = FormataData(tarefa.DataDeConclusao);
                Console.WriteLine(configuracaoColunasTabela, tarefa.Id, tarefa.Titulo, recebeDataSemHoras, tarefa.Percentual, tarefa.Prioridade);
            }


        }

        public void EditarTarefa()
        {
            LimparTela();

            ListarPendentes();

            Console.Write("Informe o Id da tarefa que deseja editar: ");
            int idParaEdicao = Convert.ToInt32(Console.ReadLine());

            controladorTarefa.EditarTarefa(idParaEdicao, ObterInformacoesEdicao());
            Console.WriteLine(MensagemSucesso("Editado com sucesso"));
            LimparTela();

        }

        public void ExcluirTarefa()
        {
            LimparTela();

            ListarPendentes();

            Console.Write("Informe o Id da tarefa que deseja exluir: ");
            int idParaExclusao = Convert.ToInt32(Console.ReadLine());

            controladorTarefa.ExcluirTarefa(idParaExclusao);
            Console.WriteLine(MensagemSucesso("Excluido com sucesso"));

            LimparTela();


        }

    }
}

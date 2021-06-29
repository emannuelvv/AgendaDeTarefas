using AgendaDeTarefas.Model;
using AgendaDeTarefas.Conexao;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDeTarefas.Controladores
{
    public class ControladorTarefa : Conexao
    {
        private readonly SqlAgenda sqlagenda;
        private Conexao conexao;
        public ControladorTarefa()
        {
            conexao = new Conexao();
            sqlagenda = new SqlAgenda();
        }

        public void InserirTarefa(Tarefa tarefa)
        {

            SqlCommand comandoInsercao = new SqlCommand();
            comandoInsercao.Connection = conexao.CriarConexao();
            string recebeComandoInsercao = sqlagenda.SqlInsercaoTarefa();

            comandoInsercao.CommandText = recebeComandoInsercao;
            comandoInsercao.Parameters.AddWithValue("Titulo", tarefa.Titulo);
            comandoInsercao.Parameters.AddWithValue("DataDeCriacao", tarefa.DataDeCriacao);
            comandoInsercao.Parameters.AddWithValue("DataDeConclusao", tarefa.DataDeConclusao);
            comandoInsercao.Parameters.AddWithValue("Percentual", tarefa.Percentual);
            comandoInsercao.Parameters.AddWithValue("Prioridade", tarefa.Prioridade);

            object id = comandoInsercao.ExecuteScalar();
            tarefa.Id = Convert.ToInt32(id);

            

        }

        public List<Tarefa> ListarTarefasPendentes()
        {

            SqlCommand comandoBusca = new SqlCommand();
            comandoBusca.Connection = conexao.CriarConexao();
            string recebeConsultaTarefasPendentes = sqlagenda.SqlTarefasPendentes();

            comandoBusca.CommandText = recebeConsultaTarefasPendentes;
            SqlDataReader leitorConsultas = comandoBusca.ExecuteReader();

            List<Tarefa> tarefas = new List<Tarefa>();
            PopulandoListaTarefas(leitorConsultas, tarefas);

           
            return tarefas;
        }

        public List<Tarefa> ListarTarefasFinalizadas()
        {

            SqlCommand comandoBusca = new SqlCommand();
            comandoBusca.Connection = conexao.CriarConexao();
            string recebeConsultaTarefasFinalizadass = sqlagenda.SqlTarefasFinalizadas();

            comandoBusca.CommandText = recebeConsultaTarefasFinalizadass;
            SqlDataReader leitorConsultas = comandoBusca.ExecuteReader();

            List<Tarefa> tarefas = new List<Tarefa>();
            PopulandoListaTarefas(leitorConsultas, tarefas);

            
            return tarefas;
        }

        public List<Tarefa> ListarTodasAsTarefas()
        {

            SqlCommand comandoBusca = new SqlCommand();
            comandoBusca.Connection = conexao.CriarConexao();
            string recebeConsultaTodasAsTarefas = sqlagenda.SqlTodasAsTarefas();

            comandoBusca.CommandText = recebeConsultaTodasAsTarefas;
            SqlDataReader leitorConsultas = comandoBusca.ExecuteReader();

            List<Tarefa> tarefas = new List<Tarefa>();
            PopulandoListaTarefas(leitorConsultas, tarefas);

            
            return tarefas;
        }

        private static void PopulandoListaTarefas(SqlDataReader leitorConsultas, List<Tarefa> tarefas)
        {
            while (leitorConsultas.Read())
            {
                int id = Convert.ToInt32(leitorConsultas["Id"]);
                string titulo = Convert.ToString(leitorConsultas["Titulo"]);
                DateTime dataConclusao = Convert.ToDateTime(leitorConsultas["DataDeConclusao"]);
                int percentual = Convert.ToInt32(leitorConsultas["Percentual"]);
                string prioridade = Convert.ToString(leitorConsultas["Prioridade"]);

                Tarefa tarefa = new Tarefa(id, titulo, dataConclusao, percentual, prioridade);
                tarefas.Add(tarefa);

            }
        }

        public void EditarTarefa(int id, Tarefa tarefa)
        {

            SqlCommand comandoEdicao = new SqlCommand();
            comandoEdicao.Connection = conexao.CriarConexao();
            string recebeComandoEdicao = sqlagenda.SqlEdicaoTarefa();

            comandoEdicao.CommandText = recebeComandoEdicao;
            comandoEdicao.Parameters.AddWithValue("Id", id);
            comandoEdicao.Parameters.AddWithValue("Titulo", tarefa.Titulo);
            comandoEdicao.Parameters.AddWithValue("DataDeConclusao", tarefa.DataDeConclusao);
            comandoEdicao.Parameters.AddWithValue("Percentual", tarefa.Percentual);
            comandoEdicao.Parameters.AddWithValue("Prioridade", tarefa.Prioridade);

            comandoEdicao.ExecuteNonQuery();
            
        }

        public void ExcluirTarefa(int id)
        {

            SqlCommand comandoExclusao = new SqlCommand();
            comandoExclusao.Connection = conexao.CriarConexao();
            string recebeComandoExclusao = sqlagenda.SqlExclusaoTarefa();

            comandoExclusao.CommandText = recebeComandoExclusao;
            comandoExclusao.Parameters.AddWithValue("Id", id);

            comandoExclusao.ExecuteNonQuery();
           
        }
    }
}

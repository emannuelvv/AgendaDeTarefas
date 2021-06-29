using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaDeTarefas.Model;
using System.Data.SqlClient;
using AgendaDeTarefas.Conexao;
using AgendaDeTarefas.Tela;


namespace AgendaDeTarefas.Controladores
{
    public class ControladorCompromisso 
    {
        private readonly SqlCompromisso sqlCompromisso;
        private Conexao conexao;

        public ControladorCompromisso()
        {
            conexao = new Conexao();
            sqlCompromisso = new SqlCompromisso();
        }

        public void InserirCompromisso(Compromisso compromisso)
        {
            SqlCommand comandoInsercao = new SqlCommand();
            comandoInsercao.Connection = conexao.CriarConexao();
            string recebeComandoInsercao = sqlCompromisso.SqlInsercaoCompromisso();

            comandoInsercao.CommandText = recebeComandoInsercao;
            comandoInsercao.Parameters.AddWithValue("Assunto", compromisso.Assunto);
            comandoInsercao.Parameters.AddWithValue("Local", compromisso.Local);
            comandoInsercao.Parameters.AddWithValue("Data", compromisso.Data);
            comandoInsercao.Parameters.AddWithValue("HoraInicio", compromisso.HoraInicio);
            comandoInsercao.Parameters.AddWithValue("HoraTermino", compromisso.HoraTermino);
            comandoInsercao.Parameters.AddWithValue("IdContato", compromisso.IdContato);

            object id = comandoInsercao.ExecuteScalar();
            compromisso.Id = Convert.ToInt32(id);

            conexao.FecharConexao();
        }

        public void EditarCompromisso(int id, Compromisso compromisso)
            {
                SqlCommand comandoEdicao = new SqlCommand();
                comandoEdicao.Connection = conexao.CriarConexao();
                string recebeComandoEdicao = sqlCompromisso.SqlInsercaoCompromisso();


                comandoEdicao.Parameters.AddWithValue("Assunto", compromisso.Assunto);
                comandoEdicao.Parameters.AddWithValue("Local", compromisso.Local);
                comandoEdicao.Parameters.AddWithValue("Data", compromisso.Data);
                comandoEdicao.Parameters.AddWithValue("HoraInicio", compromisso.HoraInicio);
                comandoEdicao.Parameters.AddWithValue("HoraTermino", compromisso.HoraTermino);
                comandoEdicao.Parameters.AddWithValue("IdContato", compromisso.IdContato);

                comandoEdicao.CommandText = recebeComandoEdicao;
                comandoEdicao.Parameters.AddWithValue("Id", id);

                comandoEdicao.ExecuteNonQuery();
                conexao.FecharConexao();
        
       }

            public void ExcluirCompromisso(int id)
            {
                SqlCommand comandoExclusao = new SqlCommand();
                comandoExclusao.Connection = conexao.CriarConexao();
                string recebeComandoExclusao = sqlCompromisso.SqlExlusaoCompromisso();

                comandoExclusao.CommandText = recebeComandoExclusao;
                comandoExclusao.Parameters.AddWithValue("Id", id);

                comandoExclusao.ExecuteNonQuery();
                conexao.FecharConexao();
            }
            public List<Compromisso> ListarCompromissosFinalizados()
            {

                SqlCommand comandoBusca = new SqlCommand();
                comandoBusca.Connection = conexao.CriarConexao();
                string recebeConsultaCompromissosFinalizados = sqlCompromisso.SqlListarCompromissosFinalizados();

                comandoBusca.CommandText = recebeConsultaCompromissosFinalizados;
                SqlDataReader leitorConsultas = comandoBusca.ExecuteReader();

                List<Compromisso> compromissos = new List<Compromisso>();
                PopulandoListaCompromissos(leitorConsultas, compromissos);

                conexao.FecharConexao();
                return compromissos;
            }



            public List<Compromisso> ListarCompromissosDiarios()
            {

                SqlCommand comandoBusca = new SqlCommand();
                comandoBusca.Connection = conexao.CriarConexao();
                string recebeConsultaCompromissosFinalizados = sqlCompromisso.SqlListarCompromissosDiarios();

                comandoBusca.CommandText = recebeConsultaCompromissosFinalizados;
                SqlDataReader leitorConsultas = comandoBusca.ExecuteReader();

                List<Compromisso> compromissos = new List<Compromisso>();
                PopulandoListaCompromissos(leitorConsultas, compromissos);

                conexao.FecharConexao();
                return compromissos;
            }

            public List<Compromisso> ListarCompromissosSemanais()
            {

                SqlCommand comandoBusca = new SqlCommand();
                comandoBusca.Connection = conexao.CriarConexao();
                string recebeConsultaCompromissosFinalizados = sqlCompromisso.SqlListarCompromissosSemanais();

                comandoBusca.CommandText = recebeConsultaCompromissosFinalizados;
                SqlDataReader leitorConsultas = comandoBusca.ExecuteReader();

                List<Compromisso> compromissos = new List<Compromisso>();
                PopulandoListaCompromissos(leitorConsultas, compromissos);

                conexao.FecharConexao();
                return compromissos;
            }


            public List<Compromisso> ListarCompromissosFuturos()
            {

                SqlCommand comandoBusca = new SqlCommand();
                comandoBusca.Connection = conexao.CriarConexao();
                string recebeConsultaCompromissosFuturos = sqlCompromisso.SqlListarCompromissosFuturos();

                comandoBusca.CommandText = recebeConsultaCompromissosFuturos;
                SqlDataReader leitorConsultas = comandoBusca.ExecuteReader();

                List<Compromisso> compromissos = new List<Compromisso>();
                PopulandoListaCompromissos(leitorConsultas, compromissos);

                conexao.FecharConexao();
                return compromissos;
            }


            private static void PopulandoListaCompromissos(SqlDataReader leitorConsultas, List<Compromisso> compromissos)
            {
                while (leitorConsultas.Read())
                {
                    int id = Convert.ToInt32(leitorConsultas["Id"]);
                    string assunto = Convert.ToString(leitorConsultas["Assunto"]);
                    string local = Convert.ToString(leitorConsultas["Local"]);
                    DateTime data = Convert.ToDateTime(leitorConsultas["Data"]);
                    string horaInicio = Convert.ToString(leitorConsultas["HoraInicio"]);
                    string horaTermino = Convert.ToString(leitorConsultas["HoraTermino"]);
                    string nomeContato = Convert.ToString(leitorConsultas["Nome"]);

                    Compromisso compromisso = new Compromisso(id, assunto, local, data, horaInicio, horaTermino, nomeContato);
                    compromissos.Add(compromisso);

                }
            }
    }
}

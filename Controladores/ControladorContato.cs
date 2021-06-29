using AgendaDeTarefas.Conexao;
using AgendaDeTarefas.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDeTarefas.Controladores
{
    public class ControladorContato : Conexao
    {
        private readonly SqlContato sqlContato;
        private Conexao conexao;

        public ControladorContato()
        {
            sqlContato = new SqlContato();
            conexao = new Conexao();
        }
        public void InserirContato(Contato contato)
        {
            SqlCommand comandoInsercao = new SqlCommand();
            comandoInsercao.Connection = conexao.CriarConexao();
            string recebeComandoInsercao = sqlContato.SqlInsercaoContato();

            comandoInsercao.CommandText = recebeComandoInsercao;
            comandoInsercao.Parameters.AddWithValue("Nome", contato.Nome);
            comandoInsercao.Parameters.AddWithValue("Email", contato.Email);
            comandoInsercao.Parameters.AddWithValue("Telefone", contato.Telefone);
            comandoInsercao.Parameters.AddWithValue("Empresa", contato.Empresa);
            comandoInsercao.Parameters.AddWithValue("Cargo", contato.Cargo);

            object id = comandoInsercao.ExecuteScalar();
            contato.Id = Convert.ToInt32(id);

            FecharConexao();
        }

        public List<Contato> ListarContatos()
        {

            SqlCommand comandoBusca = new SqlCommand();
            comandoBusca.Connection = conexao.CriarConexao();
            string recebeConsultaContatos = sqlContato.SqlListarContato();

            comandoBusca.CommandText = recebeConsultaContatos;
            SqlDataReader leitorConsultas = comandoBusca.ExecuteReader();

            List<Contato> contatos = new List<Contato>();
            PopulandoListaContatos(leitorConsultas, contatos);

            FecharConexao();
            return contatos;
        }

        private static void PopulandoListaContatos(SqlDataReader leitorConsultas, List<Contato> contatos)
        {
            while (leitorConsultas.Read())
            {
                int id = Convert.ToInt32(leitorConsultas["Id"]);
                string nome = Convert.ToString(leitorConsultas["Nome"]);
                string email = Convert.ToString(leitorConsultas["Email"]);
                string telefone = Convert.ToString(leitorConsultas["Telefone"]);
                string empresa = Convert.ToString(leitorConsultas["Empresa"]);
                string cargo = Convert.ToString(leitorConsultas["Cargo"]);

                Contato contato = new Contato(id, nome, email, telefone, empresa, cargo);
                contatos.Add(contato);

            }
        }

        public void EditarContato(int id, Contato contato)
        {
            SqlCommand comandoEdicao = new SqlCommand();
            comandoEdicao.Connection = conexao.CriarConexao();
            string recebeComandoEdicao = sqlContato.SqlEdicaoContato();

            comandoEdicao.CommandText = recebeComandoEdicao;
            comandoEdicao.Parameters.AddWithValue("Nome", contato.Nome);
            comandoEdicao.Parameters.AddWithValue("Email", contato.Email);
            comandoEdicao.Parameters.AddWithValue("Telefone", contato.Telefone);
            comandoEdicao.Parameters.AddWithValue("Empresa", contato.Empresa);
            comandoEdicao.Parameters.AddWithValue("Cargo", contato.Cargo);

            comandoEdicao.CommandText = recebeComandoEdicao;
            comandoEdicao.Parameters.AddWithValue("Id", id);

            comandoEdicao.ExecuteNonQuery();
            FecharConexao();
        }


        public void ExcluirContato(int id)
        {
            SqlCommand comandoExclusao = new SqlCommand();
            comandoExclusao.Connection = CriarConexao();
            string recebeComandoExclusao = sqlContato.SqlExclusaoContato();

            comandoExclusao.CommandText = recebeComandoExclusao;
            comandoExclusao.Parameters.AddWithValue("Id", id);

            comandoExclusao.ExecuteNonQuery();
            FecharConexao();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDeTarefas.Controller
{
    public class Conexao
    {

        private SqlConnection conexaoBanco;
        public SqlConnection ConexaoBanco { get => conexaoBanco; set => conexaoBanco = value; }
        public string EnderecoConexao { get => enderecoConexao; set => enderecoConexao = value; }

        private string enderecoConexao = @"Data Source=(LocalDb)\MSSqlLocalDB;Initial Catalog=BDEmpresa;Integrated Security=True;Pooling=False";


        public SqlConnection CriarConexao()
        {
            conexaoBanco = new SqlConnection();
            conexaoBanco.ConnectionString = enderecoConexao;
            conexaoBanco.Open();

            return conexaoBanco;
        }

        public void FecharConexao()
        {
            ConexaoBanco.Close();
        }

    }
}

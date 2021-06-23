using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDeTarefas.Model
{
    public class Contato
    {
        private int id;
        private string nome;
        private string email;
        private string telefone;
        private string empresa;
        private string cargo;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Email { get => email; set => email = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Empresa { get => empresa; set => empresa = value; }
        public string Cargo { get => cargo; set => cargo = value; }

        public Contato(int id, string nome, string email, string telefone, string empresa, string cargo)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Empresa = empresa;
            Cargo = cargo;
        }

        public Contato(string nome, string email, string telefone, string empresa, string cargo)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Empresa = empresa;
            Cargo = cargo;
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            bool verificaEmail = email.Contains("@") && email.Contains(".com");

            if (verificaEmail == false)
            {

                resultadoValidacao += "Email inválido";
            }

            if (telefone.Length < 10)
            {

                resultadoValidacao += "Telefone inválido";
            }

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }
    }
}

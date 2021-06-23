using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDeTarefas.Model
{
    public class Tarefa
    {
        private int id;
        private string titulo;
        private DateTime dataDeCriacao;
        private DateTime dataDeConclusao;
        private int percentual;
        private string prioridade;

        public int Id { get => id; set => id = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public DateTime DataDeCriacao { get => dataDeCriacao; set => dataDeCriacao = value; }
        public DateTime DataDeConclusao { get => dataDeConclusao; set => dataDeConclusao = value; }
        public int Percentual { get => percentual; set => percentual = value; }
        public string Prioridade { get => prioridade; set => prioridade = value; }


        public Tarefa(string Titulo, DateTime DataDeCriacao, DateTime DataDeConlusao, int Percentual, string Prioridade)
        {
            titulo = Titulo;
            dataDeCriacao = DataDeCriacao;
            dataDeConclusao = DataDeConlusao;
            percentual = Percentual;
            prioridade = Prioridade;

        }

        public Tarefa(int id, string titulo, DateTime dataDeConclusao, int percentual, string prioridade)
        {
            Id = id;
            Titulo = titulo;
            DataDeConclusao = dataDeConclusao;
            Percentual = percentual;
            Prioridade = prioridade;
        }

        public Tarefa(string titulo, DateTime dataDeConclusao, int percentual, string prioridade)
        {
            this.titulo = titulo;
            this.dataDeConclusao = dataDeConclusao;
            this.percentual = percentual;
            this.prioridade = prioridade;
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (percentual < 0 || percentual > 100)
            {

                resultadoValidacao += "Percentual não pode ser menor que 0 nem maior que 100 !! \n";
            }

            
            if (dataDeCriacao > dataDeConclusao)
            {
                resultadoValidacao += "Data de criação não pode ser maior que data conclusão \n";
            }

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }
    }
}

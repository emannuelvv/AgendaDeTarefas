using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDeTarefas.Model
{
    public class Compromisso
    {

        private int id;
        private string local;
        private string assunto;
        private DateTime data;
        private string horaInicio;
        private string horaTermino;
        private string nomeContato;
        private int idContato;

        public int Id { get => id; set => id = value; }
        public string Local { get => local; set => local = value; }
        public string Assunto { get => assunto; set => assunto = value; }
        public DateTime Data { get => data; set => data = value; }
        public string HoraInicio { get => horaInicio; set => horaInicio = value; }
        public string HoraTermino { get => horaTermino; set => horaTermino = value; }
        public int IdContato { get => idContato; set => idContato = value; }
        public string NomeContato { get => nomeContato; set => nomeContato = value; }


        public Compromisso(string Assunto, string Local, DateTime DataCompromisso, string HoraInicio, string HoraTermino, int IdContato)
        {
            assunto = Assunto;
            local = Local;
            data = DataCompromisso;
            horaInicio = HoraInicio;
            horaTermino = HoraTermino;
            idContato = IdContato;
        }

        public Compromisso(int id, string Assunto, string Local, DateTime DataCompromisso, string HoraInicio, string HoraTermino, string Nome)
        {
            Id = id;
            assunto = Assunto;
            local = Local;
            data = DataCompromisso;
            horaInicio = HoraInicio;
            horaTermino = HoraTermino;
            nomeContato = Nome;
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (data.DayOfWeek == DayOfWeek.Sunday || data.DayOfWeek == DayOfWeek.Saturday)
            {

                resultadoValidacao += "Reuniões apenas em dia de semana!";
            }

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;

        }


    }
}
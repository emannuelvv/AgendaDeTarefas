using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDeTarefas.Conexao
{
	public class SqlCompromisso
	{
		public string SqlInsercaoCompromisso()
		{
			string sqlInsercao = @"INSERT INTO TBCOMPROMISSO(
			[ASSUNTO],
			[LOCAL],
			[DATA],
			[HORAINICIO],
			[HORATERMINO],
			[IDCONTATO])
			
			VALUES (
			@ASSUNTO,
			@LOCAL,
			@DATA,
			@HORAINICIO,
			@HORATERMINO,
			@IDCONTATO)";

			sqlInsercao += @"SELECT SCOPE_IDENTITY()";

			return sqlInsercao;
		}

		public string SqlEdicaoCompromisso()
		{
			string sqlEdicao = @"UPDATE
						SET TBCOMPROMISSO(
						[ASSUNTO] = ASSUNTO,
						[LOCAL] = LOCAL,
						[DATA] = DATA,
						[HORAINICIO] = HORAINICIO,
						[HORATERMINO] = HORATERMINO,
						[IDCONTATO] = IDCONTATO,
						WHERE [IDCONTATO] = @IDCONTATO";

			return sqlEdicao;
		}

		public string SqlExlusaoCompromisso()
		{
			string sqlExcluso =
						@"DELETE FROM TBCOMPROMISSO WHERE [ID] = @ID";



			return sqlExcluso;
		}

		public string SqlListarCompromissosFinalizados()
		{
			string sqlBusca = @"SELECT 
			[TBCOMPROMISSO].ID,
			[ASSUNTO],
			[LOCAL],
			[DATA],
			[HORAINICIO],
			[HORATERMINO],
			[TBCONTATO].NOME 
			
			FROM 
			
			TBCOMPROMISSO INNER JOIN 
			TBCONTATO ON 
			TBCOMPROMISSO.IDCONTATO = TBCONTATO.ID
			WHERE [DATA]< GETDATE();";

			return sqlBusca;
		}

		public string SqlListarCompromissosFuturos()
		{
			string sqlBusca = @"SELECT 
			[TBCOMPROMISSO].ID,
			[ASSUNTO],
			[LOCAL],
			[DATA],
			[HORAINICIO],
			[HORATERMINO],
			[TBCONTATO].NOME 
			
			FROM 
			
			TBCOMPROMISSO INNER JOIN 
			TBCONTATO ON 
			TBCOMPROMISSO.IDCONTATO = TBCONTATO.ID
			WHERE [DATA] > GETDATE();";

			return sqlBusca;
		}

		public string SqlListarCompromissosDiarios()
		{
			string sqlBusca = @"SELECT 
			[TBCOMPROMISSO].ID,
			[ASSUNTO],
			[LOCAL],
			[DATA],
			[HORAINICIO],
			[HORATERMINO],
			[TBCONTATO].NOME 
			
			FROM 
			
			TBCOMPROMISSO INNER JOIN 
			TBCONTATO ON 
			TBCOMPROMISSO.IDCONTATO = TBCONTATO.ID
			WHERE [DATA] = CONVERT(date,GETDATE())";

			return sqlBusca;
		}

		public string SqlListarCompromissosSemanais()
		{
			string sqlBusca = @"SELECT 
			[TBCOMPROMISSO].ID,
			[ASSUNTO],
			[LOCAL],
			[DATA],
			[HORAINICIO],
			[HORATERMINO],
			[TBCONTATO].NOME 
			
			FROM 
			
			TBCOMPROMISSO INNER JOIN 
			TBCONTATO ON 
			TBCOMPROMISSO.IDCONTATO = TBCONTATO.ID
			
			WHERE DATEDIFF(DAY,GETDATE (),[DATA]) <= 7 AND DATEDIFF(DAY,GETDATE (),[DATA]) > 1;";

			return sqlBusca;
		}

	}
}

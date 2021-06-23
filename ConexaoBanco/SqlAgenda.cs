using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDeTarefas.Conexao
{
    public class SqlAgenda
    {
        public string SqlInsercaoTarefa()
        {

            string sqlInsercao =
           @"INSERT INTO TBAGENDA ([TITULO],[DATADECRIACAO],[DATADECONCLUSAO],[PERCENTUAL],[PRIORIDADE])
           VALUES (@TITULO,@DATADECRIACAO,@DATADECONCLUSAO,@PERCENTUAL,@PRIORIDADE)";

            sqlInsercao += @"SELECT SCOPE_IDENTITY()";

            return sqlInsercao;
        }

        public string SqlTarefasPendentes()
        {
            string sqlTarefasPendentes = @"SELECT [ID],[TITULO],[DATADECONCLUSAO],[PERCENTUAL],[PRIORIDADE] 
                                          FROM 
                                          TBAGENDA
                                          WHERE PERCENTUAL < 100 ORDER BY PRIORIDADE";
            return sqlTarefasPendentes;
        }

        public string SqlTarefasFinalizadas()
        {
            string sqlTarefasFinalizadas = @"SELECT [ID],[TITULO],[DATADECONCLUSAO],[PERCENTUAL],
                                        CASE [PRIORIDADE] 
                                        WHEN 'ALTA' THEN 'FINALIZADA'
                                        WHEN 'NORMAL' THEN 'FINALIZADA'
                                        WHEN 'BAIXA' THEN 'FINALIZADA'
                                        END AS [PRIORIDADE]                                      
                                        FROM 
                                        TBAGENDA
                                        WHERE PERCENTUAL = 100 ORDER BY PRIORIDADE";
            return sqlTarefasFinalizadas;
        }

        public string SqlTodasAsTarefas()
        {
            string sqlTodasAsTarefas = @"SELECT [ID],[TITULO],[DATADECONCLUSAO],[PERCENTUAL],[PRIORIDADE] 
                                          FROM 
                                          TBAGENDA ORDER BY ID ASC";
            return sqlTodasAsTarefas;
        }

        public string SqlEdicaoTarefa()
        {
            string sqlEdicao = @"UPDATE TBAGENDA SET
                                            [TITULO] = @TITULO,
                                            [DATADECONCLUSAO] = @DATADECONCLUSAO,
                                            [PERCENTUAL] = @PERCENTUAL,
                                            [PRIORIDADE] = @PRIORIDADE 
                                            WHERE [ID] = @ID";

            return sqlEdicao;
        }

        public string SqlExclusaoTarefa()
        {
            string sqlEdicao = @"DELETE FROM TBAGENDA 
                                            WHERE [ID] = @ID";
            return sqlEdicao;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDeTarefas.Conexao
{
    public class SqlContato
    {

        public string SqlInsercaoContato()
        {

            string sqlInsercao =
            @"INSERT INTO TBCONTATO([NOME],[EMAIL],[TELEFONE],[EMPRESA],[CARGO])
           VALUES (@NOME,@EMAIL,@TELEFONE,@EMPRESA,@CARGO)";

            sqlInsercao += @"SELECT SCOPE_IDENTITY()";

            return sqlInsercao;
        }

        public string SqlListarContato()
        {

            string sqlInsercao =
            @"SELECT [ID],[NOME],[EMAIL],[TELEFONE],[EMPRESA],[CARGO] FROM TBCONTATO 
            GROUP BY [ID],[NOME],[EMAIL],[TELEFONE],[EMPRESA],[CARGO] ;";

            return sqlInsercao;
        }

        public string SqlExclusaoContato()
        {

            string sqlInsercao =
            @"DELETE FROM TBAGENDA WHERE [ID] = @ID;";

            return sqlInsercao;
        }

        public string SqlEdicaoContato()
        {
            string sqlEdicao = @"UPDATE TBCONTATO SET
                                            [NOME] = @NOME,
                                            [EMAIL] = @EMAIL,
                                            [TELEFONE] = @TELEFONE,
                                            [EMPRESA] = @EMPRESA, 
                                            [CARGO] = @CARGO
                                            WHERE [ID] = @ID";

            return sqlEdicao;
        }
    }
}

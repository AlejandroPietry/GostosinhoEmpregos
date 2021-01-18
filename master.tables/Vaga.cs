using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace master.tables
{
    public class Vaga
    {
        #region Propriedades
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Funcao { get; set; }
        public string Descricao { get; set; }
        public DateTime DataValidade { get; set; }
        public string Cidade { get; set; }
        public string Cpf { get; set; }
        public string NomeResponsavel { get; set; }
        public int Flg_Vaga_Inativa { get; set; }
        #endregion

        #region metodos
        public static void Insert(string funcao, string descricao, DateTime dataValidade,
            string cidade, decimal cpf, string nomeResponsavel)
        {
            using (SqlConnection conn = new SqlConnection(Constants))
            {

            }

        }
        #endregion

    }
}

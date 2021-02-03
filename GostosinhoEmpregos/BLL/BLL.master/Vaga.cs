using GostosinhoEmpregos.BLL.BLL.constants;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GostosinhoEmpregos.BLL.BLL.master
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

        #region Consultas
        private static string SP_INSERT = @"
            INSERT INTO dbo.Vaga(Funcao, Descricao, DataCadastro, DataValidade, Cidade,Cpf,NomeResponsavel,Flg_Vaga_Inativa)
            VALUES(@funcao, @descricao, GETDATE(),@dataValidade, @cidade, @cpf, @nomeResponsavel, 0)";

        private static string SP_SELECT_ULTIMAS_VAGAS = @"SELECT TOP 3 * from dbo.Vaga ORDER BY ID DESC";

        private static string SP_SELECT_VAGA_POR_ID = @"SELECT * from dbo.Vaga WHERE ID = @id";
        #endregion

        #region metodos
        public static void Insert(string funcao, string descricao, DateTime dataValidade,
            string cidade, decimal cpf, string nomeResponsavel)
        {
            using (SqlConnection conn = new SqlConnection(Constants.Conn_DB))
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = SP_INSERT;
                cmd.Parameters.AddWithValue("@funcao", funcao);
                cmd.Parameters.AddWithValue("@descricao", descricao);
                cmd.Parameters.AddWithValue("@dataValidade", dataValidade);
                cmd.Parameters.AddWithValue("@cidade", cidade);
                cmd.Parameters.AddWithValue("@cpf", cpf);
                cmd.Parameters.AddWithValue("@nomeResponsavel", nomeResponsavel);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

        }

        /// <summary>
        /// Metodo que retorna as ultimas 3 vagas publicadas.
        /// </summary>
        /// <remarks>Alejadnro Pietry</remarks>
        public static List<Vaga> RecuperarVagasNovas()
        {
            List<Vaga> listaVagas = new List<Vaga>();

            using (SqlConnection conn = new SqlConnection(Constants.Conn_DB))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = SP_SELECT_ULTIMAS_VAGAS;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    listaVagas.Add(new Vaga
                    {
                        Id = int.Parse(dr["Id"].ToString()),
                        Funcao = dr["Funcao"].ToString() ,
                        Descricao = $"{dr["Descricao"].ToString().Substring(0, 50)} ...",
                        DataCadastro = DateTime.Parse(dr["DataCadastro"].ToString()),
                        Cidade = dr["Cidade"].ToString().ToUpper()
                    });
                }
                conn.Close();
            }

            return listaVagas;
        }

        public static Vaga RecuperarVagaPorId(int idVaga)
        {
            using (SqlConnection conn = new SqlConnection(Constants.Conn_DB))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = SP_SELECT_VAGA_POR_ID;
                cmd.Parameters.AddWithValue("@id", idVaga);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    return new Vaga
                    {
                        Id = int.Parse(dr["Id"].ToString()),
                        Funcao = dr["Funcao"].ToString(),
                        Descricao = dr["Descricao"].ToString(),
                        DataCadastro = DateTime.Parse(dr["DataCadastro"].ToString()),
                        Cidade = dr["Cidade"].ToString().ToUpper(),
                        DataValidade = DateTime.Parse(dr["DataValidade"].ToString()),
                        NomeResponsavel = dr["NomeResponsavel"].ToString()
                    };
                }
                conn.Close();
            }
            return null;
            #endregion
        }
    }
}

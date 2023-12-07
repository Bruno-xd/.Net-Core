using GonzalesRamirez.Models;
using System.Data.SqlClient;
using System.Data;
namespace GonzalesRamirez.Datos
{
    public class DistritoDatos
    {
        public List<Distrito> Listar()
        {

            var oLista = new List<Distrito>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarDistrito", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new Distrito()
                        {
                            IdDistrito = Convert.ToInt32(dr["Id"]),
                            NombreDistrito = dr["NombreDistrito"].ToString()
                        });

                    }
                }
            }

            return oLista;
        }

        public List<Distrito> ListarPorProvincia(int idProvincia)
        {
            var oLista = new List<Distrito>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarDistritoPorProvincia", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProvincia", idProvincia);

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new Distrito()
                        {
                            IdDistrito = Convert.ToInt32(dr["Id"]),
                            NombreDistrito = dr["NombreDistrito"].ToString()
                        });
                    }
                }
            }

            return oLista;
        }
    }
}

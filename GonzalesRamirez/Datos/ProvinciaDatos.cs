using GonzalesRamirez.Models;
using System.Data.SqlClient;
using System.Data;
namespace GonzalesRamirez.Datos
{
    public class ProvinciaDatos
    {
        public List<Provincia> Listar()
        {

            var oLista = new List<Provincia>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarProvincia", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new Provincia()
                        {
                            IdProvincia = Convert.ToInt32(dr["Id"]),
                            IdDepartamento = Convert.ToInt32(dr["IdDepartamento"]),
                            NombreProvincia = dr["NombreProvincia"].ToString()
                        });

                    }
                }
            }

            return oLista;
        }
    }
}

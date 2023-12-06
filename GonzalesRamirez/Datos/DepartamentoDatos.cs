using GonzalesRamirez.Models;
using System.Data.SqlClient;
using System.Data;
namespace GonzalesRamirez.Datos
{
    public class DepartamentoDatos
    {
        public List<Departamento> Listar()
        {

            var oLista = new List<Departamento>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarDepartamento", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new Departamento()
                        {
                            IdDepartamento = Convert.ToInt32(dr["Id"]),
                            NombreDepartamento = dr["NombreDepartamento"].ToString()
                        });

                    }
                }
            }

            return oLista;
        }
    }
}

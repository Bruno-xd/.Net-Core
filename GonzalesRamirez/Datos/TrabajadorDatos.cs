using GonzalesRamirez.Models;
using System.Data.SqlClient;
using System.Data;
namespace GonzalesRamirez.Datos
{
    public class TrabajadorDatos
    {
        private string ObtenerNombreDepartamento(int idDepartamento)
        {
            string nombreDepartamento = "";

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();

                using (SqlCommand cmd = new SqlCommand("sp_ObtenerNombreDepartamento", conexion)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdDepartamento", idDepartamento);

                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        nombreDepartamento = result.ToString();
                    }
                }
            }

            return nombreDepartamento;
        }
        private string ObtenerNombreProvincia(int idProvincia)
        {
            string nombreProvincia = "";

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();

                using (SqlCommand cmd = new SqlCommand("sp_ObtenerNombreProvincia", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProvincia", idProvincia);

                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        nombreProvincia = result.ToString();
                    }
                }
            }

            return nombreProvincia;
        }
        private string ObtenerNombreDistrito(int idDistrito)
        {
            string nombreDistrito = "";

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();

                using (SqlCommand cmd = new SqlCommand("sp_ObtenerNombreDistrito", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdDistrito", idDistrito);

                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        nombreDistrito = result.ToString();
                    }
                }
            }

            return nombreDistrito;
        }

        public List<Trabajador> Listar()
        {

            var oLista = new List<Trabajador>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarTrabajadores", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new Trabajador()
                        {
                            IdTrabajador = Convert.ToInt32(dr["Id"]),
                            TipoDocumento = dr["TipoDocumento"].ToString(),
                            NumDocumento = dr["NumeroDocumento"].ToString(),
                            Nombres = dr["Nombres"].ToString(),
                            Sexo = dr["Sexo"].ToString(),
                            IdDepartamento = Convert.ToInt32(dr["IdDepartamento"]),
                            NombreDepartamento = ObtenerNombreDepartamento(Convert.ToInt32(dr["IdDepartamento"])),
                            IdProvincia = Convert.ToInt32(dr["IdProvincia"]),
                            NombreProvincia = ObtenerNombreProvincia(Convert.ToInt32(dr["IdProvincia"])),
                            IdDistrito = Convert.ToInt32(dr["IdDistrito"]),
                            NombreDistrito = ObtenerNombreDistrito(Convert.ToInt32(dr["IdDistrito"]))
                        });

                    }
                }
            }

            return oLista;
        }
        
        public Trabajador Obtener(int IdTrabajador)
        {

            var oTrabajador = new Trabajador();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerTrabajador", conexion);
                cmd.Parameters.AddWithValue("IdTrabajador", IdTrabajador);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oTrabajador.IdTrabajador = Convert.ToInt32(dr["Id"]);
                        oTrabajador.TipoDocumento = dr["TipoDocumento"].ToString();
                        oTrabajador.NumDocumento = dr["NumeroDocumento"].ToString();
                        oTrabajador.Nombres = dr["Nombres"].ToString();
                        oTrabajador.Sexo = dr["Sexo"].ToString();
                        oTrabajador.IdDepartamento = Convert.ToInt32(dr["IdDepartamento"]);
                        oTrabajador.IdProvincia = Convert.ToInt32(dr["IdProvincia"]);
                        oTrabajador.IdDistrito = Convert.ToInt32(dr["IdDistrito"]);
                    }
                }
            }

            return oTrabajador;
        }
        
        public bool Guardar(Trabajador oTrabajador)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarTrabajador", conexion);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TipoDocumento", oTrabajador.TipoDocumento);
                    cmd.Parameters.AddWithValue("@NumDocumento", oTrabajador.NumDocumento);
                    cmd.Parameters.AddWithValue("@Nombres", oTrabajador.Nombres);
                    cmd.Parameters.AddWithValue("@Sexo", oTrabajador.Sexo);
                    cmd.Parameters.AddWithValue("@IdDepartamento", oTrabajador.IdDepartamento);
                    cmd.Parameters.AddWithValue("@IdProvincia", oTrabajador.IdProvincia);
                    cmd.Parameters.AddWithValue("@IdDistrito", oTrabajador.IdDistrito);
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {

                string error = e.Message;
                rpta = false;
            }



            return rpta;
        }

        
        public bool Editar(Trabajador oTrabajador)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarTrabajador", conexion);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdTrabajador", oTrabajador.IdTrabajador);
                    cmd.Parameters.AddWithValue("@TipoDocumento", oTrabajador.TipoDocumento);
                    cmd.Parameters.AddWithValue("@NumDocumento", oTrabajador.NumDocumento);
                    cmd.Parameters.AddWithValue("@Nombres", oTrabajador.Nombres);
                    cmd.Parameters.AddWithValue("@Sexo", oTrabajador.Sexo);
                    cmd.Parameters.AddWithValue("@IdDepartamento", oTrabajador.IdDepartamento);
                    cmd.Parameters.AddWithValue("@IdProvincia", oTrabajador.IdProvincia);
                    cmd.Parameters.AddWithValue("@IdDistrito", oTrabajador.IdDistrito);

                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {

                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
        
        public bool Eliminar(int IdTrabajador)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarTrabajador", conexion);
                    cmd.Parameters.AddWithValue("IdTrabajador", IdTrabajador);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
        
    }
}

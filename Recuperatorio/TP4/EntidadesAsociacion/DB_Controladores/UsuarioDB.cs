using EntidadesAsociacion.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EntidadesAsociacion.Enumerados;

namespace EntidadesAsociacion.DB_Controladores
{
    public class UsuarioDB
    {
        /// <summary>
        /// Método encargado de insertar a la base de datos el usuario pasado por parametros
        /// </summary>
        /// <param name="usuario">Usuario a insertar</param>
        /// <returns>Cantidad de registros insertados</returns>
        public static int Insertar(Usuario usuario)
        {
            string strComando;
            SqlConnection coneccion = DB.Coneccion;
            SqlCommand comando = new SqlCommand();
            comando.Connection = coneccion;
            int retorno = 0; 

            strComando = "INSERT INTO " +
                "[TPFinal_EvelynYanez].[dbo].[usuarios] ( " +
                    "dni, " +
                    "nombre, " +
                    "apellido, " +
                    "telefono, " +
                    "grupo, " +
                    "denunciasRegistradas, " +
                    "fechaIngreso, " +
                    "activo) " +
                "VALUES " +
                    $"({usuario.Dni}, " +
                    $" '{usuario.Nombre}' , " +
                    $" '{usuario.Apellido}' , " +
                    $" {usuario.NumeroTelefonico} , " +
                    $" {(int)usuario.Grupo}, " +
                    $" {usuario.DenunciasRegistradas}, " +
                    $" CONVERT(datetime, '{usuario.FechaIngreso.Date}', 103), " +
                    $" {(usuario.Activo ? 1 : 0)}); ";

            comando.CommandText = strComando;

            try
            {
                coneccion.Open();
                retorno = comando.ExecuteNonQuery();

                if (retorno > 0)
                {
                    usuario.ListadoDeDelitos.ForEach(causaIngreso =>
                    {
                        strComando = "INSERT INTO " +
                                        "[TPFinal_EvelynYanez].[dbo].[delitos] " +
                                            " (dni, tipo) " +
                                        " VALUES" +
                                            $"({usuario.Dni},{(int)causaIngreso}); ";
                        comando.CommandText = strComando;
                        comando.ExecuteNonQuery();
                    });
                }

                return retorno;
            }
            finally
            {
                coneccion.Close();
            }
        }

        /// <summary>
        /// Método encargado de buscar en la base de datos los usuarios de un grupo  
        /// que no tienen asistencias registradas para una fecha
        /// </summary>
        /// <param name="grupo">Grupo al que pertenecen los usuarios a buscar</param>
        /// <param name="fecha">Fecha de la que se busca los registros de asistencias faltantes</param>
        /// <returns>Listado de usuarios del grupo sin registros de asintecia para la fecha indicada</returns>
        public static List<Usuario> BuscarUsuariosSinAsistencia(EGrupo grupo, DateTime fecha)
        {
            string consulta = "";
            List<Usuario> listaRetorno = new List<Usuario>();

            SqlConnection coneccion = DB.Coneccion;

            consulta += " " +
                "SELECT " +
                    "U.dni, " +
                    "U.nombre, " +
                    "U.apellido, " +
                    "U.telefono, " +
                    "U.grupo, " +
                    "U.denunciasRegistradas, " +
                    "U.fechaIngreso, " +
                    "U.activo " +
                "FROM " +
                    "[TPFinal_EvelynYanez].[dbo].usuarios AS U " +
                "LEFT JOIN " +
                    "[TPFinal_EvelynYanez].[dbo].[asistencias] as A " +
                "ON A.dniUsuario = U.dni AND A.fecha =  CONVERT(datetime, @fecha, 103) " +
                "WHERE (A.dniUsuario is null OR A.fecha is null) AND U.grupo = @grupo;";

            SqlCommand comando = new SqlCommand(consulta, coneccion);

            comando.Parameters.AddWithValue("@fecha", fecha.Date);
            comando.Parameters.AddWithValue("@grupo", (int)grupo);

            try
            {
                coneccion.Open();

                SqlDataReader retornoSelect = comando.ExecuteReader();
                while (retornoSelect.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.Dni = (int)retornoSelect["dni"];
                    usuario.Nombre = retornoSelect["nombre"].ToString();
                    usuario.Apellido = retornoSelect["apellido"].ToString();
                    usuario.NumeroTelefonico = (int)retornoSelect["telefono"];
                    usuario.Grupo = (EGrupo)retornoSelect["grupo"];
                    usuario.DenunciasRegistradas = (int)retornoSelect["denunciasRegistradas"];
                    usuario.Activo = (bool)retornoSelect["activo"];
                    usuario.FechaIngreso = Convert.ToDateTime(retornoSelect["fechaIngreso"].ToString());

                    listaRetorno.Add(usuario);
                }
                return listaRetorno;
            }
            finally
            {
                coneccion.Close();
            }
        }


        /// <summary>
        /// Método ecargado de filtrar el listado de usuarios de la base de datos (tabla usuarios)
        /// Este construye la query de seleccion considerando aquellos parametros recibidos que son distintos de nulo
        /// y descartando los nulos o no recibidos.
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="fechaIngresoDesde"></param>
        /// <param name="fechaIngresoHasta"></param>
        /// <param name="grupo"></param>
        /// <param name="cantidadDenunciasDesde"></param>
        /// <param name="cantidadDenunciasHasta"></param>
        /// <returns></returns>
        public static List<Usuario> Filtrar(int? dni = null, DateTime? fechaIngresoDesde = null, 
                                                DateTime? fechaIngresoHasta = null, EGrupo? grupo = null,
                                                int? cantidadDenunciasDesde = null, int? cantidadDenunciasHasta = null)
        {
            string consulta = "";
            List<string> condiciones = new List<string>();
            List<Usuario> listaRetorno = new List<Usuario>();

            SqlConnection coneccion = DB.Coneccion;

            consulta += " " +
                "SELECT " +
                    "U.dni, " +
                    "U.nombre, " +
                    "U.apellido, " +
                    "U.telefono, " +
                    "U.grupo, " +
                    "U.denunciasRegistradas, " +
                    "U.fechaIngreso, " +
                    "U.activo, " +
                    "D.tipo AS causaIngreso " +
                "FROM " +
                    "[TPFinal_EvelynYanez].[dbo].usuarios AS U " +
                "LEFT JOIN " +
                    "[TPFinal_EvelynYanez].[dbo].[delitos] AS D " +
                "ON D.dni = U.dni ";

            // Se agregan los filtros correspondientes
            if (dni is not null)
                condiciones.Add($"U.dni = @dni ");
            if (fechaIngresoDesde is not null)
                condiciones.Add($"U.fechaIngreso >= CONVERT(datetime, @fechaIngresoDesde, 103) ");
            if (fechaIngresoHasta is not null)
                condiciones.Add($"U.fechaIngreso <= CONVERT(datetime, @fechaIngresoHasta, 103) ");
            if (grupo is not null)
                condiciones.Add($"U.grupo = @grupo ");
            if (cantidadDenunciasDesde is not null)
                condiciones.Add($"U.denunciasRegistradas >= @cantidadDenunciasDesde ");
            if (cantidadDenunciasHasta is not null)
                condiciones.Add($"U.denunciasRegistradas <= @cantidadDenunciasHasta ");

            if (condiciones.Count > 0)
                consulta += " WHERE " + string.Join(" AND ", condiciones);

            SqlCommand comando = new SqlCommand(consulta, coneccion);

            if (dni is not null)
                comando.Parameters.AddWithValue("@dni", dni);
            if (fechaIngresoDesde is not null)
                comando.Parameters.AddWithValue("@fechaIngresoDesde", ((DateTime)fechaIngresoDesde).Date);
            if (fechaIngresoHasta is not null)
                comando.Parameters.AddWithValue("@fechaIngresoHasta", ((DateTime)fechaIngresoHasta).Date);
            if (grupo is not null)
                comando.Parameters.AddWithValue("@grupo", grupo);
            if (cantidadDenunciasDesde is not null)
                comando.Parameters.AddWithValue("@cantidadDenunciasDesde", cantidadDenunciasDesde);
            if (cantidadDenunciasHasta is not null)
                comando.Parameters.AddWithValue("@cantidadDenunciasHasta", cantidadDenunciasHasta);

            try
            {
                coneccion.Open();

                SqlDataReader retornoSelect = comando.ExecuteReader();
                while (retornoSelect.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.Dni = (int)retornoSelect["dni"];
                    usuario.Nombre = retornoSelect["nombre"].ToString();
                    usuario.Apellido = retornoSelect["apellido"].ToString();
                    usuario.NumeroTelefonico = (int)retornoSelect["telefono"];
                    usuario.Grupo = (EGrupo)retornoSelect["grupo"];
                    usuario.DenunciasRegistradas = (int)retornoSelect["denunciasRegistradas"];
                    usuario.Activo = (bool)retornoSelect["activo"];
                    usuario.FechaIngreso = Convert.ToDateTime(retornoSelect["fechaIngreso"].ToString());
                    ETipoCausaIngreso? causaIngreso = Convert.IsDBNull(retornoSelect["causaIngreso"]) ? null : (ETipoCausaIngreso)retornoSelect["causaIngreso"];

                    if (causaIngreso is not null)
                        usuario.ListadoDeDelitos.Add((ETipoCausaIngreso)causaIngreso);

                    Usuario retornoUsuario = listaRetorno.Find(usuarioRetorno => usuarioRetorno.Equals(usuario));

                    if (retornoUsuario is not null && causaIngreso is not null)
                    {
                        retornoUsuario.ListadoDeDelitos.Add((ETipoCausaIngreso)causaIngreso);
                    }
                    else
                    {
                        listaRetorno.Add(usuario);
                    }
                }
                return listaRetorno;
            }
            finally
            {
                coneccion.Close();
            }
        }


        /// <summary>
        /// Método encargado de eliminar un usuario.
        /// Este metodo eliminara el usuario y eliminara en cascada los datos relacionados
        /// al mismo en otras tablas (asistencias y delitos).
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        public static int Eliminar(int dni)
        {
            string strComando;
            SqlConnection coneccion = DB.Coneccion;
            SqlCommand comando = new SqlCommand();
            comando.Connection = coneccion;

            strComando = "DELETE FROM [TPFinal_EvelynYanez].[dbo].usuarios " +
                $" WHERE " +
                    $" dni = {dni}; ";

            comando.CommandText = strComando;

            try
            {
                coneccion.Open();
                return comando.ExecuteNonQuery();
            }
            finally
            {
                coneccion.Close();
            }

        }
    }
}

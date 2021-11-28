using System.Collections.Generic;
using System;
using static EntidadesAsociacion.Enumerados;
using EntidadesAsociacion.Utils;
using System.Data.SqlClient;

namespace EntidadesAsociacion.DB_Controladores
{
    public class AsistenciaDB
    {
        /// <summary>
        /// Método encargado de insertar en la base de datos una asistencia
        /// Esta se insertara en la tabla asistencias
        /// </summary>
        /// <param name="asistencia">Asistencia a insertar</param>
        /// <returns>Cantidad de registros insertados</returns>
        public static int Insertar(Asistencia asistencia)
        {
            string strComando;
            SqlConnection coneccion = DB.Coneccion;
            SqlCommand comando = new SqlCommand();
            comando.Connection = coneccion;

            strComando = "INSERT INTO " +
                "[TPFinal_EvelynYanez].[dbo].asistencias " +
                    " (fecha, grupo, presente, dniUsuario) " +
                "VALUES " +
                    $"(CONVERT(datetime, '{asistencia.Fecha.Date}', 103), {(int)asistencia.Grupo}, {(int)asistencia.Presente}, {asistencia.DniUsuario});";
            comando.CommandText = strComando;

            try
            {
                coneccion.Open();
                int retorno = comando.ExecuteNonQuery();
                return retorno;
            }
            finally
            {
                coneccion.Close();
            }
        }

        /// <summary>
        /// Método encargado de actualizar ek tipo de asistencia de asistencia correspondiente a un
        /// registro de asistencia cargado en la tabla asistencias.
        /// Buscandola por fecha de asistencia y dni del usuario
        /// </summary>
        /// <param name="dni">Dni del usuario</param>
        /// <param name="fechaAsistencia">Fecha de asistencia</param>
        /// <param name="tipoAsistencia">Tipo de asistencia actualizada</param>
        /// <returns>Cantidad de registros afectados</returns>
        public static int Actualizar(int dni, DateTime fechaAsistencia ,ETipoAsistencia tipoAsistencia)
        {
            string strComando;
            SqlConnection coneccion = DB.Coneccion;
            SqlCommand comando = new SqlCommand();
            comando.Connection = coneccion;

            strComando = "UPDATE [TPFinal_EvelynYanez].[dbo].asistencias " +
                $" SET presente = {(int)tipoAsistencia} " +
                $" WHERE" +
                    $" dniUsuario = {dni} AND " +
                    $" fecha = CONVERT(datetime, '{fechaAsistencia.Date}', 103) ;";

            comando.CommandText = strComando;

            try
            {
                coneccion.Open();
                int retorno = comando.ExecuteNonQuery();
                return retorno;
            }
            finally
            {
                coneccion.Close();
            }

        }

        /// <summary>
        /// Método encargado de eliminar una asistencia de la base de datos (tabla asistencias)
        /// Se eliminara la asistencia correspondiente al dni y fecha de asistencia pasados por parametros.
        /// </summary>
        /// <param name="dni">Dni del usuario</param>
        /// <param name="fechaAsistencia">Fecha de asistencia</param>
        /// <returns>Cantidad de registros eliminados</returns>
        public static int Eliminar(int dni, DateTime fechaAsistencia)
        {
            string strComando;
            SqlConnection coneccion = DB.Coneccion;
            SqlCommand comando = new SqlCommand();
            comando.Connection = coneccion;

            strComando = "DELETE FROM [TPFinal_EvelynYanez].[dbo].asistencias " +
                $" WHERE " +
                    $" dniUsuario = {dni} AND " +
                    $" fecha = CONVERT(datetime, '{fechaAsistencia.Date}', 103) ;";

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

        /// <summary>
        /// Método encago de generar la query y filtrar el listado de asistencias de la base de datos.
        /// Esta generara el filtro para los campos pasados por parametro. Si estos se reciben como null o 
        /// no se reciben entonces no seran considerados para generar el filtro.
        /// </summary>
        /// <param name="dni">Dni del usuario</param>
        /// <param name="fechaAsistenciaDesde">Fecha de asistencia desde (Se incluye la fecha en el resultado)</param>
        /// <param name="fechaAsistenciaHasta">fecha de asistencia hasta (Se incluye la fecha en el resultado)</param>
        /// <param name="grupo">Tipo de grupo de la asitencia</param>
        /// <param name="tipoAsistencia">Tipo de asistencia</param>
        /// <returns>Listado de asistencias filtrado</returns>
        public static List<Asistencia> Filtrar(int? dni = null, DateTime? fechaAsistenciaDesde = null, DateTime? fechaAsistenciaHasta = null, EGrupo? grupo = null, ETipoAsistencia? tipoAsistencia = null)
        {
            string consulta = "";
            List<string> condiciones = new List<string>();
            List<Asistencia> listaRetorno = new List<Asistencia>();

            SqlConnection coneccion = DB.Coneccion;

            // Se genera la query
            consulta += " " +
                "SELECT " +
                    "A.fecha AS fechaAsistencia, " +
                    "A.grupo AS grupoAsistencia, " +
                    "A.presente, " +
                    "U.dni, " +
                    "U.nombre, " +
                    "U.apellido, " +
                    "U.telefono, " +
                    "U.grupo, " +
                    "U.denunciasRegistradas, " +
                    "U.activo, " +
                    "D.tipo as causaIngreso " +
                "FROM " +
                    "[TPFinal_EvelynYanez].[dbo].asistencias AS A " +
                "INNER JOIN " +
                    "[TPFinal_EvelynYanez].[dbo].usuarios AS U " +
                "ON A.dniUsuario = U.dni " +
                "LEFT JOIN " +
                    "[TPFinal_EvelynYanez].[dbo].delitos AS D " +
                "ON U.dni = D.dni ";

            // Se incluyen los filtros recibidos según corresponda
            if (dni is not null)
                condiciones.Add($" U.dni = @dni");
            if (fechaAsistenciaDesde is not null)
                condiciones.Add($" A.fecha >= CONVERT(datetime, @fechaAsistenciaDesde, 103) ");
            if (fechaAsistenciaHasta is not null)
                condiciones.Add($" A.fecha  <= CONVERT(datetime, @fechaAsistenciaHasta, 103) ");
            if (grupo is not null)
                condiciones.Add($" U.grupo = @grupo");
            if(tipoAsistencia is not null)
                condiciones.Add($" A.presente = @tipoAsistencia");

            if (condiciones.Count > 0)
                consulta += " WHERE " + string.Join(" AND ", condiciones);

            SqlCommand comando = new SqlCommand(consulta, coneccion);
            
            // Se incluyen los parametros recibidos segun corresponda.
            if (dni is not null)
                comando.Parameters.AddWithValue("@dni", dni);
            if (fechaAsistenciaDesde is not null)
                comando.Parameters.AddWithValue("@fechaAsistenciaDesde", ((DateTime)fechaAsistenciaDesde).Date);
            if (fechaAsistenciaHasta is not null)
                comando.Parameters.AddWithValue("@fechaAsistenciaHasta", ((DateTime)fechaAsistenciaHasta).Date);
            if (grupo is not null)
                comando.Parameters.AddWithValue("@grupo", (int)grupo);
            if (tipoAsistencia is not null)
                comando.Parameters.AddWithValue("@tipoAsistencia", (int)tipoAsistencia);

            try
            {
                coneccion.Open();

                // Se ejeculta el comando
                SqlDataReader retornoSelect = comando.ExecuteReader();

                // Se genera el listado correspondiente
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
                    ETipoCausaIngreso? causaIngreso = Convert.IsDBNull(retornoSelect["causaIngreso"]) ? null : (ETipoCausaIngreso)retornoSelect["causaIngreso"];

                    if(causaIngreso is not null)
                        usuario.ListadoDeDelitos.Add((ETipoCausaIngreso)causaIngreso);

                    Asistencia asistencia = new Asistencia();
                    asistencia.Usuario = usuario;
                    asistencia.Fecha = Convert.ToDateTime(retornoSelect["fechaAsistencia"].ToString());
                    asistencia.Grupo = (EGrupo)retornoSelect["grupoAsistencia"];
                    asistencia.Presente = (ETipoAsistencia)retornoSelect["presente"];

                    Asistencia retornoAsistencia = listaRetorno.Find(asistenciaRetorno => asistenciaRetorno.Equals(asistencia));

                    if (retornoAsistencia is not null && causaIngreso is not null) 
                    {
                        retornoAsistencia.Usuario.ListadoDeDelitos.Add((ETipoCausaIngreso)causaIngreso);
                    }
                    else
                    {
                        listaRetorno.Add(asistencia);
                    }
                }

                return listaRetorno;
            }
            finally
            {
                coneccion.Close();
            }
        }
    }
}

using EntidadesAsociacion.Excepciones.Genericas;
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
    public class TurnoDB
    {
        /// <summary>
        /// Método ecargado de insertar un turno a la base de datos (tabla turnos)
        /// </summary>
        /// <param name="turno">Turno a insertar</param>
        /// <returns>Cantidad de registros insertados</returns>
        public static int Insertar(Turno turno)
        {
            string strComando;
            SqlConnection coneccion = DB.Coneccion;
            SqlCommand comando = new SqlCommand();
            comando.Connection = coneccion;

            strComando = "INSERT INTO " +
                "[TPFinal_EvelynYanez].[dbo].[turnos] " +
                    " (turno, estado, fecha) " +
                "VALUES " +
                    $"({(turno.Grupo is not null ? (int)turno.Grupo : "NULL")}, {(turno.Estado ? 1 : 0)} , CONVERT(datetime, '{turno.Fecha.Date}', 103));";

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
        /// Método encargado de actualizar un turno en la base de datos.
        /// Este cambiara el estado del turno de la base al recibido por parametros
        /// Buscandolo por fecha de turno
        /// </summary>
        /// <param name="turno">Turno a actualizar con nuevo estado</param>
        /// <returns>Cantidad de registros afectados</returns>
        public static int Actualizar(Turno turno)
        {
            string strComando;
            SqlConnection coneccion = DB.Coneccion;
            SqlCommand comando = new SqlCommand();
            comando.Connection = coneccion;

            strComando = "UPDATE [TPFinal_EvelynYanez].[dbo].[turnos] " +
                $" SET estado = {(turno.Estado ? 1 : 0)} " +
                $" WHERE" +
                    $" fecha = CONVERT(datetime, '{turno.Fecha}', 103);";

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
        /// Método encargado de buscar un turno en la base de datos
        /// </summary>
        /// <param name="fecha">Fecha del turno a buscar</param>
        /// <returns>Cantidad de registros afectados</returns>
        /// <exception cref="NoEncontrado">Excepcion arrojada cuando no se encunetre un turno para la fecha pasada por parametro</exception>
        public static Turno Buscar(DateTime fecha)
        {
            string consulta = "";
            Turno turnoRetorno = null;

            SqlConnection coneccion = DB.Coneccion;

            consulta += " " +
                "SELECT " +
                    " turno, " +
                    " estado, " +
                    " fecha " +
                "FROM " +
                    "[TPFinal_EvelynYanez].[dbo].[turnos] " +
                "WHERE fecha = CONVERT(datetime, @fecha, 103);";

            SqlCommand comando = new SqlCommand(consulta, coneccion);

            comando.Parameters.AddWithValue("@fecha", fecha.Date);

            try
            {
                coneccion.Open();

                SqlDataReader retornoSelect = comando.ExecuteReader();
                while (retornoSelect.Read())
                {
                    turnoRetorno = new Turno(Convert.ToDateTime(retornoSelect["fecha"].ToString()), (EGrupo)retornoSelect["turno"], (bool)retornoSelect["estado"]);
                }

                return turnoRetorno;
            }
            finally
            {
                coneccion.Close();
            }
        }
        
        /// <summary>
        /// Método ecargado de buscar el último turno cerrado
        /// </summary>
        /// <returns>Instancia del último turno cerrado</returns>
        public static Turno BuscarUltimoTurnoCerrado()
        {
            string consulta = "";
            Turno turnoRetorno = null;

            SqlConnection coneccion = DB.Coneccion;

            consulta += " " +
                "SELECT TOP(1) " +
                    " turno, " +
                    " estado, " +
                    " fecha " +
                "FROM " +
                    "[TPFinal_EvelynYanez].[dbo].[turnos] " +
                "WHERE estado = 1 "+
                " ORDER BY fecha DESC ;";

            SqlCommand comando = new SqlCommand(consulta, coneccion);

            try
            {
                coneccion.Open();

                SqlDataReader retornoSelect = comando.ExecuteReader();
                while (retornoSelect.Read())
                {
                    turnoRetorno = new Turno(Convert.ToDateTime(retornoSelect["fecha"].ToString()), (EGrupo)retornoSelect["turno"], (bool)retornoSelect["estado"]);
                }

                return turnoRetorno;
            }
            finally
            {
                coneccion.Close();
            }
        }

        /// <summary>
        /// Método ecargado de buscar el turno que se encuentra abierto
        /// </summary>
        /// <returns>Instancia del turno que se encuentra abierto</returns>
        public static Turno BuscarTurnoAbierto()
        {
            string consulta = "";
            Turno turnoRetorno = null;

            SqlConnection coneccion = DB.Coneccion;

            consulta += " " +
                "SELECT " +
                    " turno, " +
                    " estado, " +
                    " fecha " +
                "FROM " +
                    "[TPFinal_EvelynYanez].[dbo].[turnos] " +
                "WHERE estado = 0;";

            SqlCommand comando = new SqlCommand(consulta, coneccion);

            try
            {
                coneccion.Open();

                SqlDataReader retornoSelect = comando.ExecuteReader();
                while (retornoSelect.Read())
                {
                    EGrupo? grupo = Convert.IsDBNull(retornoSelect["turno"]) ? null : (EGrupo)retornoSelect["turno"];
                    turnoRetorno = new Turno(Convert.ToDateTime(retornoSelect["fecha"].ToString()), grupo, (bool)retornoSelect["estado"]);
                }

                return turnoRetorno;
            }
            finally
            {
                coneccion.Close();
            }
        }
    }
}

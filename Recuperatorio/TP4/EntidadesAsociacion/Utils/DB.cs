using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAsociacion.Utils
{
    public static class DB
    {
        static string strConeccion;

        /// <summary>
        /// Constructor estatico de DB
        /// Inicializa el string de la coneccion con valor 
        ///  @"Server=.\SQLEXPRESS;Database=TPFinal_EvelynYanez;Trusted_Connection=True;"
        ///  por defecto
        /// </summary>
        static DB()
        {
            strConeccion = @"Server=.\SQLEXPRESS;Database=TPFinal_EvelynYanez;Trusted_Connection=True;";
        }

        /// <summary>
        /// Propiedad encargada de generar una nueva coneccion a la base de datos
        /// </summary>
        public static SqlConnection Coneccion
        {
            get { return new SqlConnection(DB.strConeccion); }
        }

    }
}

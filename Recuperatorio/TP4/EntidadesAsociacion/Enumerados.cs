using System.ComponentModel;

namespace EntidadesAsociacion
{
    public class Enumerados
    {
        /// <summary>
        /// Enumerado conrrespondiente a los tipos de asistencia (presencialidad)
        /// </summary>
        public enum ETipoAsistencia
        {
            [Description("Ausente")]
            Ausente,
            [Description("Ausente Con Aviso")]
            AusenteConAviso,
            [Description("Feriado")]
            Feriado,
            [Description("Presente")]
            Presente
        }

        /// <summary>
        /// Enumerado correpsondiente a los tipos de causas de ingreso
        /// </summary>
        public enum ETipoCausaIngreso
        {
            [Description("Delito Sexual")]
            DelitoSexual,
            [Description("Maltrato Y Abuso Infantil")]
            MaltratoYAbusoInfantil,
            [Description("Violencia Domestica")]
            ViolenciaDomestica
        }

        /// <summary>
        /// Enumerado correpsondiente a los grupos de trabajo
        /// </summary>
        public enum EGrupo
        {
            Lunes,
            Martes,
            Miercoles,
            Jueves,
            Viernes
        }

        /// <summary>
        /// Enumerado correpsondiente a los tipos de extensiones de los archivos
        /// </summary>
        public enum ETipoExtension
        {
            Txt,
            Csv,
            Json,
            Xml
        }

        /// <summary>
        /// Enumerado correspondiente a los tipos de personas de la aplicacion
        /// </summary>
        public enum ETipoPersona
        {
            Usuario,
            Empleado,
            Administrador
        }
    }
}

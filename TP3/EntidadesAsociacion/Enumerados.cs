namespace EntidadesAsociacion
{
    public class Enumerados
    {
        /// <summary>
        /// Enumerado conrrespondiente a los tipos de asistencia (presencialidad)
        /// </summary>
        public enum ETipoAsistencia
        {
            Ausente,
            AusenteConAviso,
            Feriado,
            Presente
        }

        /// <summary>
        /// Enumerado correpsondiente a los tipos de causas de ingreso
        /// </summary>
        public enum ETipoCausaIngreso
        {
            DelitoSexual,
            MaltratoYAbusoInfantil,
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

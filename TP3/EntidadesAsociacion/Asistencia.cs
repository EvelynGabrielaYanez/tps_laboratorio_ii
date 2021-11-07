using EntidadesAsociacion.Interfaces;
using System;
using System.Text;
using static EntidadesAsociacion.Enumerados;

namespace EntidadesAsociacion
{
    public class Asistencia : ICsv
    {
        private Usuario usuario;
        private DateTime fecha;
        private EGrupo grupo;
        private ETipoAsistencia presente;

        public Asistencia()
        {
        }

        /// <summary>
        /// Método constructor de una asistencia.
        /// </summary>
        /// <param name="usuario">Usuario que corresponde a la asistencia</param>
        /// <param name="fecha">Fecha en la que asistio</param>
        /// <param name="grupo">Grupo al que asistio</param>
        /// <param name="presente">Tipo de asistencia que tuvo (presente, austene, ausente con aviso, feriado)</param>
        public Asistencia(Usuario usuario, DateTime fecha, EGrupo grupo, ETipoAsistencia presente)
        {
            this.usuario = usuario;
            this.fecha = fecha;
            this.grupo = grupo;
            this.presente = presente;
        }

        /// <summary>
        /// Propiedad de lectura y escritura del usuario que corresponde a la asistencia
        /// </summary>
        public Usuario Usuario
        {
            get { return this.usuario; }
            set { this.usuario = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del Dni del usuario
        /// </summary>
        public int DniUsuario
        {
            get { return this.usuario.Dni; }
            set { this.usuario.Dni = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura de la fecha de asistencia
        /// </summary>
        public DateTime Fecha
        {
            get { return this.fecha; }
            set { this.fecha = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del grupo al que corresponde la asistencia
        /// </summary>
        public EGrupo Grupo
        {
            get { return this.grupo; }
            set { this.grupo = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del estado de la presencialidad (presente, austene, ausente con aviso, feriado)
        /// </summary>
        public ETipoAsistencia Presente
        {
            get { return this.presente; }
            set { this.presente = value; }
        }

        /// <summary>
        /// Método encargado de separar los valroes de las propiedades del objeto por coma y retornar el string correspondiente  a la concatenacion de los mismos.
        /// </summary>
        /// <returns>Cadena con los valores de las prpiedades concatenados y separados por comas</returns>
        public string ToStringSeparadoPorComa()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(usuario.ToStringSeparadoPorComa());
            sb.Append(";");
            sb.Append(fecha.ToString());
            sb.Append(";");
            sb.Append(grupo.ToString());
            sb.Append(";");
            sb.Append(presente.ToString());
            return sb.ToString();
        }

        /// <summary>
        /// Sobrescritura del método ToString()
        /// Método encargado de generar una cadena con todas las propiedadees y valores de la persona.
        /// </summary>
        /// <returns>Cadena con todas las propiedades y valores de la persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Usuario:{this.usuario}");
            sb.AppendLine($"Fecha: {this.fecha}");
            sb.AppendLine($"Presente: {this.presente}");
            sb.AppendLine($"Grupo: {this.grupo}");

            return sb.ToString();
        }

        /// <summary>
        /// Método encargado de generar un string que contenga los nombres de las pripiedades de un objeto concatenados con ";".
        /// </summary>
        /// <returns>string de los nombres de las pripiedades de un objeto concatenados con ";".</returns>
        public string ObtenerCabezeraDeColumnas()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(usuario.ObtenerCabezeraDeColumnas());
            sb.Append(";");
            sb.Append("Fecha");
            sb.Append(";");
            sb.Append("Grupo");
            sb.Append(";");
            sb.Append("Pesente");
            return sb.ToString();
        }

        /// <summary>
        /// Sobrescritura del operador ==
        /// Se considerara que dos asistencias son iguales si ninguna de las dos es nula, poseen la misma fecha de asistencia y corresponden al mismo usuario
        /// </summary>
        /// <param name="asistencia1">Primer asistencia a comparar</param>
        /// <param name="asistencia2">Segunda asistencia a comparar</param>
        /// <returns>true = son iguales | false = son distintas</returns>
        public static bool operator ==(Asistencia asistencia1, Asistencia asistencia2)
        {
            return asistencia1 is not null && asistencia2 is not null && asistencia1.Fecha.Date == asistencia2.Fecha.Date && asistencia1.usuario.Equals(asistencia2.usuario);
        }

        /// <summary>
        /// Sobrescritura del operador !=
        /// Se considerara que dos asistencias son distintas si alguna de las dos es nula o poseen distinta fecha de asistencia o corresponden al disntintos usuario
        /// </summary>
        /// <param name="asistencia1">Primer asistencia a comparar</param>
        /// <param name="asistencia2">Segunda asistencia a comparar</param>
        /// <returns>false = son iguales | true = son distintas</returns>
        public static bool operator !=(Asistencia asistencia1, Asistencia asistencia2)
        {
            return !(asistencia1 == asistencia2);
        }

        /// <summary>
        /// Sobrescritura del metodo equals.
        /// Considerara que el objeto pasado por parametro es igual a la instancia cuando este sea del tipo Asistencia,
        /// no sea nulo, posea la misma fecha de asistencia y mismo usuario que la instancia.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is Asistencia && (Asistencia)obj == this;
        }

        /// <summary>
        /// Sobrescritura del método GetHashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

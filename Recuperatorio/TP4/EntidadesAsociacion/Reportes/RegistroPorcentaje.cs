using EntidadesAsociacion.Interfaces;
using System.Text;

namespace EntidadesAsociacion.Reportes
{
    public class RegistroPorcentaje : ICsv
    {
        int cantidad;
        double porcentaje;
        string intervalo;

        /// <summary>
        /// Método constructor de un registro por porcentaje
        /// </summary>
        public RegistroPorcentaje()
        {
            this.porcentaje = 0;
            this.cantidad = 0;

        }

        /// <summary>
        /// Método constructor de un registro por porcentaje
        /// </summary>
        /// <param name="intervalo">Intervalo al que correspondnde el registro por porcentaje</param>
        public RegistroPorcentaje(string intervalo) : this()
        {
            this.intervalo = intervalo;
        }

        /// <summary>
        /// Método constructor de un registro por porcentaje
        /// </summary>
        /// <param name="cantidad">Cantidad contabilizada para el intervalo</param>
        /// <param name="porcentaje">Porcentaje que representa la cantidad respecto al total a analizar</param>
        /// <param name="intervalo">Intervalo al que correspondnde el registro por porcentaje</param>
        public RegistroPorcentaje(int cantidad, double porcentaje, string intervalo) : this(intervalo)
        {
            this.cantidad = cantidad;
            this.porcentaje = porcentaje;
        }

        /// <summary>
        /// Propiedad de lectura y escritura del intervalo a analizar
        /// </summary>
        public string Intervalo
        {
            get { return this.intervalo; }
            set { this.intervalo = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura de la cantidad de objetos que pertenecen al intervalo
        /// </summary>
        public int Cantidad
        {
            get { return this.cantidad; }
            set { this.cantidad = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del porcentaje que representa la cantidad respecto al total a analizar
        /// </summary>
        public double Porcentaje
        {
            get { return this.porcentaje; }
            set { this.porcentaje = value; }
        }

        /// <summary>
        /// Método encargado de separar los valroes de las propiedades del objeto por coma y retornar el string correspondiente  a la concatenacion de los mismos.
        /// </summary>
        /// <returns>Cadena con los valores de las prpiedades concatenados y separados por comas</returns>
        public string ToStringSeparadoPorComa()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.intervalo.ToString());
            sb.Append(";");
            sb.Append(this.cantidad.ToString());
            sb.Append(";");
            sb.Append(this.porcentaje.ToString());
            return sb.ToString();
        }

        /// <summary>
        /// Sobrescritura del método ToString()
        /// Método encargado de generar una cadena con todas las propiedadees y valores del registro por porcentaje.
        /// </summary>
        /// <returns>Cadena con todas las propiedades y valores del registro por porcentaje.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Intervalo: {this.intervalo}");
            sb.AppendLine($"Cantidad: {this.cantidad}");
            sb.AppendLine($"Porcentaje: {this.porcentaje}");
            return sb.ToString();
        }

        /// <summary>
        /// Método encargado de generar un string que contenga los nombres de las pripiedades de un objeto concatenados con ";".
        /// </summary>
        /// <returns>string de los nombres de las pripiedades de un objeto concatenados con ";".</returns>
        public string ObtenerCabezeraDeColumnas()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Intervalo");
            sb.Append(";");
            sb.Append("Cantidad");
            sb.Append(";");
            sb.Append("Porcentaje");
            return sb.ToString();
        }
    }
}

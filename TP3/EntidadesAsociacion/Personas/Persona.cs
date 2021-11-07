using System.Text;

namespace EntidadesAsociacion
{
    public abstract class Persona
    {
        string nombre;
        string apellido;
        protected int dni;

        /// <summary>
        /// Método constructor de una persona
        /// </summary>
        public Persona()
        {
        }

        /// <summary>
        /// Método constructor deuna persona
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="dni">Dni de la persona</param>
        protected Persona(string nombre, string apellido, int dni)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
        }

        /// <summary>
        /// Prpiedad de lectura y escritura del atributo nombre de la persona
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        /// <summary>
        /// Prpiedad de lectura y escritura del atributo apellido de la persona
        /// </summary>
        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = value; }
        }

        /// <summary>
        /// Prpiedad de lectura y escritura del atributo dni de la persona
        /// </summary>
        public int Dni
        {
            get { return this.dni; }
            set { this.dni = value; }
        }

        /// <summary>
        /// Método encargado de validar que el DNI pasado por parametro
        /// tenga un largo entre 8 y 6 caractere y que el mismo sea númerico.
        /// </summary>
        /// <param name="strDni"></param>
        /// <returns>true = Valido | false = Invalido</returns>
        public static bool ValidarDNI(string strDni)
        {
            if (strDni.Length <= 8 && strDni.Length >= 6)
            {
                return int.TryParse(strDni, out _);
            }
            return false;
        }

        /// <summary>
        /// Sobrescritura del método ToString()
        /// Método encargado de generar una cadena con todas las propiedadees y valores de la persona.
        /// </summary>
        /// <returns>Cadena con todas las propiedades y valores de la persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"DNI: {this.dni}");
            sb.AppendLine($"Nombre: {this.nombre}");
            sb.AppendLine($"Apellido: {this.apellido}");

            return sb.ToString();
        }
    }
}

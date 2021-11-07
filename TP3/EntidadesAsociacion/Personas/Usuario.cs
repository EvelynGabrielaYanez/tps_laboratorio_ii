using EntidadesAsociacion.Interfaces;
using EntidadesAsociacion.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using static EntidadesAsociacion.Enumerados;

namespace EntidadesAsociacion
{
    public class Usuario : Persona, ICsv
    {
        DateTime fechaIngreso;
        List<ETipoCausaIngreso> listadoDeDelitos;
        int denunciasRegistradas;
        int numeroTelefonico;
        bool activo;
        EGrupo grupo;

        /// <summary>
        /// Método consturctor de un Usuario
        /// </summary>
        public Usuario() : base()
        {
        }

        /// <summary>
        /// Método constructor de un Usuario
        /// </summary>
        /// <param name="nombre">Nombre del Usuario</param>
        /// <param name="apellido">Apellido del Usuario</param>
        /// <param name="dni">Dni del Usuairo</param>
        protected Usuario(string nombre, string apellido, int dni) : base(nombre, apellido, dni)
        {
            this.activo = true;
        }

        /// <summary>
        /// Método constructor de un Usuario
        /// </summary>
        /// <param name="nombre">Nombre del Usuario</param>
        /// <param name="apellido">Apellido del Usuario</param>
        /// <param name="dni">Dni del Usuairo</param>
        /// <param name="fechaIngreso">Fecha de ingreso del Usuario</param>
        /// <param name="grupo">Grupo al que asiste el usuario</param>
        /// <param name="denunciasRegistradas">Cantidad de denuncias realizadas a el usuario</param>
        /// <param name="numeroTelefonico">Número telefonico del usuario o un contacto</param>
        /// <param name="listadoDeDelitos">Listado de causas de ingreso</param>
        public Usuario(string nombre, string apellido, int dni, DateTime fechaIngreso, EGrupo grupo, int denunciasRegistradas, int numeroTelefonico, List<ETipoCausaIngreso> listadoDeDelitos) : this(nombre, apellido, dni)
        {
            this.fechaIngreso = fechaIngreso;
            this.grupo = grupo;
            this.denunciasRegistradas = denunciasRegistradas;
            this.numeroTelefonico = numeroTelefonico;
            this.listadoDeDelitos = listadoDeDelitos;
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo fechaDeIngreso del usuario
        /// </summary>
        public DateTime FechaIngreso
        {
            get { return this.fechaIngreso; }
            set { this.fechaIngreso = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo listadoDeDelitos del usuario
        /// </summary>
        public List<ETipoCausaIngreso> ListadoDeDelitos
        {
            get { return this.listadoDeDelitos; }
            set { this.listadoDeDelitos = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo denunciasRegistradas del usuario
        /// </summary>
        public int DenunciasRegistradas
        {
            get { return this.denunciasRegistradas; }
            set { this.denunciasRegistradas = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo numeroTelefonico del usuario
        /// </summary>
        public int NumeroTelefonico
        {
            get { return this.numeroTelefonico; }
            set { this.numeroTelefonico = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo activo del usuario
        /// </summary>
        public bool Activo
        {
            get { return this.activo; }
            set { this.activo = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo grupo del usuario
        /// </summary>
        public EGrupo Grupo
        {
            get { return this.grupo; }
            set { this.grupo = value; }
        }

        /// <summary>
        /// Método encargado de separar los valroes de las propiedades del objeto por coma y retornar el string correspondiente  a la concatenacion de los mismos.
        /// </summary>
        /// <returns>Cadena con los valores de las prpiedades concatenados y separados por comas</returns>
        public string ToStringSeparadoPorComa()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.Nombre);
            sb.Append(";");
            sb.Append(this.Apellido);
            sb.Append(";");
            sb.Append(this.Dni);
            sb.Append(";");
            sb.Append(this.FechaIngreso);
            sb.Append(";");
            List<string> stringDelitos = new List<string>();
            foreach (ETipoCausaIngreso causaIngreso in this.ListadoDeDelitos)
            {
                stringDelitos.Add(causaIngreso.ToString());
            }
            sb.Append(string.Join(" - ", stringDelitos));
            sb.Append(";");
            sb.Append(this.denunciasRegistradas);
            sb.Append(";");
            sb.Append(this.NumeroTelefonico);
            sb.Append(";");
            sb.Append(this.Activo ? "SI" : "NO");

            return sb.ToString();
        }


        /// <summary>
        /// Método encargado de generar un string que contenga los nombres de las pripiedades de un objeto concatenados con ";".
        /// </summary>
        /// <returns>string de los nombres de las pripiedades de un objeto concatenados con ";".</returns>
        public string ObtenerCabezeraDeColumnas()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Nombre");
            sb.Append(";");
            sb.Append("Apellido");
            sb.Append(";");
            sb.Append("DNI");
            sb.Append(";");
            sb.Append("Fecha De Ingreso");
            sb.Append(";");
            sb.Append("Causas de Ingreso");
            sb.Append(";");
            sb.Append("Cantidad de denuncias registradas");
            sb.Append(";");
            sb.Append("Número telefonico");
            sb.Append(";");
            sb.Append("Activo");

            return sb.ToString();
        }

        /// <summary>
        /// Sobrescritura del método ToString()
        /// Método encargado de generar una cadena con todas las propiedadees y valores del Usuario.
        /// </summary>
        /// <returns>Cadena con todas las propiedades y valores de la persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.Append($"Grupo: {this.grupo}");
            sb.Append($"Fecha de ingreso: {this.fechaIngreso}");
            sb.Append($"Motivos de Ingreso: {this.listadoDeDelitos.Mostar()}");
            sb.Append($"Cantidad de denunciar registradas: {this.denunciasRegistradas}");
            sb.Append($"Número telefonico: {this.numeroTelefonico}");

            return base.ToString();
        }

        /// <summary>
        /// Método encargado de validar si el usuario contiene las causas de ingreso pasadas por parametro
        /// </summary>
        /// <param name="filtroCausaDeIngreso">Listado de causas de ingreso a validar</param>
        /// <returns>true = contiene las cuasas de ingreso | false = no contiene al menos una de las causas de ingreso</returns>
        public bool ValidarLasCausaDeIngreso(List<ETipoCausaIngreso> causasDeIngreso)
        {
            bool retorno = true;
            foreach (ETipoCausaIngreso causaDeIngresoAValidar in causasDeIngreso)
            {
                if (!this.listadoDeDelitos.Contains(causaDeIngresoAValidar))
                {
                    retorno = false;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Sobrescritura del operador ==.
        /// Dos usuarios se consideraran iguales si poseen el mismo número de dni
        /// </summary>
        /// <param name="usuario1">Primer usuario a comparar</param>
        /// <param name="usuario2">Segundo usuario a comparar</param>
        /// <returns>true = son iguales | false = no son iguales</returns>
        public static bool operator ==(Usuario usuario1, Usuario usuario2)
        {
            return usuario1.Dni == usuario2.Dni;
        }

        /// <summary>
        /// Sobrescritura del operador !=.
        /// Dos usuarios se consideraran distrintos si poseen distinto número de dni
        /// </summary>
        /// <param name="usuario1">Primer usuario a comparar</param>
        /// <param name="usuario2">Segundo usuario a comparar</param>
        /// <returns>false = son iguales | true = no son iguales</returns>
        public static bool operator !=(Usuario usuario1, Usuario usuario2)
        {
            return !(usuario1 == usuario2);
        }

        /// <summary>
        /// Método encargado de comparar el usuario con el objeto pasado por parametro.
        /// Se consideraran iguales cuando el objeto pasado sea de la clase usuario y 
        /// tenga el mismo número de dni que la instacia del usuario.
        /// </summary>
        /// <param name="obj">objeto a comparar</param>
        /// <returns>true = son iguales | false = no son iguales</returns>
        public override bool Equals(object obj)
        {
            return obj is Usuario && (Usuario)obj == this;
        }

        /// <summary>
        /// Sobrescritura del método gethashcode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

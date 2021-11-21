using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EntidadesAsociacion.Enumerados;

namespace EntidadesAsociacion
{
    public class Turno
    {
        DateTime fecha;
        EGrupo? grupo;
        bool estado;

        /// <summary>
        /// Método constructor de un turno
        /// </summary>
        /// <param name="fecha">Fecha a la que corresponde un turno</param>
        /// <param name="grupo">Grupo que opero en la fecha</param>
        /// <param name="estado">Estado del turno (true = cerrado | false = abierto)</param>
        public Turno(DateTime fecha, EGrupo? grupo, bool estado)
        {
            this.fecha = fecha;
            this.grupo = grupo;
            this.estado = estado;
        }

        /// <summary>
        /// Propiedad de solo lectura de la fecha a la que corresponde el turno
        /// </summary>
        public DateTime Fecha
        {
            get { return this.fecha; }
        }

        /// <summary>
        /// Propiedad de sólo lectura correspondiente al grupo que opero en el turno
        /// </summary>
        public EGrupo? Grupo
        {
            get { return this.grupo; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura correpsondiete al estado del turno (true = cerrado | false = abierto)
        /// </summary>
        public bool Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }
    }
}

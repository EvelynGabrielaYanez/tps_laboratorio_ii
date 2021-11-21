using System;
using System.Collections.Generic;
using static EntidadesAsociacion.Enumerados;

namespace EntidadesAsociacion.CierreTurno
{
    public class InfoCierreTurno: EventArgs
    {
        Turno turno;
        List<Usuario> usuariosAsisnenciaFaltante;

        /// <summary>
        /// Método cosntructor de InfoCierreTurno.
        /// Inicializara el listado de usuarios que tienen registros de asistencia faltantes en el turno como un listado vacio.
        /// </summary>
        /// <param name="turno">Turno al que corresponde el cierre de turno</param>
        public InfoCierreTurno(Turno turno)
        {
            this.turno = turno;
            this.usuariosAsisnenciaFaltante = new List<Usuario>();
        }

        /// <summary>
        /// Método constructor de InfoCierreTurno.
        /// </summary>
        /// <param name="turno">Turno alq ue corresponde el cierre de turno</param>
        /// <param name="usuariosAsisnenciaFaltante">Listado de usuarios a los que les faltan registros de asistencia en el turno</param>
        public InfoCierreTurno(Turno turno, List<Usuario> usuariosAsisnenciaFaltante)
        {
            this.turno = turno;
            this.usuariosAsisnenciaFaltante = usuariosAsisnenciaFaltante;
        }

        /// <summary>
        /// Propiedad de sólo lectura que retorna el turno correspondiente a la información del cierre de turno
        /// </summary>
        public Turno Turno
        {
            get { return this.turno; }
        }

        /// <summary>
        /// Propiedad de sólo lecutra que corresponde al listado de usuarios a los que les faltan registros de asistencias en el turno
        /// </summary>
        public List<Usuario> UsuariosAsisnenciaFaltante
        {
            get { return this.usuariosAsisnenciaFaltante; }
        }

    }
}

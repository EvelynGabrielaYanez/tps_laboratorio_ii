using EntidadesAsociacion.Controladores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static EntidadesAsociacion.Enumerados;

namespace EntidadesAsociacion.CierreTurno
{
    public class CierreTurno
    {
        Turno turno;

        public delegate void CierreApeturaTurno(object sender, InfoCierreTurno info);
        public event CierreApeturaTurno CambioTurno;
        public event CierreApeturaTurno AsistenciasFaltantes;

        /// <summary>
        /// Método constructor de un turno
        /// </summary>
        public CierreTurno()
        {
            turno = TurnoControlador.BuscarTurnoAbierto();
            if (turno is null)
                turno = TurnoControlador.BuscarUltimoTurnoCerrado();
        }

        /// <summary>
        /// Método encargado de ejecutar la tarea encargada de realizr el cierre de turnos.
        /// Esta tarea se correra cada dos segundos y validara si puede o no cerrar el turno
        /// disparando el evento de falta de cargas de asistencias en caso de que corresponda
        /// </summary>
        /// <param name="tokenDeCancelacion">Token de cancelacion de la tarea</param>
        public async void ControlarCierre(CancellationTokenSource tokenDeCancelacion)
        {
            await Task.Run(() => this.ValidarYCerrarTurno(tokenDeCancelacion));
        }

        /// <summary>
        /// Método encargado de realizar el cierre de turnos.
        /// Esta tarea se correra cada dos segundos  y validara si puede o no cerrar el turno
        /// disparando el evento de falta de cargas de asistencias en caso de que corresponda
        /// </summary>
        /// <param name="tokenDeCancelacion"></param>
        public void ValidarYCerrarTurno(CancellationTokenSource tokenDeCancelacion)
        {
            while (true)
            {

                if (tokenDeCancelacion.IsCancellationRequested)
                    break;

                // Valido si es una fecha activa
                if (this.turno is null)
                {
                    Turno nuevoTurno = new Turno(DateTime.Now, Asociacion.ObtenerGrupoPorFecha(DateTime.Now), false);
                    TurnoControlador.Insertar(nuevoTurno);
                    this.turno = nuevoTurno;
                }
                else
                {
                    // Valida si el turno es igual a la fecha actual. En tal caso no se cerrara el dia.
                    if (this.turno.Fecha.Date == DateTime.Now.Date)
                        continue;

                    if (this.turno.Grupo is not null)
                    {
                        // Valida si se encunetran todas las asistencias cargadas
                        List<Usuario> listadoUsuariosFaltantes = UsuarioControlador.BuscarUsuariosSinAsistencia((EGrupo)this.turno.Grupo, turno.Fecha);
                        if (listadoUsuariosFaltantes.Count > 0)
                        {
                            AsistenciasFaltantes.Invoke(this, new InfoCierreTurno(this.turno, listadoUsuariosFaltantes));
                        }
                        else
                        {
                            this.CerrarTurno();
                        }
                    }
                    else
                    {
                        this.CerrarTurno();
                    }
                }

                Thread.Sleep(2000);
            }
        }

        /// <summary>
        /// Método encargado de realizar el cierre de un turno y la apertura del siguiente.
        /// </summary>
        public void CerrarTurno()
        {
            // Realiza el cierre del turno actual
            this.turno.Estado = true;
            TurnoControlador.Actualizar(this.turno);
            DateTime nuevaFecha = this.turno.Fecha.AddDays(1);
            // Se abre un turno nuevo
            Turno nuevoTurno = new Turno(nuevaFecha, Asociacion.ObtenerGrupoPorFecha(nuevaFecha), false);
            TurnoControlador.Insertar(nuevoTurno);
            this.turno = nuevoTurno;
            CambioTurno.Invoke(this, new InfoCierreTurno(nuevoTurno));
        }
    }
}

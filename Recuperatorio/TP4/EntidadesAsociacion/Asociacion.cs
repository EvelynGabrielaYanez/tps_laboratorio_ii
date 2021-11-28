using EntidadesAsociacion.Controladores;
using System;
using System.Collections.Generic;
using System.Globalization;
using static EntidadesAsociacion.Enumerados;

namespace EntidadesAsociacion
{
    public static class Asociacion
    {
        static List<Empleado> listaEmpleados;

        /// <summary>
        /// Constructor estatico de la asociacion.
        /// Inicializa las listas y hardcodea empleados y usuarios.
        /// </summary>
        static Asociacion()
        {
            //Asociacion.listaUsuarios = new List<Usuario>();
            Asociacion.listaEmpleados = new List<Empleado>();
            //Asociacion.listadoAsistencias = new List<Asistencia>();
            Asociacion.HardCodeoEmpleados();
            Asociacion.HardCodeoUsuarios();
        }
        /// <summary>
        /// Prpiedad de lectura del listado de empelados de la asociacion
        /// </summary>
        public static List<Empleado> ListaEmpleados
        {
            get { return Asociacion.listaEmpleados; }
        }

        /// <summary>
        /// Método encargado de hardcodear un listado de empleados
        /// </summary>
        private static void HardCodeoEmpleados()
        {
            listaEmpleados = new List<Empleado>()
            {
              { new Empleado("nombreEmpleado1", "apellidoEmpelado1", 39429755, "empleado1", "contra1234") },
              { new Empleado("nombreEmpleado2", "apellidoEmpelado2", 39429756, "empleado2", "senia5678") },
              { new Empleado("nombreEmpleado3", "apellidoEmpelado3", 39429757, "empleado3", "emplea123") },
              { new Administrador("nombreAdmin1", "apellidoAdmin1", 39429758, "admin1", "admin123") },
              { new Administrador("nombreAdmin2", "apellidoAdmin2", 39429759, "admin2", "admin456") }
            };
        }

        /// <summary>
        /// Método encargado de hardcodear un listado de usuarios
        /// </summary>
        private static void HardCodeoUsuarios()
        {
            Usuario usuario1 = new Usuario("nombreUsuario1", "apellidoUsuario1", 31429766, Convert.ToDateTime("01/07/2021"), EGrupo.Viernes, 2, 1566429774, new List<ETipoCausaIngreso>() { ETipoCausaIngreso.DelitoSexual });
            Usuario usuario2 = new Usuario("nombreUsuario2", "apellidoUsuario2", 34429765, Convert.ToDateTime("01/08/2021"), EGrupo.Martes, 1, 1566439685, new List<ETipoCausaIngreso>() { ETipoCausaIngreso.DelitoSexual, ETipoCausaIngreso.ViolenciaDomestica });
            Usuario usuario3 = new Usuario("nombreUsuario3", "apellidoUsuario3", 39429767, Convert.ToDateTime("01/09/2021"), EGrupo.Miercoles, 5, 1566439685, new List<ETipoCausaIngreso>() { ETipoCausaIngreso.ViolenciaDomestica });
            Usuario usuario4 = new Usuario("nombreUsuario4", "apellidoUsuario4", 36429768, Convert.ToDateTime("03/04/2021"), EGrupo.Miercoles, 10, 1578423714, new List<ETipoCausaIngreso>() { ETipoCausaIngreso.DelitoSexual, ETipoCausaIngreso.MaltratoYAbusoInfantil });
            Usuario usuario5 = new Usuario("nombreUsuario4", "apellidoUsuario4", 39429112, Convert.ToDateTime("03/05/2021"), EGrupo.Viernes, 10, 1578423714, new List<ETipoCausaIngreso>() { ETipoCausaIngreso.DelitoSexual, ETipoCausaIngreso.MaltratoYAbusoInfantil });
            Usuario usuario6 = new Usuario("nombreUsuario4", "apellidoUsuario4", 37429444, Convert.ToDateTime("01/09/2021"), EGrupo.Lunes, 10, 1578423714, new List<ETipoCausaIngreso>() { ETipoCausaIngreso.DelitoSexual, ETipoCausaIngreso.MaltratoYAbusoInfantil, ETipoCausaIngreso.ViolenciaDomestica });
            Usuario usuario7 = new Usuario("nombreUsuario4", "apellidoUsuario4", 37429123, Convert.ToDateTime("06/11/2021"), EGrupo.Jueves, 10, 1578423714, new List<ETipoCausaIngreso>() { ETipoCausaIngreso.MaltratoYAbusoInfantil });


        }


        /// <summary>
        /// Método encargado de obtener el tipo de grupo que corresponde segun la fecha actual
        /// </summary>
        /// <returns>
        /// Tipo de grupo correspondietne a la fecha actual.
        /// En caso de no existir un gurpo para el dia correspondiente retorna null
        /// </returns>
        public static EGrupo? ObtenerGrupoPorFecha(DateTime fecha)
        {
            string dia = fecha.ToString("dddd", CultureInfo.CreateSpecificCulture("es-ES"));
            switch (dia.ToLower())
            {
                case "lunes":
                    return EGrupo.Lunes;
                case "martes":
                    return EGrupo.Martes;
                case "miércoles":
                    return EGrupo.Miercoles;
                case "jueves":
                    return EGrupo.Jueves;
                case "viernes":
                    return EGrupo.Viernes;
                default:
                    return null;
            }
        }
    }
}

using EntidadesAsociacion.Excepciones.Usuarios;
using EntidadesAsociacion.Reportes;
using EntidadesAsociacion.Utils;
using System;
using System.Collections.Generic;
using static EntidadesAsociacion.Enumerados;

namespace EntidadesAsociacion.Controladores
{
    public static class UsuarioControlador
    {
        /// <summary>
        /// Método encargado de agregar un usuario el listado de usuarios de la asociación
        /// </summary>
        /// <param name="nuevoUsuario">Usuario a agregar</param>
        /// <returns>true = usuario agregado con éxito | false = el usuario no fue agregado, ya estaba en la lista</returns>
        public static bool AgregarUsuario(Usuario nuevoUsuario)
        {
            bool retorno = true;
            // Valido si el usuario ya esta en la lista y si no esta lo agrego
            foreach (Usuario usuario in Asociacion.ListaUsuarios)
            {
                if (usuario == nuevoUsuario)
                {
                    retorno = false;
                    break;
                }
            }
            if (retorno)
            {
                Asociacion.ListaUsuarios.Add(nuevoUsuario);
            }
            return retorno;
        }

        /// <summary>
        /// Método encargado de filtrar por fecha el listado de usuarios de pasado por parametro. (Se filtra por intervalos que contengan a los extremos)
        /// </summary>
        /// <param name="fechaDesde">Fecha de ingreso desde</param>
        /// <param name="fechaHasta">Fecha de ingreso hasta</param>
        /// <param name="listadoaFiltrar">Listado de Usuarios a filtrar</param>
        /// <returns>Listado de usuarios filtrado</returns>
        public static List<Usuario> FiltrarPorFecha(DateTime fechaDesde, DateTime fechaHasta, List<Usuario> listadoaFiltrar)
        {
            List<Usuario> listadoRetorno = new List<Usuario>();
            if (fechaDesde <= fechaHasta)
            {
                foreach (Usuario usuario in listadoaFiltrar)
                {
                    if (usuario.FechaIngreso.Date >= fechaDesde.Date && usuario.FechaIngreso.Date <= fechaHasta.Date)
                    {
                        listadoRetorno.Add(usuario);
                    }
                }
            }
            return listadoRetorno;
        }

        /// <summary>
        /// Método encargado de filtrar por cantidad de denuncias el listado de usuarios pasado por parametro (Se filtra por intervalos que contengan a los extremos)
        /// </summary>
        /// <param name="denunciasMinimo">Cantidad de denuncias mínimo</param>
        /// <param name="denunciasMaximo">Cantidad de denuncias máximo</param>
        /// <param name="listadoaFiltrar">Listado de usuarios a filtrar</param>
        /// <returns>Listado de usuarios filtrado</returns>
        public static List<Usuario> FiltrarCantidadDenuncias(int denunciasMinimo, int denunciasMaximo, List<Usuario> listadoaFiltrar)
        {
            List<Usuario> listadoRetorno = new List<Usuario>();
            if (denunciasMinimo >= 0 && denunciasMinimo <= denunciasMaximo)
            {
                foreach (Usuario usuario in listadoaFiltrar)
                {
                    if (usuario.DenunciasRegistradas >= denunciasMinimo && usuario.DenunciasRegistradas <= denunciasMaximo)
                    {
                        listadoRetorno.Add(usuario);
                    }
                }
            }
            return listadoRetorno;
        }

        /// <summary>
        /// Método encargado de filtrar por causas de ingreso el listado de usuarios pasado por parametro.
        /// El método retornara aquellos usarios que contengan todas las caisas de ingreso ingresadas en el listado de causas.
        /// </summary>
        /// <param name="filtroCausaDeIngreso">Listado de causas de ingreso</param>
        /// <param name="listadoaFiltrar">Listado de usuarios a filtrar</param>
        /// <returns>Listado de usuarios filtrado</returns>
        public static List<Usuario> FiltrarCausaDeIngreso(List<ETipoCausaIngreso> filtroCausaDeIngreso, List<Usuario> listadoaFiltrar)
        {
            List<Usuario> listadoRetorno = new List<Usuario>();
            if (filtroCausaDeIngreso is not null && filtroCausaDeIngreso.Count > 0)
            {
                foreach (Usuario usuario in listadoaFiltrar)
                {
                    if (usuario.ValidarLasCausaDeIngreso(filtroCausaDeIngreso))
                    {
                        listadoRetorno.Add(usuario);
                    }
                }
            }
            return listadoRetorno;
        }

        /// <summary>
        /// Método encargado de filtrar el listado de usuarios de la asociacion por grupo
        /// </summary>
        /// <param name="grupo">Tipo de grupo por el que se filtrar</param>
        /// <returns>Listado de usuarios filtrado</returns>
        public static List<Usuario> FiltrarPorGrupo(EGrupo grupo)
        {
            List<Usuario> retornoUsuarios = new List<Usuario>();
            foreach (Usuario registro in Asociacion.ListaUsuarios)
            {
                if (grupo == registro.Grupo)
                {
                    retornoUsuarios.Add(registro);
                }
            }
            return retornoUsuarios;
        }

        /// <summary>
        /// Método encargado de calcular el porcentaje de denuncias por intervalos considerando como intervalo de analisis
        /// el pasado por parametros. 
        /// Retronara un listado de registros de porcentaje con los porcentajes correspondientes a cada intervalo.
        /// </summary>
        /// <param name="intevaloDenuncias">Intervalo de cantodad de denuncias</param>
        /// <returns>Listado de registros por porcentaje calculado</returns>
        public static List<RegistroPorcentaje> CalcularPorcentajePorDenuncias(int intevaloDenuncias)
        {
            List<RegistroPorcentaje> listadoRetorno = new List<RegistroPorcentaje>();
            if (intevaloDenuncias <= 0)
            {
                return listadoRetorno;
            }

            int cantidadDeUsuarios = Asociacion.ListaUsuarios.Count;
            if (cantidadDeUsuarios == 0)
            {
                cantidadDeUsuarios = 1;
            }
            int totalRegistrosCalculados = 0;
            for (int i = 1; totalRegistrosCalculados < cantidadDeUsuarios; i++)
            {
                int intervaloDedese = (i - 1) * intevaloDenuncias;
                int intervaloHasta = i * intevaloDenuncias - 1;

                RegistroPorcentaje nuevoRegistro = new RegistroPorcentaje($"{intervaloDedese} a {intervaloHasta}");
                foreach (Usuario registro in Asociacion.ListaUsuarios)
                {
                    if (registro.DenunciasRegistradas >= intervaloDedese && registro.DenunciasRegistradas <= intervaloHasta)
                    {
                        nuevoRegistro.Cantidad++;
                        totalRegistrosCalculados++;
                    }
                }
                nuevoRegistro.Porcentaje = (double)(100 * nuevoRegistro.Cantidad) / cantidadDeUsuarios;
                listadoRetorno.Add(nuevoRegistro);
            }

            return listadoRetorno;
        }

        /// <summary>
        /// Método encargado de calcular el porcentaje de meses transcurridos en la asociacion por intervalos considerando 
        /// como intervalo de analisis el pasado por parametros. 
        /// Retronara un listado de registros de porcentaje con los porcentajes correspondientes a cada intervalo.
        /// </summary>
        /// <param name="intevaloDenuncias">Intervalo de cantodad de meses que el usuario lleva en la asociacion</param>
        /// <returns>Listado de registros por porcentaje calculado</returns>
        public static List<RegistroPorcentaje> CalcularPorcentajesPorMeses(int inteveloMeses)
        {
            List<RegistroPorcentaje> listadoRetorno = new List<RegistroPorcentaje>();
            if (inteveloMeses <= 0)
            {
                return listadoRetorno;
            }

            int cantidadDeUsuarios = Asociacion.ListaUsuarios.Count;
            if (cantidadDeUsuarios == 0)
            {
                cantidadDeUsuarios = 1;
            }
            int totalRegistrosCalculados = 0;
            for (int i = 1; totalRegistrosCalculados < cantidadDeUsuarios; i++)
            {
                int intervaloDedese = (i - 1) * inteveloMeses;
                int intervaloHasta = i * inteveloMeses - 1;

                RegistroPorcentaje nuevoRegistro = new RegistroPorcentaje($"{intervaloDedese} a {intervaloHasta}");
                foreach (Usuario registro in Asociacion.ListaUsuarios)
                {
                    int mesesTranscurridosDesdeIngreso = registro.FechaIngreso.CalcularMesesHastaLaActualidad();
                    if (mesesTranscurridosDesdeIngreso >= intervaloDedese && mesesTranscurridosDesdeIngreso <= intervaloHasta)
                    {
                        nuevoRegistro.Cantidad++;
                        totalRegistrosCalculados++;
                    }
                }
                nuevoRegistro.Porcentaje = (double)(100 * nuevoRegistro.Cantidad) / cantidadDeUsuarios;
                listadoRetorno.Add(nuevoRegistro);
            }
            return listadoRetorno;
        }


        /// <summary>
        /// Método encargado de calcular el porcentaje de usuarios por causa de ingreso.
        /// Retronara un listado de registros de porcentaje con los porcentajes correspondientes a cada causa de ingreso.
        /// Observacion: el porcentaje total podra no ser 100% dado que un usuario puede tener mas de una causa de ingreso
        /// </summary>
        /// <returns>Listado de registros por porcentaje calculado</returns>
        public static List<RegistroPorcentaje> CalcularPorcentajesPorCausaIngreso()
        {
            List<RegistroPorcentaje> listadoRetorno = new List<RegistroPorcentaje>();
            int cantidadDeUsuarios = Asociacion.ListaUsuarios.Count;
            if (cantidadDeUsuarios == 0)
            {
                cantidadDeUsuarios = 1;
            }
            foreach (ETipoCausaIngreso causaDeIngreso in Enum.GetValues(typeof(ETipoCausaIngreso)))
            {
                int CantidadPorCausa = UsuarioControlador.FiltrarCausaDeIngreso(new List<ETipoCausaIngreso>() { causaDeIngreso }, Asociacion.ListaUsuarios).Count;
                RegistroPorcentaje nuevoRegistro = new RegistroPorcentaje(CantidadPorCausa, (double)(CantidadPorCausa * 100) / cantidadDeUsuarios, causaDeIngreso.ToString());
                listadoRetorno.Add(nuevoRegistro);
            }

            return listadoRetorno;
        }

        /// <summary>
        /// Método encargado de buscar y retornar un listado con los Dni de los usuarios de la asociacion.
        /// </summary>
        /// <returns>Listado de dni</returns>
        public static List<int> BuscarListadoDni()
        {
            List<int> listaRetorno = new List<int>();
            foreach (Usuario usuario in Asociacion.ListaUsuarios)
            {
                listaRetorno.Add(usuario.Dni);
            }
            return listaRetorno;
        }

        /// <summary>
        /// Método encargado de buscar un usuario por número de dni
        /// </summary>
        /// <param name="dni">Número de dni a buscar</param>
        /// <returns>Instancia del usuario buscado</returns>
        /// <exception cref="UsuarioNoEncontrado">Excepción arrojada cuando no se encuentre ningún usuario con el dni pasado por parametro.</exception>
        public static Usuario BuscarUsuario(int dni)
        {
            Usuario usuarioRetorno = null;
            foreach (Usuario usuario in Asociacion.ListaUsuarios)
            {
                if (usuario.Dni == dni)
                {
                    usuarioRetorno = usuario;
                    break;
                }
            }
            if (usuarioRetorno is null)
            {
                throw new UsuarioNoEncontrado($"No se encontro ningun usuario con DNI: {dni}");
            }
            return usuarioRetorno;
        }
    }
}

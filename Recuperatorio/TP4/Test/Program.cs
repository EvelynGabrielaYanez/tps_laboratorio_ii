using EntidadesAsociacion;
using EntidadesAsociacion.Controladores;
using EntidadesAsociacion.Reportes;
using EntidadesAsociacion.Utils;
using System;
using System.Collections.Generic;
using static EntidadesAsociacion.Enumerados;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Se le asigna el título a la consula
            Console.Title = "Test Asociacion";
            

            // Se inicia sesion con un empleado
            Empleado empleado = EmpleadoControlador.ValidarSesion("empleado1", "contra1234");
            Console.WriteLine("Se inicia sesión con un empleado");
            Console.WriteLine(empleado.ToString());
            Console.WriteLine($"\n{"".PadLeft(50, '=')}");

            // Se agregan dos usuarios
            Usuario primerUsuario = new Usuario("Usuario1", "TestConsola", 11111111, Convert.ToDateTime("05/11/2021"), EGrupo.Viernes, 3, 1212121212, new List<ETipoCausaIngreso>() {ETipoCausaIngreso.ViolenciaDomestica});
            Usuario segundoUsuario = new Usuario("Usuario2", "TestConsola", 22222222, Convert.ToDateTime("19/10/2021"), EGrupo.Martes, 2, 1232323232, new List<ETipoCausaIngreso>() {ETipoCausaIngreso.MaltratoYAbusoInfantil, ETipoCausaIngreso.DelitoSexual});

            // Se eliminan los usuarios-asistencias insertados durante el testeo si es que este ya fue ejecutado previamente.
            UsuarioControlador.Eliminar(primerUsuario.Dni);
            UsuarioControlador.Eliminar(segundoUsuario.Dni);

            // Se agregan los usuarios 
            UsuarioControlador.AgregarUsuario(primerUsuario);
            UsuarioControlador.AgregarUsuario(segundoUsuario);

            // Se agregan dos asistencias asistencias (La tercer asistencia no deberia agergarse dado que ya hay una asistencia cargada para esa fecha y ese usuario)
            Asistencia primerAsistencia = new Asistencia(primerUsuario, Convert.ToDateTime("05/11/2021"), EGrupo.Viernes, ETipoAsistencia.Presente);
            Asistencia segundaAsistencia = new Asistencia(segundoUsuario, Convert.ToDateTime("26/10/2021"), EGrupo.Martes, ETipoAsistencia.AusenteConAviso);
            Asistencia tercerAsistencia = new Asistencia(segundoUsuario, Convert.ToDateTime("26/10/2021"), EGrupo.Martes, ETipoAsistencia.Feriado);

            // Se agregan las asistencias
            AsistenciaControlador.AgregarAsistencia(primerAsistencia);
            AsistenciaControlador.AgregarAsistencia(segundaAsistencia);
            AsistenciaControlador.AgregarAsistencia(tercerAsistencia);
            Console.WriteLine(AsistenciaControlador.Filtrar().Mostar());
            Console.WriteLine($"\n{"".PadLeft(50, '=')}");

            // Se edita la asistencia agregada
            Asistencia asistenciaAEditar = new Asistencia(primerUsuario, Convert.ToDateTime("05/11/2021"), EGrupo.Viernes, ETipoAsistencia.AusenteConAviso);
            AsistenciaControlador.EditarAsistencia(asistenciaAEditar);
            Console.WriteLine(AsistenciaControlador.Filtrar().Mostar());
            Console.WriteLine($"\n{"".PadLeft(50, '=')}");

            Console.WriteLine("<-----------PRESIONE UNA TECLA PARA CONTINUAR----------->");
            Console.ReadKey();
            Console.Clear();

            string pathArchivosLetura = AppDomain.CurrentDomain.BaseDirectory;
            pathArchivosLetura += $"\\Archivos_Serializacion\\ArchivosLectura";
            // Se leen asistencias del archivo Json (Si contiene asistencias previamente cargadas no se leeran)

            ArchivosYSerializacionControlador.ImportarAsistenciasJsonXML(ETipoExtension.Json, "Asistencias", pathArchivosLetura);
            Console.WriteLine(AsistenciaControlador.Filtrar().Mostar());
            Console.WriteLine($"\n{"".PadLeft(50, '=')}");

            // Se leen asistencias del archivo Xml (Si contiene asistencias previamente cargadas no se leeran)
            ArchivosYSerializacionControlador.ImportarAsistenciasJsonXML(ETipoExtension.Xml, "Asistencias", pathArchivosLetura);
            Console.WriteLine(AsistenciaControlador.Filtrar().Mostar());
            Console.WriteLine($"\n{"".PadLeft(50, '=')}");


            Console.WriteLine("<-----------PRESIONE UNA TECLA PARA CONTINUAR----------->");
            Console.ReadKey();
            Console.Clear();

            // Se comparan los datos y genera reportes
            string fechaDesde = "01/11/2021";
            string fechaHasta = "08/11/2021";


            // Se exporta txt
            List<Asistencia> listadoDeAsistencia = AsistenciaControlador.FiltrarAsistencias(Convert.ToDateTime(fechaDesde), Convert.ToDateTime(fechaHasta), EGrupo.Lunes);
            string pathEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ArchivosYSerializacionControlador.ExportarAsistenciaCsvTxt(listadoDeAsistencia, ETipoExtension.Txt, "Asistencia-01_11_2021-08_11_2021", pathEscritorio);

            Console.WriteLine("Se exporto el archivo de asististencias filtrado por:");
            Console.WriteLine($"FECHA DESDE: {fechaDesde}\nFECHA HASTA: {fechaHasta}");
            Console.WriteLine(@$"RUTA DEL ARCHIVO: {pathEscritorio}\Asistencia-01_11_2021-08_11_2021.txt");

            // Se exporta a csv
            List<Asistencia> filtroPorGrupo = AsistenciaControlador.FiltrarPorGrupo(EGrupo.Lunes);
            ArchivosYSerializacionControlador.ExportarAsistenciaCsvTxt(filtroPorGrupo, ETipoExtension.Csv, "Asistencia-Grupo_Lunes", pathEscritorio);
            Console.WriteLine("Se exporto el archivo de asististencias filtrado por:");
            Console.WriteLine($"FECHA DESDE: {fechaDesde}\nFECHA HASTA: {fechaHasta}");
            Console.WriteLine(@$"RUTA DEL ARCHIVO: {pathEscritorio}\Asistencia-Grupo_Lunes.csv");

            Console.WriteLine($"\n{"".PadLeft(50, '=')}");


            Console.WriteLine("<-----------PRESIONE UNA TECLA PARA CONTINUAR----------->");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("REPORTES POR PORCENTAJE");
            // Se generan reportes de porcentaje y se exportan en los distintos formatos (txt,csv,xml y csv)
            // Genera el reporte de porcentaje de usuarios por cantidad de denuncias tomando un intervalo de 3
            Reporte<RegistroPorcentaje> reportePorcentaje1 = new Reporte<RegistroPorcentaje>(UsuarioControlador.CalcularPorcentajePorDenuncias(3));
            string nombreReporte = "Porcentaje-Cantidad-Denuncias";
            reportePorcentaje1.ExportarCsvTxt(ETipoExtension.Txt, nombreReporte, "Reportes", pathEscritorio);
            Console.WriteLine($"- Se genero el reporte de porcentaje de usuarios por cantidad de denuncias tomando un intervalo de 3. (Nombre del archivo: {nombreReporte})");

            // Genera el reporte de porcentaje de usuarios por cantidad de meses transcurrdios desde el ingreso un intervalo de 5
            Reporte<RegistroPorcentaje> reportePorcentaje2 = new Reporte<RegistroPorcentaje>(UsuarioControlador.CalcularPorcentajesPorMeses(5));
            nombreReporte = "Porcentaje-Cantidad-Meses-Ingresado";
            reportePorcentaje2.ExportarCsvTxt(ETipoExtension.Csv, nombreReporte, "Reportes", pathEscritorio);
            Console.WriteLine($"- Se genero el reporte de porcentaje de usuarios por cantidad de meses transcurrdios desde el ingreso un intervalo de 5. (Nombre del archivo: {nombreReporte})");

            // Genera el reporte de porcetaje de usuarios por causa de ingreso
            Reporte<RegistroPorcentaje> reportePorcentaje3 = new Reporte<RegistroPorcentaje>(UsuarioControlador.CalcularPorcentajesPorCausaIngreso());
            nombreReporte = "Porcentaje - Causa - De - Ingreso";
            reportePorcentaje3.SerializarXmlJson(ETipoExtension.Xml, nombreReporte, "Reportes", pathEscritorio);
            Console.WriteLine($"- Se genero el reporte de porcetaje de usuarios por causa de ingreso. (Nombre del archivo: {nombreReporte})");

            // Genera el reporte de porcentaje de usuarios por tipo de asistencia del grupo del dia Lunes
            Reporte<RegistroPorcentaje> reportePorcentaje4 = new Reporte<RegistroPorcentaje>(AsistenciaControlador.CalcularPorcentaPorTipoAsistencia(EGrupo.Lunes));
            nombreReporte = "Porcentaje-Asistencia-Grupo-Lunes";
            reportePorcentaje4.SerializarXmlJson(ETipoExtension.Json, nombreReporte, "Reportes", pathEscritorio);
            Console.WriteLine($"Se genero el reporte de porcentaje de usuarios por tipo de asistencia del grupo del dia Lunes. (Nombre del archivo: {nombreReporte})\n");

            Console.WriteLine(@$"RUTA DE LOS ARCHIVOS: {pathEscritorio}\Reportes\");

            //AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine("<-----------PRESIONE UNA TECLA PARA CONTINUAR----------->");
            Console.ReadKey();
            Console.Clear();
            DateTime fechaDesdeFiltro = Convert.ToDateTime("01/10/2021");
            DateTime fechaHastaFiltro = Convert.ToDateTime("10/11/2021");

            Console.WriteLine($"Usuarios con fecha de ingreso desde {fechaDesdeFiltro.ToString("dd/MM/yyyy")} - hasta {fechaHastaFiltro.ToString("dd/MM/yyyy")}\n\n");
            //List<Usuario> usuariosFiltradoPorFecha = UsuarioControlador.FiltrarPorFecha(fechaDesdeFiltro.Date, fechaHastaFiltro.Date, Asociacion.ListaUsuarios);
            List<Usuario> usuariosFiltradoPorFecha = UsuarioControlador.Filtrar(fechaDesde:fechaDesdeFiltro.Date, fechaHasta: fechaHastaFiltro.Date);
            Console.WriteLine(usuariosFiltradoPorFecha.Mostar());

            Console.WriteLine($"\n{"".PadLeft(50, '=')}");

            Console.WriteLine("Usuarios con una cantidad de denuncias entre 0 y 3\n\n");
            //List<Usuario> usuariosFiltradoCantidadDenuncas = UsuarioControlador.FiltrarCantidadDenuncias(0, 3, Asociacion.ListaUsuarios);
            List<Usuario> usuariosFiltradoCantidadDenuncas = UsuarioControlador.Filtrar(cantidadDenunciasDesde:0, cantidadDenunciasHasta: 3);
            Console.WriteLine(usuariosFiltradoCantidadDenuncas.Mostar());

            Console.WriteLine($"\n{"".PadLeft(50, '=')}");
            Console.WriteLine($"Usuarios que ejercieron Violencia Domestica\n\n");
            List<Usuario> usuarioFiltradoCausaDeIngreso = UsuarioControlador.FiltrarCausaDeIngreso(new List<ETipoCausaIngreso>() { ETipoCausaIngreso.ViolenciaDomestica }, UsuarioControlador.Filtrar());
            Console.WriteLine(usuarioFiltradoCausaDeIngreso.Mostar());

        }
    }
}

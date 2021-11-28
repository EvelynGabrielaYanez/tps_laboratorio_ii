using EntidadesAsociacion.Excepciones.Archivos;
using EntidadesAsociacion.Reportes;
using System.Collections.Generic;
using static EntidadesAsociacion.Enumerados;

namespace EntidadesAsociacion.Controladores
{
    public static class ArchivosYSerializacionControlador
    {
        /// <summary>
        /// Método encargado de importar la asistencias en formato json o xml
        /// </summary>
        /// <param name="extension">Tipo de extension</param>
        /// <param name="nombreArchivo">Nombre del archivo a importar</param>
        /// <param name="ruta">Ruta del archivo a importar</param>
        /// <exception cref="ErrorDeLectura">Se arroja cuando ocurre algun error en la lectura del archivo o no se tiene permisos para leer</exception>
        public static void ImportarAsistenciasJsonXML(ETipoExtension extension, string nombreArchivo, string ruta)
        {
                Reporte<Asistencia> reporteAsistencias = new Reporte<Asistencia>();
                Reporte<Asistencia> lectura = reporteAsistencias.DesereailziarXmlJson(extension, nombreArchivo, ruta);
                AsistenciaControlador.AgregarListadoDeAsistencias(lectura.DatosReporte);
        }

        /// <summary>
        /// Método encargado de exportar la asistencias en formato csv o txt
        /// </summary>
        /// <param name="listadoDeAsistencia">Listado de asistencias a exportar</param>
        /// <param name="extension">Tipo de extension</param>
        /// <param name="nombreArchivo">Nombre del archivo a importar</param>
        /// <param name="ruta">Ruta del archivo a importar</param>
        /// <exception cref="ErrorDeEscritura">Se arroja cuando ocurre algun error en la lectura del archivo o no se tiene permisos para leer</exception>
        public static void ExportarAsistenciaCsvTxt(List<Asistencia> listadoDeAsistencia, ETipoExtension tipoExtension, string nombreArchivo, string ruta)
        {
                Reporte<Asistencia> reporteAsistencia = new Reporte<Asistencia>(listadoDeAsistencia);
                reporteAsistencia.ExportarCsvTxt(tipoExtension, nombreArchivo, "", ruta);
        }
    }
}

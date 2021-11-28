using EntidadesAsociacion.Archivos_Serializacion;
using EntidadesAsociacion.Excepciones.Archivos;
using EntidadesAsociacion.Interfaces;
using System.Collections.Generic;
using static EntidadesAsociacion.Enumerados;

namespace EntidadesAsociacion.Reportes
{
    public class Reporte<T> where T : ICsv, new()
    {
        private List<T> datosReporte;

        /// <summary>
        /// Método constructor de un reporte
        /// </summary>
        public Reporte()
        {
            this.datosReporte = new List<T>();
        }

        /// <summary>
        /// Método constructor de un reporte
        /// </summary>
        /// <param name="datosReporte">
        /// Listado de datos de tipo T que copntendra el reporte.
        /// T debe implementar la interfaz Icsv y tener un constructor vacio.
        /// </param>
        public Reporte(List<T> datosReporte)
        {
            this.datosReporte = datosReporte;
        }

        /// <summary>
        /// Propiedad de escritura y lectura del listado de datos de tipo T del reporte.
        /// </summary>
        public List<T> DatosReporte
        {
            get { return this.datosReporte; }
            set { this.datosReporte = value; }
        }

        /// <summary>
        /// Método encargado de exportar a csv o txt un rporte
        /// </summary>
        /// <param name="extension">Tipo de extension</param>
        /// <param name="nombre">Nombre con el que se exportara el archivo</param>
        /// <param name="carpetaExtra">Subcarpeta que contendra el archivo (en caso de no querer crearla ingresar un string vacio)</param>
        /// <param name="path">Ruta en la que se guardara el archivo</param>
        /// <exception cref="ErrorDeEscritura">
        /// La extension del archivo es invaldia. Esta contiene una innerException del tipo ExtensionInvalida
        /// U ocurrio un error al escribir el archivo.
        /// </exception>
        public void ExportarCsvTxt(ETipoExtension extension, string nombre, string carpetaExtra, string path)
        {
            string nombreArchivo = $"{nombre}.{extension.ToString().ToLower()}";
            switch (extension)
            {
                case ETipoExtension.Txt:
                    ArchivoDeTexto<T>.Escribir(path, carpetaExtra, nombreArchivo, this.datosReporte, true);
                    break;
                case ETipoExtension.Csv:
                    ArchivoCsv<T>.Escribir(path, carpetaExtra, nombreArchivo, this.datosReporte, true);
                    break;
                default:
                    ExtensionInvalida extensionInvalida = new ExtensionInvalida($"La extension: {extension} es invalida");
                    throw new ErrorDeEscritura("Error al serializar el archvo.", extensionInvalida);
            }
        }

        /// <summary>
        /// Método encargado de serailizar a json o xml un rporte
        /// </summary>
        /// <param name="extension">Tipo de extension</param>
        /// <param name="nombre">Nombre con el que se exportara el archivo</param>
        /// <param name="carpetaExtra">Subcarpeta que contendra el archivo (en caso de no querer crearla ingresar un string vacio)</param>
        /// <param name="path">Ruta en la que se guardara el archivo</param>
        /// <exception cref="ErrorDeEscritura">
        /// La extension del archivo es invaldia. Esta contiene una innerException del tipo ExtensionInvalida en caso de serlo
        /// U ocurrio un error al serializar el archivo.
        /// </exception>
        public void SerializarXmlJson(ETipoExtension extension, string nombre, string carpetaExtra, string path)
        {
            string nombreArchivo = $"{nombre}.{extension.ToString().ToLower()}";
            switch (extension)
            {
                case ETipoExtension.Json:
                    ArchivoJson<Reporte<T>>.Escribir(path, carpetaExtra, nombreArchivo, this, true);
                    break;
                case ETipoExtension.Xml:
                    ArchivoXML<Reporte<T>>.Escribir(path, carpetaExtra, nombreArchivo, this, true);
                    break;
                default:
                    ExtensionInvalida extensionInvalida = new ExtensionInvalida($"La extension: {extension} es invalida");
                    throw new ErrorDeLectura("Error al deserealizar el archvo.", extensionInvalida);
            }
        }

        /// <summary>
        /// Método encargado de desrealizar un reporte del tipo xml o json
        /// </summary>
        /// <param name="extension">Tipo de extension</param>
        /// <param name="nombre">Nombre con el que se exportara el archivo</param>
        /// <param name="path">Ruta en la que se guardara el archivo</param>
        /// <returns>Reporte del tipo T generico con los datos desereializados</returns>
        /// <exception cref="ErrorDeLectura">
        /// La extension del archivo es invaldia. Esta contiene una innerException del tipo ExtensionInvalida en caso de serlo
        /// U ocurrio un error al deserializar el archivo.
        /// </exception>
        public Reporte<T> DesereailziarXmlJson(ETipoExtension extension, string nombre, string path)
        {
            Reporte<T> reporte = new Reporte<T>();
            string nombreArchivo = $"{nombre}.{extension.ToString().ToLower()}";
            switch (extension)
            {
                case ETipoExtension.Json:
                    reporte = ArchivoJson<Reporte<T>>.Leer(path, nombreArchivo);
                    break;
                case ETipoExtension.Xml:
                    reporte = ArchivoXML<Reporte<T>>.Leer(path, nombreArchivo);
                    break;
                default:
                    ExtensionInvalida extensionInvalida = new ExtensionInvalida($"La extension: {extension} es invalida");
                    throw new ErrorDeLectura("Error al deserealizar el archvo.", extensionInvalida);
            }

            return reporte;
        }
    }
}

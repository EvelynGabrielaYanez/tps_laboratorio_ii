using EntidadesAsociacion.Excepciones.Archivos;
using EntidadesAsociacion.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EntidadesAsociacion.Archivos_Serializacion
{
    public static class ArchivoDeTexto<T> where T : ICsv, new()
    {
        /// <summary>
        /// Método encargado de escribir los archivos de extensión txt
        /// </summary>
        /// <param name="ruta">Ruta donde se escribira el archivo</param>
        /// <param name="subCarpeta">Nombre de la subcarpeta en caso de querer crear una</param>
        /// <param name="nombreDelArchivo">Nombre del archivo a escribir</param>
        /// <param name="contenidoDelArchivo">Contenido del archivo</param>
        /// <param name="crearPathSiNoExiste">True = creara el path si no exsiste. False = No lo creara</param>
        /// <exception cref="ErrorDeEscritura">
        /// Se arroja cuando ocurre algun error en la escritura del archivo o no se tiene permisos para escirbir
        /// Se arroja con una inneException del tipo PathInexistente cuando el path recibido y  generado es inexistente
        /// </exception>
        public static void Escribir(string ruta, string subCarpeta, string nombreDelArchivo, List<T> contenidoDelArchivo, bool crearPathSiNoExiste)
        {
            try
            {
                Path.GetFullPath(ruta);
                string pathCompleto = GenerarPathCometo(ruta, subCarpeta, nombreDelArchivo, out string path);
                if (crearPathSiNoExiste && !Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                else if (!crearPathSiNoExiste)
                {
                    throw new PathInexistente("La ruta no existe");
                }
                using (StreamWriter streamWriter = new StreamWriter(pathCompleto))
                {
                    foreach (T linea in contenidoDelArchivo)
                    {
                        streamWriter.WriteLine(linea.ToString());
                    }
                }
            }
            catch (PathInexistente e)
            {
                throw new ErrorDeEscritura($"Ruta inexistente: {ruta}", e);
            }
            catch (Exception e)
            {
                throw new ErrorDeEscritura($"Error al escribir el archivo de texto {ruta}", e);
            }
        }

        /// <summary>
        /// Método encargado de generar el path compelto de la ruta
        /// </summary>
        /// <param name="ruta">Ruta donde se escribira el archivo</param>
        /// <param name="subCarpeta">Nombre de la subcarpeta</param>
        /// <param name="nombreDelArchivo">Nombre del archivo a escribir</param>
        /// <param name="path">Ruta completa sin el archivo anexado</param>
        /// <returns>Ruta completa</returns>
        /// <exception cref="PathInexistente">Se arroja esta excepcion cuando el path recibido y  generado es inexistente</exception>
        private static string GenerarPathCometo(string ruta, string subCarpeta, string nombreDelArchivo, out string path)
        {
            if (!Directory.Exists(ruta))
            {
                throw new PathInexistente("Ruta Invalida");
            }
            StringBuilder sbPath = new StringBuilder();
            sbPath.Append(Path.GetFullPath(ruta));
            if (subCarpeta.Trim() != string.Empty)
            {
                sbPath.Append(@$"\{subCarpeta}\");
            }
            else
            {
                sbPath.Append(@$"\");
            }
            path = sbPath.ToString();
            sbPath.Append(nombreDelArchivo);
            if (!nombreDelArchivo.ToLower().Contains(".txt"))
            {
                sbPath.Append(".txt");
            }
            return sbPath.ToString();
        }
    }

}

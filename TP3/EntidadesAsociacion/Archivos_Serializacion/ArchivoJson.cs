using EntidadesAsociacion.Excepciones.Archivos;
using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace EntidadesAsociacion.Archivos_Serializacion
{
    public static class ArchivoJson<T> where T : new()
    {
        /// <summary>
        /// Método encargado de serializar los archivos de extensión json
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
        public static void Escribir(string ruta, string subCarpeta, string nombreDelArchivo, T contenidoDelArchivo, bool crearPathSiNoExiste)
        {
            string path = "";
            try
            {
                string pathCompleto = GenerarPathCometo(ruta, subCarpeta, nombreDelArchivo, out path);

                if (crearPathSiNoExiste && !Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                else if (!crearPathSiNoExiste)
                {
                    throw new PathInexistente("La ruta no existe");
                }
                File.WriteAllText(pathCompleto, JsonSerializer.Serialize(contenidoDelArchivo));

            }
            catch (PathInexistente e)
            {
                throw new ErrorDeEscritura($"Ruta inexistente: {ruta}", e);
            }
            catch (Exception e)
            {
                throw new ErrorDeEscritura($"Error al escribir el archivo Json {path}", e);
            }
        }

        /// <summary>
        /// Método encargado de deserializar los archivos de extensión json
        /// </summary>
        /// <param name="ruta">Ruta donde se escribira el archivo</param>
        /// <param name="nombreDelArchivo">Nombre del archivo a deserializar</param>
        /// <returns>Objeto generico dle tipo T deserializado</returns>
        /// <exception cref="ErrorDeLectura">
        /// Se arroja cuando ocurre algun error en la lectura del archivo o no se tiene permisos para leer
        /// Se arroja con una inneException del tipo PathInexistente cuando el path recibido y  generado es inexistente
        /// </exception>
        public static T Leer(string ruta, string nombreDelArchivo)
        {
            string path = "";
            try
            {
                string pathCompleto = GenerarPathCometo(ruta, "", nombreDelArchivo, out path);
                T contenidoDeseralizado = default;
                if (Directory.Exists(path))
                {
                    string archivo = null;
                    //Busca el Archivo en la ruta
                    foreach (string archivoEnLaRuta in Directory.GetFiles(path))
                    {
                        if (archivoEnLaRuta == pathCompleto)
                        {
                            archivo = archivoEnLaRuta;
                            break;
                        }
                    }
                    if (archivo is not null)
                    {
                        contenidoDeseralizado = JsonSerializer.Deserialize<T>(File.ReadAllText(archivo));
                    }
                }
                return contenidoDeseralizado;
            }
            catch (PathInexistente error)
            {
                throw new ErrorDeLectura($"Ruta inexistente { ruta}", error);
            }
            catch (Exception error)
            {
                throw new ErrorDeLectura($"Error al leer el archivo de texto {path}", error);
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
                throw new Exception("Ruta Invalida");
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
            if (!nombreDelArchivo.ToLower().Contains(".json"))
            {
                sbPath.Append(".json");
            }
            return sbPath.ToString();
        }
    }
}

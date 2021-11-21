namespace EntidadesAsociacion.Interfaces
{
    /// <summary>
    /// Interfaz utilizada para aquellas clases que requieran utilizar la escritura en formato csv
    /// </summary>
    public interface ICsv
    {
        /// <summary>
        /// Método encargado de separar los valroes de las propiedades del objeto por coma y retornar el string correspondiente  a la concatenacion de los mismos.
        /// </summary>
        /// <returns>Cadena con los valores de las prpiedades concatenados y separados por comas</returns>
        string ToStringSeparadoPorComa();

        /// <summary>
        /// Método encargado de generar un string que contenga los nombres de las pripiedades de un objeto concatenados con ";".
        /// </summary>
        /// <returns>string de los nombres de las pripiedades de un objeto concatenados con ";".</returns>
        string ObtenerCabezeraDeColumnas();
    }
}

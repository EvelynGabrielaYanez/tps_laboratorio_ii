using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        #region Campos
        private double numero;
        #endregion

        #region Propiedades
        /// <summary>
        ///     Propiedad que asignara el valor al atributo número.
        ///     Validando previamente si este es numerico y en caso contrario le asignara 0.
        /// </summary>
        public string Numero
        {
            set
            {
                numero = Operando.ValidarOperando(value);
            }
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Método constructor que asigna por defecto el valor numero 0.
        /// </summary>
        public Operando()
        {
            this.Numero = "0";
        }

        /// <summary>
        ///     Método constructor que recibe por parametro el valor a asignar al atributo numero.
        /// </summary>
        /// <param name="numero">string con valor a asignar al atributo numero</param>
        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }

        /// <summary>
        ///     Método constructor que recibe por parametro el valor a asignar al atributo numero.
        /// </summary>
        /// <param name="numero">double con valor a asignar al atributo numero</param>
        public Operando(double numero) : this(numero.ToString())
        {
        }
        /// <summary>
        ///     Método que realiza la conversión de binario a decimal
        /// </summary>
        /// <param name="binario">Cadena de caracteres con el número binario a convertir</param>
        /// <returns>
        ///     Retorna una cadena de caracteres con el número decimal correspondiente a la conversión.
        ///     En caso de ser el número binario invalido retorna  "Valor inválido"
        /// </returns>
        public static string BinarioDecimal(string binario)
        {
            string retorno;
            if (Operando.EsBinario(binario))
            {
                int i = 0;
                double retornoDecimal = 0;
                foreach (char b in binario)
                {
                    if (b.Equals('1'))
                        retornoDecimal += (int)Math.Pow(2, binario.Length - 1 - i);
                    i++;
                }
                retorno = retornoDecimal.ToString();
            }
            else
            {
                retorno = "Valor inválido";
            }
            return retorno;
        }
        /// <summary>
        ///     Método que realiza la conversion de decimal a binario
        /// </summary>
        /// <param name="numero">Numero decimal a convertir</param>
        /// <returns>
        ///     Retorna el string correspondiente al binario.
        ///     En caso de ser demasido grande el valor a convertir retorna 
        ///     "Valor Demasiado Grande"
        /// </returns>
        public static string DecimalBinario(double numero)
        {
            int entero = (int)Math.Abs(numero);
            int resto;
            string binario = "";
            do
            {
                resto = entero % 2;
                entero /= 2;
                binario = resto.ToString() + binario;
            } while (entero >= 2);
            binario = entero.ToString() + binario;
            if (binario[0] == '-')
            {
                binario = "Valor Demasiado Grande";
            }
            return binario;
        }
        /// <summary>
        ///     Método que realiza la conversion de decimal a binario
        /// </summary>
        /// <param name="numero">Numero decimal a convertir</param>
        /// <returns>
        ///     Retorna el string correspondiente al binario.
        ///     En caso de ser demasido grande el valor a convertir retorna 
        ///     "Valor Demasiado Grande"
        /// </returns>
        public static string DecimalBinario(string numero)
        {
            Operando operando = new Operando(numero);
            return Operando.DecimalBinario(operando.numero);
        }
        private static bool EsBinario(string binario)
        {
            bool retorno = true;
            foreach (char caracter in binario)
            {
                if (!caracter.Equals('0') && !caracter.Equals('1'))
                {
                    retorno = false;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        ///     Sobrecarga del operandor - que realizara la resta
        ///     de los atributos numero de los Operando pasados por parámetro.
        /// </summary>
        /// <param name="n1">Primer Operando</param>
        /// <param name="n2">Seguno Operando</param>
        /// <returns>Retorna la resta de los atributos numero</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        ///     Sobrecarga del operandor + que realizara la suma
        ///     de los atributos numero de los Operando pasados por parámetro.
        /// </summary>
        /// <param name="n1">Primer Operando</param>
        /// <param name="n2">Seguno Operando</param>
        /// <returns>Retorna la suma de los atributos numero</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        ///     Sobrecarga del operandor * que realizara el producto
        ///     de los atributos numero de los Operando pasados por parámetro.
        /// </summary>
        /// <param name="n1">Primer Operando</param>
        /// <param name="n2">Seguno Operando</param>
        /// <returns>Retorna el producto de los atributos numero</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        ///     Sobrecarga del operandor / que realizara la división de los atributos numero. 
        ///     Siendo dividendo y divisor correspondientemente.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>
        ///     Retorna la división de los atributos numero de cada operando.
        ///     En caso de ser el atributo numero = 0 en el Operando segundo
        ///     se retornara el minimo valor de un double.
        /// </returns> 
        public static double operator /(Operando n1, Operando n2)
        {
            double retorno;
            if (n2.numero != 0)
            {
                retorno = n1.numero / n2.numero;
            }
            else
            {
                retorno = double.MinValue;
            }
            return retorno;
        }

        /// <summary>
        ///     Método que comprobará que el valor recibido sea numérico.
        /// </summary>
        /// <param name="strNumero">string a validar</param>
        /// <returns>
        ///     Si el valor es numérico lo retornara en formato double.
        ///     Caso contrario, retornará 0.
        /// </returns>
        private static double ValidarOperando(string strNumero)
        {
            double numero;
            if (!double.TryParse(strNumero, out numero))
            {
                numero = 0;
            }
            return numero;
        }
        #endregion
    }
}

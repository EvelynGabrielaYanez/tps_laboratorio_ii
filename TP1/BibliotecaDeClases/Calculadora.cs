using System;

namespace Entidades
{
    public static class Calculadora
    {
        #region Métodos
        /// <summary>
        ///     Método que valida y realiza la operación pedida entre ambos números.
        /// </summary>
        /// <param name="num1">Primer Operando</param>
        /// <param name="num2">Segundo Operando</param>
        /// <param name="operador">Char con el operador correspondiente a la operación a realizar</param>
        /// <returns>
        ///     Retrona double correspondiente resultado de la operacion realizada.
        /// </returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            operador = Calculadora.ValidarOperador(operador);
            double retorno = 0;
            switch (operador)
            {
                case '+':
                    retorno = num1 + num2;
                    break;
                case '-':
                    retorno = num1 - num2;
                    break;
                case '*':
                    retorno = num1 * num2;
                    break;
                case '/':
                    retorno = num1 / num2;
                    break;
            }
            return retorno;
        }

        /// <summary>
        /// Métod que validara que el operador recibido sea +, -, / o*.
        /// </summary>
        /// <param name="operador">Char con el operador a validar</param>
        /// <returns>
        ///     Retornara el operador recibido en caso de ser +, -, / o *.
        ///     Caso contrario retornara +.
        /// </returns>
        private static char ValidarOperador(char operador)
        {
            char retorno = operador;
            if (!operador.Equals('+') && !operador.Equals('-') &&
                !operador.Equals('*') && !operador.Equals('/'))
            {
                retorno = '+';
            }
            return retorno;
        }
        #endregion
    }
}

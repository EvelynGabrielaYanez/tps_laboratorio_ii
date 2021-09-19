using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class FormCalculadora : System.Windows.Forms.Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Método encargado de borrar los datos de los textBox,
        ///     ComboBox y el Label de la pantalla
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.SelectedItem = null;
            this.lblResultado.Text = "";
            this.lstOperaciones.Items.Clear();
        }

        /// <summary>
        ///     Método encargado de llamar al método Operar de Calculadora 
        ///     y retornar el resultado del mismo.
        /// </summary>
        /// <param name="numero1">string primer numero</param>
        /// <param name="numero2">string segundo numero</param>
        /// <param name="operador">string operador</param>
        /// <returns>
        ///     Double correspondiente al resultado de la operación
        /// </returns>
        public static double Operar(string numero1, string numero2, string operador)
        {
            Operando operador1 = new Operando(numero1);
            Operando operador2 = new Operando(numero2);
            // En caso de recibir un string vacio o un string de mas de un caracter lo convertira a un caracter vacio.
            if (!char.TryParse(operador, out char charOperador))
            {
                charOperador = '\0';
            }
            return Calculadora.Operar(operador1, operador2, charOperador);
        }
        /// <summary>
        ///     Ejecutara la liempieza de  los textBox, ComboBox y el Label de la pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        ///     Realazara el calculo de la operación tomando los valores de los operando del textbox correspondientes
        ///     al txtNumero1 y txtNumero2 y el operador del comobox cmbOperador. 
        ///     Retornara el resultado en el label  lblResultado.
        ///     Agregara la operación al listado de operaciones lstOperaciones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string strNumeroUno = this.txtNumero1.Text;
            string strNumeroDos = this.txtNumero2.Text;
            string operador = this.cmbOperador.Text;
            string resultado = FormCalculadora.Operar(strNumeroUno, strNumeroDos, operador).ToString();

            this.lblResultado.Text = resultado;
            // Se modifican los casos
            if (strNumeroUno.Equals(""))
            {
                strNumeroUno = "0";
            }
            if (operador.Equals(""))
            {
                operador = "+";
            }
            if (strNumeroDos.Equals(""))
            {
                strNumeroDos = "0";
            }
            this.lstOperaciones.Items.Add($"{strNumeroUno} {operador} {strNumeroDos} = {resultado}");
        }

        /// <summary>
        ///     Realizara el cierre del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Convertira de decimal a binario el valor que se encuentre en el lbl lblResultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string binario = Operando.DecimalBinario(this.lblResultado.Text);
            this.lstOperaciones.Items.Add($"({this.lblResultado.Text})d = ({binario})b");

            this.lblResultado.Text = binario;
        }

        /// <summary>
        /// Convertira de binario a decimal el valor que se encuentre en el lbl lblResultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string numeroDecimal = Operando.BinarioDecimal(this.lblResultado.Text);
            if (numeroDecimal.Equals("Valor invalido"))
            {
                this.lstOperaciones.Items.Add($"({this.lblResultado.Text})b = ({numeroDecimal})d");
            }
            else
            {
                this.lstOperaciones.Items.Add($" El valor {this.lblResultado.Text} no es binario");
            }
            
            this.lblResultado.Text = numeroDecimal;
        }

        /// <summary>
        ///     En caso de estar cerrandose el formulario preguntara mediante una cada de mensaje si esta esta seguro de salir.
        ///     Si el usuario confimara la operacion lo cerrara, caso contrario cancelara el cierre.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}

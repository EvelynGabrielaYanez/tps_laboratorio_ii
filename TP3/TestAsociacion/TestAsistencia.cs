using EntidadesAsociacion;
using EntidadesAsociacion.Controladores;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using static EntidadesAsociacion.Enumerados;

namespace TestAsociacion
{
    [TestClass]
    public class TestAsistencia
    {
        Asistencia asistencia;
        /// <summary>
        /// Método encargado de inicializar la asistencia con la que se realizaran alguns de los test.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            Usuario usuario = new Usuario("asistenciaTestNombre", "asistenciaTestApellido", 37429444, Convert.ToDateTime("01/09/2021"), EGrupo.Lunes, 10, 1578423714, new List<ETipoCausaIngreso>() { ETipoCausaIngreso.DelitoSexual, ETipoCausaIngreso.MaltratoYAbusoInfantil });
            this.asistencia = new Asistencia(usuario, Convert.ToDateTime("29/10/2021"), EGrupo.Viernes, ETipoAsistencia.Ausente);
        }

        /// <summary>
        /// Método encargado de testear que:
        /// - Al agregar una asistencia con éxito el método retorne true
        /// - La última asistencia del listado de la asociacion sea la que debia agregar
        /// </summary>
        [TestMethod]
        public void Test_AgregarAsistencia_01()
        {
            // Asistencia de retorno esperada
            Asistencia asistenciaRetornoEsperada = this.asistencia;

            // Se agrega la asistencia
            bool retorno = AsistenciaControlador.AgregarAsistencia(this.asistencia);

            // Se obtiene la última asistencia de la lista
            int cantidad = Asociacion.ListadoAsistencias.Count;

            /// Se valida si la asistencia agregada es la que
            Assert.AreEqual(asistenciaRetornoEsperada, Asociacion.ListadoAsistencias[cantidad - 1]);
            Assert.IsTrue(retorno);
        }

        /// <summary>
        /// Método encargado de testear que:
        /// - Al agregar una asistencia que ya fue agregada previamente el método retorne true
        /// - El largo de la lista continue siendo el mismo que antes de ejecutar el método (no se haya agregado la asistencia)
        /// </summary>
        [TestMethod]
        public void Test_AgregarAsistencia_02()
        {
            int cantidadEsperada = Asociacion.ListadoAsistencias.Count;

            //
            AsistenciaControlador.AgregarAsistencia(this.asistencia);
            bool retorno = AsistenciaControlador.AgregarAsistencia(this.asistencia);

            Assert.AreEqual(cantidadEsperada, Asociacion.ListadoAsistencias.Count);
            Assert.IsFalse(retorno);
        }

        /// <summary>
        /// Método encargado de testear que el método EditarAsistencia:
        /// - Al editar una asistencia con éxito retorne true
        /// - La asistencia en la lista (editada) contenga el tipo de presencialidad editado correctamente
        /// </summary>
        /// <param name="tipoDeasistencia"></param>
        [DataRow(ETipoAsistencia.Feriado)]
        [TestMethod]
        public void Test_EditarAsistencia_01(ETipoAsistencia tipoDeasistencia)
        {
            // Se agrega una asistencia
            AsistenciaControlador.AgregarAsistencia(this.asistencia);
            //Se edita el tipo de presente de la misma
            this.asistencia.Presente = tipoDeasistencia;

            // Se ejecuta el método a testear
            bool retorno = AsistenciaControlador.EditarAsistencia(this.asistencia);

            // Obtengo la ultima asistencia de la lista para verificar si se agrego
            int indice = Asociacion.ListadoAsistencias.Count - 1;
            Asistencia asistenciaRetorno = Asociacion.ListadoAsistencias[indice];

            Assert.AreEqual(tipoDeasistencia, asistenciaRetorno.Presente);
            Assert.IsTrue(retorno);
        }

        /// <summary>
        /// Método encargado de testear que el método EditarAsistencia:
        /// - Al intentar editar una asistencia inexistente en el listado de la asociacion retorne false
        /// </summary>
        [TestMethod]
        public void Test_EditarAsistencia_02()
        {
            Usuario usuario = new Usuario("asistenciaTestNombre2", "asistenciaTestApellido2", 38555777, Convert.ToDateTime("01/09/2021"), EGrupo.Lunes, 10, 1578423714, new List<ETipoCausaIngreso>() { ETipoCausaIngreso.DelitoSexual, ETipoCausaIngreso.MaltratoYAbusoInfantil });
            this.asistencia = new Asistencia(usuario, Convert.ToDateTime("29/10/2021"), EGrupo.Viernes, ETipoAsistencia.Ausente);

            bool retorno = AsistenciaControlador.EditarAsistencia(this.asistencia);
            Assert.IsFalse(retorno);
        }
    }
}

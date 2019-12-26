using Escritura.Core;
using Escritura.UI.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Escritura.UI.Controllers
{
    class AuxiliarController
    {
        public AuxiliarController(List<Capitulo> listaCapitulos, List<Personaje> listaPersonajes, Capitulo capituloActual)
        {
            capitulos = listaCapitulos;
            personajes = listaPersonajes;
            capActual = capituloActual;

            Build();
        }

        void Build()
        {
            vistaAuxiliar = new VistaAuxiliar(capActual);
            int i = 0;
            foreach (Button btn in vistaAuxiliar.btnsSeccion)
            {
                int a = i;
                btn.Click += (sender, args) =>
                {
                    abrirEdicion(new EdicionController(capitulos, personajes, capActual, capActual.Secciones[a]));
                    vistaAuxiliar.Hide();
                };
                i++;
            }
        }

        private void abrirEdicion(EdicionController ed)
        {

            edicionView = ed.edicionView;

            edicionView.Show();

            edicionView.FormClosed += (sender, args) => vistaAuxiliar.Show() ;


        }

        Capitulo capActual
        {
            get; set;
        }

        List<Capitulo> capitulos
        {
            get; set;
        }

        List<Personaje> personajes
        {
            get; set;
        }

        EdicionView edicionView
        {
            get; set;
        }


        public VistaAuxiliar vistaAuxiliar
        {
            get; set;
        }
    }
}

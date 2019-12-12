using NovelasAPP.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonajesNovelas.UI
{
    public class PersonajesController
    {

        public PersonajesController()
        {
            this.View = new PersonajesView();

            this.View.BtCrearPersonaje.Click += (sender, args) => this.ViewCrearPersonajePanel();
            this.View.BtMostrarPersonajes.Click += (sender, args) => this.ViewMostrarPersonajesPanel();
            this.View.BtBorrarPersonajes.Click += (sender, args) => this.ViewBorrarPersonajesPanel();
        }

        private void ViewBorrarPersonajesPanel()
        {
            new BorrarPersonajesPanel().Show();
        }

        private void ViewCrearPersonajePanel()
        {
            new CrearPersonajePanel().Show();
        }

        private void ViewMostrarPersonajesPanel()
        {
            new MostrarPersonajesPanel().Show();
        }

        private void Menu()
        {
        }


        public PersonajesView View
        {
            get; private set;
        }
    }
}

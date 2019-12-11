using PersonajesNovelas.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonajesNovelas.UI
{
    public class MainWindowController
    {

        public MainWindowController()
        {
            this.View = new MainWindowView();

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




        public MainWindowView View
        {
            get; private set;
        }
    }
}

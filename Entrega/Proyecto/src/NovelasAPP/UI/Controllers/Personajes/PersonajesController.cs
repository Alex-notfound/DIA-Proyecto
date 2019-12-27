using NovelasAPP.UI.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NovelasAPP.UI.Controllers
{
    public class PersonajesController
    {

        public PersonajesController()
        {

            this.View = new PersonajesView();
            this.View.BtCrearPersonaje.Click += (sender, args) => this.ViewCrearPersonajePanel();
            this.View.BtBorrarPersonajes.Click += (sender, args) => this.ViewBorrarPersonajesPanel();
            
        }

        private void ViewBorrarPersonajesPanel()
        {
            
            new BorrarPersonajesPanel().ShowDialog();
            this.View.IntroducirDatos();
        }

        private void ViewCrearPersonajePanel()
        {
            
            new CrearPersonajePanel().ShowDialog();
            this.View.IntroducirDatos();
        }

        public PersonajesView View
        {
            get; private set;
        }
    }
}

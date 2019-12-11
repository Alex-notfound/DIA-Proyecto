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
    class CrearPersonajePanel : Form
    {

        RegistroPersonajes registro = new RegistroPersonajes();


        public CrearPersonajePanel()
        {
            registro = registro.RecuperaXml();
            Build();
        }

        public TextBox Edn { get; private set; }
        public TextBox Edd { get; private set; }

        private void Build()
        {

            //Crear panel
            var pnl = new Panel { Dock = DockStyle.Top };
            pnl.SuspendLayout();
            pnl.Dock = DockStyle.Fill;

            var btGuardar = new Button
            {
                Text = "Guardar",
                Dock = DockStyle.Top
            };


            //Descripcion

            var lbld = new Label
            {
                Dock = DockStyle.Top,
                Text = "Descripción"
            };


            this.Edd = new TextBox
            {
                Dock = DockStyle.Top,
                TextAlign = HorizontalAlignment.Left,
                Text = ""
            };


            //Nombre
            var lbln = new Label
            {
                Dock = DockStyle.Top,
                Text = "Nombre"
            };

            this.Edn = new TextBox
            {
                Dock = DockStyle.Top,
                TextAlign = HorizontalAlignment.Left,
                Text = ""
            };


            pnl.Controls.Add(btGuardar);
            pnl.Controls.Add(this.Edd);
            pnl.Controls.Add(lbld);
            pnl.Controls.Add(this.Edn);
            pnl.Controls.Add(lbln);
            

            pnl.ResumeLayout(false);
            this.Controls.Add(pnl);
            this.MinimumSize = new Size(320, 240);
            btGuardar.Click += (sender, args) => GuardarDatos();


        }


        public void GuardarDatos()
        {
            string nombre = Edn.Text;
            string descripcion = Edd.Text;
            registro.addPersonaje(new Personaje(nombre, descripcion));

            registro.GuardaXml();
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonajesNovelas
{
    using WFrms = System.Windows.Forms;
    public class MainWindowView : WFrms.Form
    {

        public MainWindowView()
        {
            this.Build();
        }

        void Build()
        {
            var mainPanel = new WFrms.TableLayoutPanel
            {
                Dock = WFrms.DockStyle.Fill
            };
            mainPanel.Controls.Add(this.BuildCreate());
            mainPanel.Controls.Add(this.BuildShow());
            mainPanel.Controls.Add(this.BuildDelete());

            this.Size = new Size(300, 200);

            this.Controls.Add(mainPanel);
        }

        WFrms.Button BuildCreate()
        {

            BtCrearPersonaje = new Button
            {
                Text = "Crear personaje",
                Dock = DockStyle.Top
            };


            return BtCrearPersonaje;

        }

        WFrms.Button BuildShow()
        {

            BtMostrarPersonajes = new Button
            {
                Text = "Mostrar personajes",
                Dock = DockStyle.Top
            };

            return BtMostrarPersonajes;

        }

        WFrms.Button BuildDelete()
        { 

            BtBorrarPersonajes = new Button
            {
                Text = "Borrar personajes",
                Dock = DockStyle.Top
            };

            return BtBorrarPersonajes;
        }

        public WFrms.Button BtCrearPersonaje
        {
            get; private set;
        }
        public WFrms.Button BtMostrarPersonajes
        {
            get; private set;
        }
        public WFrms.Button BtBorrarPersonajes
        {
            get; private set;
        }


    }
}

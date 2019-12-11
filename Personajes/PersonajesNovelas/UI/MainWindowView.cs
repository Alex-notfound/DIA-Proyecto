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

            this.Size = new Size(300, 400);

            this.Controls.Add(mainPanel);
        }

        WFrms.Panel BuildCreate()
        {
            var pnl = new WFrms.Panel { Dock = WFrms.DockStyle.Top };

            BtCrearPersonaje = new Button
            {
                Text = "Crear personaje",
                Dock = DockStyle.Top
            };



            pnl.Controls.Add(BtCrearPersonaje);
            return pnl;

        }

        WFrms.Panel BuildShow()
        {
            var pnl = new WFrms.Panel { Dock = WFrms.DockStyle.Top };

            BtMostrarPersonajes = new Button
            {
                Text = "Mostrar personajes",
                Dock = DockStyle.Top
            };


            pnl.Controls.Add(BtMostrarPersonajes);
            return pnl;

        }

        WFrms.Panel BuildDelete()
        {
            var pnl = new WFrms.Panel { Dock = WFrms.DockStyle.Top };

            BtBorrarPersonajes = new Button
            {
                Text = "Borrar personajes",
                Dock = DockStyle.Top
            };

            pnl.Controls.Add(BtBorrarPersonajes);
            return pnl;

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

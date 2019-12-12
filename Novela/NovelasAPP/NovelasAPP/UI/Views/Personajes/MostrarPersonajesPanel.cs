using NovelasAPP.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonajesNovelas.UI
{
    class MostrarPersonajesPanel : Form
    {
       

            public MostrarPersonajesPanel()
            {
                this.build();
            }


            /// <summary>
            /// Crea un panel en el que se listan personajes
            /// </summary>

            private void build()
            {

            // Recupera xml del registro
            RegistroPersonajes registro = new RegistroPersonajes();
            registro = registro.RecuperaXml();

              var pnlTable = new TableLayoutPanel();

                //pnlTable.SuspendLayout();
                pnlTable.Dock = DockStyle.Fill;

                Label personajes = new Label()
                {
                    Dock = DockStyle.Top,
                    Text = "PERSONAJES\n\n" + registro.ToString()
                };

                personajes.Size = new Size(personajes.PreferredWidth, personajes.PreferredHeight);
                pnlTable.Controls.Add(personajes);

                pnlTable.ResumeLayout(false);
                this.Controls.Add(pnlTable);
                this.MinimumSize = new Size(320, 2000);
            }

        }
    }

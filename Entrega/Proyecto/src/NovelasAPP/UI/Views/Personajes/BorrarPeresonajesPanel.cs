using NovelasAPP.Core.Personajes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NovelasAPP.UI.Views
{
    class BorrarPersonajesPanel : Form
    {
        
        RegistroPersonajes Registro = new RegistroPersonajes();
        private object btBorrar;

        public BorrarPersonajesPanel()
        {
            Registro = Registro.RecuperaXml();
            build();
            
        }


        private void build()
        {
            var pnl = new Panel { Dock = DockStyle.Top };
            pnl.SuspendLayout();
            pnl.Dock = DockStyle.Fill;

            var lblper = new Label
            {
                Dock = DockStyle.Top,
                Text = "Elige personaje:"
            };

            var listaPersonajes = new ComboBox()
            {
                Dock = DockStyle.Right
            };

            listaPersonajes.BeginUpdate();
            foreach (Personaje per in Registro.Personajes)
            {
                listaPersonajes.Items.Add(per.Nombre);
            }
            listaPersonajes.EndUpdate();

            var btBorrar = new Button
            {
                Text = "Borrar personaje",
                Dock = DockStyle.Top
            };

            var btBorrarTodos = new Button
            {
                Text = "Borrar todos los personajes",
                Dock = DockStyle.Top
            };


            
            pnl.Controls.Add(btBorrarTodos);
            pnl.Controls.Add(btBorrar);
            
            pnl.Controls.Add(lblper);
            pnl.Controls.Add(listaPersonajes);




            pnl.ResumeLayout(false);
            this.Controls.Add(pnl);
            this.MinimumSize = new Size(320, 240);

            try
            {
                btBorrar.Click += (sender, args) => {
                    if (listaPersonajes.SelectedItem != null)
                    {
                        borrarUnicoPersonaje(listaPersonajes.SelectedItem.ToString());
                    }
                };

            }
            catch(NullReferenceException e)
            {
                this.Close();
            }
            btBorrarTodos.Click += (sender, args) => borrarPersonajes();

        }

        private void borrarUnicoPersonaje(string personaje)
        {
            Registro.delete(personaje);
            Registro.GuardaXml();
            this.Close();
        }

        private void borrarPersonajes()
        {
            var pnl = new Panel { Dock = DockStyle.Bottom };

            RegistroPersonajes registro = new RegistroPersonajes();


            //Recupera xml del registro para borrarlos respues
            registro.RecuperaXml();

            registro.Clear();

            //Texto que se muestra en pantalla
            Label label1 = new Label()
            {
                Dock = DockStyle.Bottom,
                Text = "Datos Borrados"
            };

            label1.Size = new Size(label1.PreferredWidth, label1.PreferredHeight);
            pnl.Controls.Add(label1);
            this.Controls.Add(pnl);
            
            this.Close();

        }

    }
}

using PersonajesNovelas.Core;
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
                ColumnCount = 2,
                RowCount = 2,
                AutoSize = true,
                Dock = WFrms.DockStyle.Fill
            };
            mainPanel.Controls.Add(this.BuildCreate(), 0, 0);
            mainPanel.Controls.Add(this.BuildDelete(), 1, 0);


            Datos = new DataGridView();
            
            Datos.Size = new Size(390, 200);
            mainPanel.Controls.Add(Datos, 0, 1);
            mainPanel.SetColumnSpan(Datos, 2);

            mainPanel.AutoSize = true;

            TablaMultifuncion_Load();
            
            

            this.Size = new Size(580, 340);

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

        WFrms.Button BuildDelete()
        { 

            BtBorrarPersonajes = new Button
            {
                Text = "Borrar personajes",
                Dock = DockStyle.Left
            };

            return BtBorrarPersonajes;
        }

        private void TablaMultifuncion_Load()
        {
            ColocarDataGridView();
            IntroducirDatos();
        }


        private void ColocarDataGridView()
        {

            Datos.ColumnCount = 2;


            Datos.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            Datos.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            Datos.RowHeadersVisible = false;
            Datos.ReadOnly = true;


            Datos.Columns[0].Name = "Nombre";
            Datos.Columns[1].Name = "Descripción";

            Datos.Columns[0].Width = 200;
            Datos.Columns[1].Width = 350;


            Datos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            Datos.Dock = DockStyle.Fill;
        }

        public void IntroducirDatos()
        {
            Datos.Rows.Clear();

            RegistroPersonajes registro = new RegistroPersonajes();
            registro = registro.RecuperaXml();
            
            foreach(Personaje p in registro.Personajes)
            {
                Datos.Rows.Add(p.Nombre,p.Descripcion);
            }


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

        public WFrms.DataGridView Datos
        {
            get;private set;
        }

    }
}

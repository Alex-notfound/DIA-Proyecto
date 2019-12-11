using Escritura.Core;
using Escritura.UI.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Escritura.UI.Views
{
    public partial class EdicionView : Form
    {
        public EdicionView(Capitulo capituloActual)
        {
            this.mainPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 10,
                RowCount = 4,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None
            };

            TableLayoutPanel topPanel = this.topPanel();
            TableLayoutPanel escrituraTable = this.tlpEscritura();

            CapitulosPanel(EdicionController.capitulos);
            PersonajesPanel(EdicionController.personajes);
            SeccionesPanel(capituloActual.Secciones);

            mainPanel.Controls.Add(topPanel, 0, 0);
            mainPanel.Controls.Add(escrituraTable, 0, 1);
            mainPanel.Controls.Add(lvCapitulos, 1, 1);
            mainPanel.Controls.Add(lvSecciones, 1, 2);
            mainPanel.Controls.Add(lvPersonajes, 1, 3);

            mainPanel.SetColumnSpan(topPanel, 2);
            mainPanel.SetRowSpan(escrituraTable, mainPanel.RowCount - 1);

            mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize)); ;



            this.Controls.Add(mainPanel);
            this.MinimumSize = new Size(1024, 768);
            this.Text = "Escritura";
        }

        void CapitulosPanel(List<Capitulo> capitulos)
        {
            this.lvCapitulos = new ListView
            {
                View = View.Details,
                HeaderStyle = ColumnHeaderStyle.Nonclickable,
                MultiSelect = false,
                Dock = DockStyle.Fill
            };

            this.lvCapitulos.Clear();

            ListViewItem[] listaItems = new ListViewItem[capitulos.Count];
            int i = 0;
            foreach (Capitulo c in capitulos)
            {
                listaItems[i] = new ListViewItem(c.Titulo);
                i++;
            }

            //this.lvCapitulos.ItemActivate += (sender, args) => MessageBox.Show("Funcionaaa");
            this.lvCapitulos.Columns.Add("Capitulos", -2, HorizontalAlignment.Left);
            this.lvCapitulos.Items.AddRange(listaItems);
        }

        void PersonajesPanel(List<Personaje> personajes)
        {

            this.lvPersonajes = new ListView
            {
                View = View.Details,
                HeaderStyle = ColumnHeaderStyle.Nonclickable,
                MultiSelect = false,
                Dock = DockStyle.Fill
            };

            this.lvPersonajes.Clear();

            ListViewItem[] listaItems = new ListViewItem[personajes.Count];
            int i = 0;
            foreach (Personaje c in personajes)
            {
                listaItems[i] = new ListViewItem(c.Nombre);
                i++;
            }

            this.lvPersonajes.Columns.Add("Personajes", -2, HorizontalAlignment.Left);
            this.lvPersonajes.Items.AddRange(listaItems);


        }

        void SeccionesPanel(List<Seccion> secciones)
        {

            this.lvSecciones = new ListView
            {
                View = View.Details,
                HeaderStyle = ColumnHeaderStyle.Nonclickable,
                MultiSelect = false,
                Dock = DockStyle.Fill
            };

            this.lvSecciones.Clear();

            ListViewItem[] listaItems = new ListViewItem[secciones.Count];
            int i = 0;
            foreach (Seccion s in secciones)
            {
                listaItems[i] = new ListViewItem("Seccion " + (i+1));
                i++;
            }

            this.lvSecciones.Columns.Add("Secciones", -2, HorizontalAlignment.Left);
            this.lvSecciones.Items.AddRange(listaItems);


        }

        TableLayoutPanel topPanel()
        {
            var table = new TableLayoutPanel
            {
                AutoSize = true,
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 1,
            };

            this.btnNuevoCap = new Button
            {
                AutoSize = true,
                Anchor = AnchorStyles.None,
                Text = "Nuevo Capitulo"
            };

            this.btnNuevaSec = new Button
            {
                AutoSize = true,
                Anchor = AnchorStyles.None,
                Text = "Nueva Seccion"
            };

            table.Controls.Add(this.btnNuevoCap, 0, 0);
            table.Controls.Add(this.btnNuevaSec, 1, 0);

            table.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            return table;
        }

        TableLayoutPanel tlpEscritura()
        {
            TableLayoutPanel table = new TableLayoutPanel
            {
                ColumnCount = 3,
                RowCount = 2,
                Dock = DockStyle.Fill
            };

            this.btnNegrita = new Button
            {
                Text = "Negrita"
            };

            this.btnCursiva = new Button
            {
                Text = "Cursiva"
            };

            this.btnGuardar = new Button
            {
                Text = "Guardar"
            };

            this.tbEdicion = new TextBox
            {
                Dock = DockStyle.Fill,
                Multiline = true
            };

            table.Controls.Add(btnNegrita, 0, 0);
            table.Controls.Add(btnCursiva, 1, 0);
            table.Controls.Add(btnGuardar, 2, 0);
            table.Controls.Add(tbEdicion, 1, 1);

            table.SetColumnSpan(tbEdicion, 3);

            return table;
        }

        public void refreshView(Capitulo capActual)
        {
            this.mainPanel.Controls.Remove(this.lvCapitulos);
            this.CapitulosPanel(EdicionController.capitulos);
            mainPanel.Controls.Add(lvCapitulos, 1, 1);

            this.mainPanel.Controls.Remove(this.lvSecciones);
            this.SeccionesPanel(capActual.Secciones);
            mainPanel.Controls.Add(lvSecciones, 1, 2);

            this.mainPanel.Controls.Remove(this.lvPersonajes);
            this.PersonajesPanel(EdicionController.personajes);
            mainPanel.Controls.Add(lvPersonajes, 1, 3);

            mainPanel.Refresh();

        }

        public TableLayoutPanel mainPanel
        {
            get; set;
        }
        public Button btnGuardar
        {
            get; set;
        }

        public Button btnCursiva
        {
            get; set;
        }
        public Button btnNegrita
        {
            get; set;
        }

        public Button btnNuevoCap
        {
            get; set;
        }

        public Button btnNuevaSec
        {
            get; set;
        }

        public TextBox tbEdicion
        {
            get; set;
        }

        public ListView lvCapitulos
        {
            get; set;
        }

        public ListView lvPersonajes
        {
            get; set;
        }

        public ListView lvSecciones
        {
            get; set;
        }

    }
}

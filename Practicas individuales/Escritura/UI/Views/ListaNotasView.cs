using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Escritura.UI.Views
{
    public partial class ListaNotasView : Form
    {
        public ListaNotasView(string titulo, List<Label> lblNotas)
        {
            this.Build(titulo, lblNotas);
        }

        void Build(string titulo, List<Label> lblNotas)
        {

            var mainPanel = new TableLayoutPanel
            {
                AutoSize = true,
                ColumnCount = 1,
                RowCount = lblNotas.Count,
                Dock = DockStyle.Fill,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None
            };


            int i = 0;
            foreach (Label l in lblNotas)
            {
                mainPanel.Controls.Add(l, 0, i);
                i++;
            }

            Button aceptar = new Button
            {
                DialogResult = DialogResult.OK,
                Text = "Cerrar"
            };

            mainPanel.Controls.Add(aceptar, 1, i);

            this.Controls.Add(mainPanel);
            this.Text = titulo + " - Notas";
        }

        public static Label BuildNotas(string num, string texto)
        {
            Label lblSeccion = new Label
            {
                Dock = DockStyle.Fill,
                Text = "Nota " + num + ": " + texto
            };

            return lblSeccion;
        }


        public Button addNotas
        {
            get; private set;
        }
    }
}

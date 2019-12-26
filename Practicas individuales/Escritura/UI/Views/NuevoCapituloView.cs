using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Escritura.UI.Views
{
    public partial class NuevoCapituloView : Form
    {
        public NuevoCapituloView()
        {
            this.Build();
        }

        void Build()
        {
            var mainPanel = new TableLayoutPanel
            {
                ColumnCount = 2,
                RowCount = 3,
                Dock = DockStyle.Fill,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None,

            };

            Label lbl = new Label
            {
                Dock = DockStyle.Top,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                Text = "Titulo del nuevo capitulo"
            };

            this.titulo = new TextBox
            {
                Dock = DockStyle.Fill
            };

            Button aceptar = new Button
            {
                DialogResult = DialogResult.OK,
                Text = "Aceptar"
            };

            Button cancelar = new Button
            {
                DialogResult = DialogResult.Cancel,
                Text = "Cancelar"
            };

            mainPanel.Controls.Add(lbl, 0, 0);
            mainPanel.SetColumnSpan(lbl, 2);
            
            mainPanel.Controls.Add(titulo, 0, 1);
            mainPanel.SetColumnSpan(titulo, 2);
            
            mainPanel.Controls.Add(aceptar, 0, 3);
            mainPanel.Controls.Add(cancelar, 1, 3);

            mainPanel.AutoSize = true;

            this.Controls.Add(mainPanel);

        }

        public TextBox titulo
        {
            get; set;
        }

    }
}

using Escritura.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Escritura.UI.Views
{
    public partial class VistaAuxiliar : Form
    {
        public VistaAuxiliar(Capitulo capitulo)
        {
            var mainPanel = new TableLayoutPanel
            {
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None,
                ColumnCount = 1,
                RowCount = capitulo.Secciones.Count
            };

            btnsSeccion = new Button[capitulo.Secciones.Count];

            int i = 0;
            //foreach (Seccion sec in capitulo.Secciones)
            foreach(Button btn in btnsSeccion)
            {
                btnsSeccion[i] = new Button 
                { 
                    AutoSize = true, Text = "Seccion " + (i+1) 
                };

                mainPanel.Controls.Add(btnsSeccion[i], 0, i);
                i++;
            }

            this.Controls.Add(mainPanel);

        }

        public Button[] btnsSeccion
        {
            get; set;
        }
    }
}

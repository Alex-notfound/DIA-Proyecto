using NovelasAPP.Core.Graficos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NovelasAPP.UI.Views
{
    public partial class GraficoWindow : Form
    {
        public const int ChartCanvasSize = 512;
        public GraficoWindow(List<int> valoresPalabras)
        {
            this.Build();

            this.Chart.LegendY = "Palabras / Caracteres";
            this.Chart.LegendX = "Capitulos / Secciones";
            this.Chart.Values = valoresPalabras.ToArray(); 

            this.Chart.Draw();
        }

        private void Build()
        {
            this.Chart = new Grafico(width: ChartCanvasSize,
                                    height: ChartCanvasSize)
            {
                Dock = DockStyle.Fill,
            };

            this.Controls.Add(this.Chart);

            this.MinimumSize = new Size(ChartCanvasSize, ChartCanvasSize);
            this.Text = this.GetType().Name;
        }

        /// <summary>
        /// Gets the <see cref="Chart"/>.
        /// </summary>
        /// <value>The chart.</value>
        public Grafico Chart
        {
            get; private set;
        }

    }
}

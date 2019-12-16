using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NovelasAPP.UI.Views
{
    using WFrms = System.Windows.Forms;

    public partial class GraficosView : Form
    {

        public GraficosView()
        {
            this.Build();
        }

        void Build()
        {
            var MainPanel = new WFrms.TableLayoutPanel { Dock = WFrms.DockStyle.Fill };

            MainPanel.Controls.Add(this.BuildCapitulos());
            MainPanel.Controls.Add(this.BuildSecciones());

            this.Controls.Add(MainPanel);
        }

        WFrms.Panel BuildCapitulos()
        {
            var pnl = new WFrms.Panel { Dock = WFrms.DockStyle.Top };

            this.btnGenerarCapitulos = new WFrms.Button
            {
                Dock = WFrms.DockStyle.Fill,
                Text = "Generar Grafico de Capitulos"
            };

            pnl.Controls.Add(btnGenerarCapitulos);

            return pnl;
        }

        WFrms.Panel BuildSecciones()
        {
            var pnl = new WFrms.Panel { Dock = WFrms.DockStyle.Top };

            this.btnGenerarSecciones = new WFrms.Button
            {
                Dock = WFrms.DockStyle.Fill,
                Text = "Generar Grafico de Secciones"
            };

            pnl.Controls.Add(btnGenerarSecciones);

            return pnl;
        }

        public WFrms.Button btnGenerarCapitulos
        {
            get; private set;
        }

        public WFrms.Button btnGenerarSecciones
        {
            get; private set;
        }

    }
}

using System;
using System.Collections.Generic;
using WFrms = System.Windows.Forms;

namespace NovelasAPP.UI.Views
{
    public class AddSeccionView : WFrms.Form
    {
        public AddSeccionView()
        {
            this.Build();
        }

        void Build()
        {
            var mainPanel = new WFrms.TableLayoutPanel
            {
                Dock = WFrms.DockStyle.Fill
            };
            
            mainPanel.Controls.Add(this.BuildNotas());
            mainPanel.Controls.Add(this.BuildTexto());
            mainPanel.Controls.Add(this.BuildBtnAddSec());
            
            
            this.Controls.Add(mainPanel);
        }

        WFrms.Panel BuildNotas()
        {
            var pnl = new WFrms.Panel {Dock = WFrms.DockStyle.Top};

            this.txtNotas = new WFrms.TextBox()
            {
                PlaceholderText = "Notas",
                Dock = WFrms.DockStyle.Fill
            };
            pnl.Controls.Add(this.txtNotas);
            return pnl;
        }
        
        WFrms.Panel BuildTexto()
        {
            var pnl = new WFrms.Panel {Dock = WFrms.DockStyle.Top};

            this.txtTitulo = new WFrms.TextBox()
            {
                PlaceholderText = "Texto",
                Dock = WFrms.DockStyle.Fill
            };
            pnl.Controls.Add(this.txtTitulo);
            return pnl;
        }
        
        WFrms.Panel BuildBtnAddSec()
        {
            var pnl = new WFrms.Panel
            {
                Dock = WFrms.DockStyle.Top
            };
            this.btnAddSec = new WFrms.Button
            {
                Dock = WFrms.DockStyle.Fill,
                Text = "Añadir"
            };
            
            pnl.Controls.Add(this.btnAddSec);
            return pnl;
        }
        
        public WFrms.TextBox txtTitulo
        {
            get; private set;
        }
        
        public WFrms.TextBox txtNotas
        {
            get; private set;
        }
        
        public WFrms.Button btnAddSec { get; private set; }
    }
}
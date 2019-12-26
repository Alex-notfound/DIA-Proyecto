using System;
using System.Collections.Generic;
using CapitulosDIA.Core;
using WFrms = System.Windows.Forms;

namespace CapitulosDIA
{
    public class EditSeccionView : WFrms.Form
    {
        public EditSeccionView(Capitulo cap, string seccion)
        {
            this.Build(cap, seccion);
        }

        void Build(Capitulo cap, string s)
        {
            this.seccionEditar=cap.recuperarSeccion(s);
            var mainPanel = new WFrms.TableLayoutPanel
            {
                Dock = WFrms.DockStyle.Fill
            };
            
            mainPanel.Controls.Add(this.BuildTexto());
            mainPanel.Controls.Add(this.BuildNotas());
            
            mainPanel.Controls.Add(this.BuildBtnAddSec());
            
            //WFrms.MessageBox.Show(seccionEditar.ToString());
            
            this.Controls.Add(mainPanel);
        }

        WFrms.Panel BuildNotas()
        {
            var pnl = new WFrms.Panel {Dock = WFrms.DockStyle.Top};

            this.txtNotas = new WFrms.TextBox()
            {
                PlaceholderText = "Notas",
                Text = seccionEditar.notas
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
                Text = seccionEditar.texto
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
            this.btnEditSec = new WFrms.Button
            {
                Dock = WFrms.DockStyle.Fill,
                Text = "Editar"
            };
            
            pnl.Controls.Add(this.btnEditSec);
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
        
        public WFrms.Button btnEditSec { get; private set; }
        private Seccion seccionEditar;

    }
}
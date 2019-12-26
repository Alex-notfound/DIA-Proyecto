using System.Collections.Generic;
using System.Drawing;
using CapitulosDIA.Core;
using WFrms = System.Windows.Forms;

namespace CapitulosDIA
{
    public class PanelDataGridView : WFrms.Form
    {
        public PanelDataGridView(RegistroCapitulos rc)
        {
            this.Build(rc.capitulos);
        }

        void Build(List<Capitulo> caps)
        {
            var mainPanel = new WFrms.TableLayoutPanel
            {
                Dock = WFrms.DockStyle.Fill
            };
            
            mainPanel.Controls.Add(this.BuildDataGrid(caps));
            mainPanel.Controls.Add(this.BuildAddBtn());
            mainPanel.Controls.Add(this.BuildEditBtn());
            mainPanel.Controls.Add(this.BuildSeccionBtn());
            mainPanel.Controls.Add(this.BuildListBtn());
            
            this.Controls.Add(mainPanel);
        }

        WFrms.Panel BuildEditBtn()
        {
            var pnl = new WFrms.Panel
            {
                Dock = WFrms.DockStyle.Top
            };
            this.editBtn = new WFrms.Button
            {
                Dock = WFrms.DockStyle.Fill,
                Text = "Editar"
            };

            pnl.Controls.Add(this.editBtn);
            return pnl;
        }
        
        WFrms.Panel BuildAddBtn()
        {
            var pnl = new WFrms.Panel
            {
                Dock = WFrms.DockStyle.Top
            };
            this.addBtn = new WFrms.Button
            {
                Dock = WFrms.DockStyle.Fill,
                Text = "Añadir"
            };

            pnl.Controls.Add(this.addBtn);
            return pnl;
        }
        
        WFrms.Panel BuildListBtn()
        {
            var pnl = new WFrms.Panel
            {
                Dock = WFrms.DockStyle.Top
            };
            
            this.listBtn = new WFrms.Button
            {
                Dock = WFrms.DockStyle.Fill,
                Text = "Listar"
            };

            pnl.Controls.Add(this.listBtn);
            return pnl;
        }
        
        WFrms.Panel BuildSeccionBtn()
        {
            var pnl = new WFrms.Panel
            {
                Dock = WFrms.DockStyle.Top
            };
            
            this.seccionBtn = new WFrms.Button
            {
                Dock = WFrms.DockStyle.Fill,
                Text = "Añadir seccion"
            };

            pnl.Controls.Add(this.seccionBtn);
            return pnl;
        }
        
        WFrms.Panel BuildDataGrid(List<Capitulo> caps)
        {
            var pnl = new WFrms.Panel
            {
                Dock = WFrms.DockStyle.Fill,
                Height = 200
            };
            
            this.dataGrid = new WFrms.DataGridView()
            {
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = WFrms.DataGridViewAutoSizeColumnsMode.Fill,
                Dock = WFrms.DockStyle.Fill,
                MultiSelect = false,
                SelectionMode = WFrms.DataGridViewSelectionMode.FullRowSelect,
                ColumnCount = 2,
                ColumnHeadersVisible = true,
                Columns =
                {
                    [0] =
                    {
                        Name = "Capitulo",
                    },
                    [1] =
                    {
                        Name = "Texto"
                    }

                },
                ReadOnly = true
            };
            foreach (var cap in caps)
            {
                this.dataGrid.Rows.Add(cap.titulo,cap.notas);
            }
            
            pnl.Controls.Add(this.dataGrid);
            return pnl;
        }
        

        public WFrms.Button editBtn { get; private set; }

        public WFrms.Button addBtn { get; private set; }
        
        public WFrms.Button listBtn { get; private set; }
        
        public WFrms.Button seccionBtn { get; private set; }

        public WFrms.DataGridView dataGrid { get; private set; }

    }
}
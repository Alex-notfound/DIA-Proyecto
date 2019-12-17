using NovelasAPP.Core.Capitulos;
using System.Collections.Generic;
using System.Drawing;
using WFrms = System.Windows.Forms;

namespace NovelasAPP.UI.Views
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
                Dock = WFrms.DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 2
            };

            WFrms.Panel gridPanel = this.BuildDataGrid(caps);

            mainPanel.Controls.Add(gridPanel, 0, 1);
            mainPanel.Controls.Add(this.BuildAddBtn(), 0, 0);
            mainPanel.Controls.Add(this.BuildEditBtn(), 1, 0);
            mainPanel.Controls.Add(this.BuildSeccionBtn(), 2, 0);
            mainPanel.Controls.Add(this.BuildListBtn(), 3, 0);
            
            mainPanel.SetColumnSpan(gridPanel, 4);

            this.Controls.Add(mainPanel);
            this.MinimumSize = new Size(600, 200);
            this.Text = "Capitulos";
        }

        WFrms.Panel BuildEditBtn()
        {
            var pnl = new WFrms.Panel
            {
                AutoSize = true,
                Dock = WFrms.DockStyle.Top
            };
            this.editBtn = new WFrms.Button
            {
                AutoSize = true,
                Text = "Editar"
            };

            pnl.Controls.Add(this.editBtn);
            return pnl;
        }
        
        WFrms.Panel BuildAddBtn()
        {
            var pnl = new WFrms.Panel
            {
                AutoSize = true,
                Dock = WFrms.DockStyle.Top
            };
            this.addBtn = new WFrms.Button
            {
                AutoSize = true,
                Text = "Añadir"
            };

            pnl.Controls.Add(this.addBtn);
            return pnl;
        }
        
        WFrms.Panel BuildListBtn()
        {
            var pnl = new WFrms.Panel
            {
                AutoSize = true,
                Dock = WFrms.DockStyle.Top
            };
            
            this.listBtn = new WFrms.Button
            {
                AutoSize = true,
                Text = "Graficas"
            };

            pnl.Controls.Add(this.listBtn);
            return pnl;
        }
        
        WFrms.Panel BuildSeccionBtn()
        {
            var pnl = new WFrms.Panel
            {
                AutoSize = true,
                Dock = WFrms.DockStyle.Top
            };
            
            this.seccionBtn = new WFrms.Button
            {
                AutoSize = true,
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
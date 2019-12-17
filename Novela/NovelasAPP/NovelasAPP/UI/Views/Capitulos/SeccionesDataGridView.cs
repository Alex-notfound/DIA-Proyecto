using NovelasAPP.Core.Capitulos;
using System.Collections.Generic;
using System.Drawing;
using WFrms = System.Windows.Forms;

namespace NovelasAPP.UI.Views
{
    public class SeccionesDataGridView : WFrms.Form
    {
        public SeccionesDataGridView(RegistroCapitulos rc, Capitulo cap)
        {
            this.Build(cap);
        }

        void Build(Capitulo cap)
        {
            var mainPanel = new WFrms.TableLayoutPanel
            {
                Dock = WFrms.DockStyle.Fill
            };
            
            mainPanel.Controls.Add(this.BuildDataGrid(cap));
            //mainPanel.Controls.Add(this.BuildAddBtn());
            //mainPanel.Show();
            this.Controls.Add(mainPanel);
        }


        /*
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
        */
        
        
        WFrms.Panel BuildDataGrid(Capitulo capitulo)
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
                        Name = "Texto",
                    },
                    [1] =
                    {
                        Name = "Notas"
                    }

                },
                ReadOnly = true
            };
            foreach (var cap in capitulo.secciones)
            {
                this.dataGrid.Rows.Add(cap.texto,cap.notas);
            }
            
            pnl.Controls.Add(this.dataGrid);
            return pnl;
        }
        
        
        //public WFrms.Button addBtn { get; private set; }
        
        public WFrms.DataGridView dataGrid { get; private set; }

    }
}
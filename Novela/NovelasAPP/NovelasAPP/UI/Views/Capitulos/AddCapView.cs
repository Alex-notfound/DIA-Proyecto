using WFrms = System.Windows.Forms;

namespace NovelasAPP.UI.Views
{
    public class AddCapView : WFrms.Form
    {
        public AddCapView()
        {
            this.Build();
        }

        void Build()
        {
            var mainPanel = new WFrms.TableLayoutPanel
            {
                RowCount = 3,
                Dock = WFrms.DockStyle.Fill
            };
            
            mainPanel.Controls.Add(this.BuildTitulo(), 0, 0);
            mainPanel.Controls.Add(this.BuildNotas(), 0, 1);
            mainPanel.Controls.Add(this.BuildBtnAddCap(), 0, 2);
            
            this.Controls.Add(mainPanel);
        }
        
        WFrms.Panel BuildTitulo()
        {
            var pnl = new WFrms.Panel 
            {
                Dock = WFrms.DockStyle.Fill,
                AutoSize = true,
            };

            this.txtTitulo = new WFrms.TextBox()
            {
                PlaceholderText = "Titulo"
            };
            pnl.Controls.Add(this.txtTitulo);
            return pnl;
        }
        
        WFrms.Panel BuildNotas()
        {
            var pnl = new WFrms.Panel {
                Dock = WFrms.DockStyle.Top,
                AutoSize = true
            };

            this.txtNotas = new WFrms.TextBox()
            {
                PlaceholderText = "Notas"
            };
            pnl.Controls.Add(this.txtNotas);
            return pnl;
        }
        
        WFrms.Panel BuildBtnAddCap()
        {
            var pnl = new WFrms.Panel
            {
                AutoSize = true
            };
            this.btnAddCap = new WFrms.Button
            {
                AutoSize = true,
                Text = "Añadir"
            };
            
            pnl.Controls.Add(this.btnAddCap);
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
        
        public WFrms.Button btnAddCap { get; private set; }
        
    }
}
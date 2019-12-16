using WFrms = System.Windows.Forms;

namespace CapitulosDIA
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
                Dock = WFrms.DockStyle.Fill
            };
            
            mainPanel.Controls.Add(this.BuildTitulo());
            mainPanel.Controls.Add(this.BuildNotas());
            mainPanel.Controls.Add(this.BuildBtnAddCap());
            
            this.Controls.Add(mainPanel);
        }
        
        WFrms.Panel BuildTitulo()
        {
            var pnl = new WFrms.Panel {Dock = WFrms.DockStyle.Top};

            this.txtTitulo = new WFrms.TextBox()
            {
                PlaceholderText = "Titulo"
            };
            pnl.Controls.Add(this.txtTitulo);
            return pnl;
        }
        
        WFrms.Panel BuildNotas()
        {
            var pnl = new WFrms.Panel {Dock = WFrms.DockStyle.Top};

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
                Dock = WFrms.DockStyle.Top
            };
            this.btnAddCap = new WFrms.Button
            {
                Dock = WFrms.DockStyle.Fill,
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
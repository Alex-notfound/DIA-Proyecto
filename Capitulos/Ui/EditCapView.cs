using WFrms = System.Windows.Forms;
using CapitulosDIA.Core;
namespace CapitulosDIA
{
    public class EditCapView : WFrms.Form
    {
        public EditCapView(Capitulo cap)
        {
            this.c = cap;
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
                PlaceholderText = "Titulo",
                Text = c.titulo,
                Dock = WFrms.DockStyle.Fill
            };
            pnl.Controls.Add(this.txtTitulo);
            return pnl;
        }
        
        WFrms.Panel BuildNotas()
        {
            var pnl = new WFrms.Panel {Dock = WFrms.DockStyle.Top};

            this.txtNotas = new WFrms.TextBox()
            {
                PlaceholderText = "Notas",
                Text = c.notas,
                Dock = WFrms.DockStyle.Fill
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
                Text = "Editar"
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

        public Capitulo c;
        public string titulo;
        public string notas;

    }
}
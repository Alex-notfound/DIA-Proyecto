using NovelasAPP.Core.Capitulos;
using NovelasAPP.Core.HTML;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NovelasAPP.UI
{
    public partial class MainWindowView : Form
    {
        public MainWindowView()
        {
            this.Build();
        }

        void Build()
        {
            TableLayoutPanel mainPanel = new TableLayoutPanel
            {
                ColumnCount = 1,
                RowCount = 3
            };

            this.BtnCapitulos = new Button
            {
                AutoSize = true,
                Text = "Capitulos"
            };

            this.BtnPersonajes = new Button
            {
                AutoSize = true,
                Text = "Personajes"
            };

            this.BtnHTML = new Button
            {
                AutoSize = true,
                Text = "Convertir libro a HTML"
            };

            BtnHTML.Click += (sender, args) => ParserHTML.ParseLibro(Core.Capitulos.RegistroCapitulos.RecuperaXml().capitulos);

            mainPanel.Controls.Add(this.BtnCapitulos, 0, 0);
            mainPanel.Controls.Add(this.BtnPersonajes, 0, 1);
            mainPanel.Controls.Add(this.BtnHTML, 0, 2);

            this.Controls.Add(mainPanel);
            this.Text = "NOVELAS APP";
        }

        public Button BtnCapitulos
        {
            get; set;
        }

        public Button BtnPersonajes
        {
            get; set;
        }

        public Button BtnHTML
        {
            get; set;
        }
    }
}

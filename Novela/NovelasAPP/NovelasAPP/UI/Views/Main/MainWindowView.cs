using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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

            this.btnCapitulos = new Button
            {
                AutoSize = true,
                Text = "Capitulos"
            };

            this.btnPersonajes = new Button
            {
                AutoSize = true,
                Text = "Personajes"
            };

            this.btnHTML = new Button
            {
                AutoSize = true,
                Text = "Convertir libro a HTML"
            };

            mainPanel.Controls.Add(this.btnCapitulos, 0, 0);
            mainPanel.Controls.Add(this.btnPersonajes, 0, 1);
            mainPanel.Controls.Add(this.btnHTML, 0, 2);

            this.Controls.Add(mainPanel);
        }

        public Button btnCapitulos
        {
            get; set;
        }

        public Button btnPersonajes
        {
            get; set;
        }

        public Button btnHTML
        {
            get; set;
        }
    }
}

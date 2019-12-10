using System;
using System.Windows.Forms;
using System.Drawing;

namespace ParserHTML
{
    public class MainWindow : Form
    {
        public MainWindow()
        {
            this.Build();
        }

        private void Build()
        {
            var textArea = new RichTextBox();
            textArea.Multiline = true;
            
            var pnlTable = new TableLayoutPanel();
            
            pnlTable.SuspendLayout();
            pnlTable.Dock = DockStyle.Fill;

            var btFirst = new Button
            {
                Text = "Generar HTML",
                Dock = DockStyle.Top
            };
            btFirst.ForeColor = Color.White;
            btFirst.Click += (sender, args) => ActionParse(textArea.Text);
           
            pnlTable.Controls.Add(btFirst);
            textArea.Parent = pnlTable;
            textArea.Dock = DockStyle.Fill;

            pnlTable.ResumeLayout(false);
            this.Controls.Add(pnlTable);

            textArea.BackColor = Color.FromArgb(63, 63, 63);
            textArea.SelectionColor = Color.White;
            this.BackColor = Color.FromArgb(63,63,63);

            this.MinimumSize = new Size(320, 240);
            this.Text = "TextBook";
        }

        private void ActionParse(string texto)
        {
            new HTMLWindow(ParserHTML.CastToHTML(texto)).Show();
        }
    }
}

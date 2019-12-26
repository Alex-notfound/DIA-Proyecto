using System.Windows.Forms;
using System.Drawing;

namespace ParserHTML
{
    internal class HTMLWindow : Form
    {
        public HTMLWindow(string texto)
        {
            var textArea = new RichTextBox
            {
                Multiline = true,
                BackColor = Color.FromArgb(63, 63, 63),
                ForeColor = Color.White,
                Text = texto
            };

            var pnlTable = new TableLayoutPanel();

            pnlTable.SuspendLayout();
            pnlTable.Dock = DockStyle.Fill;

            textArea.Parent = pnlTable;
            textArea.Dock = DockStyle.Fill;

            pnlTable.ResumeLayout(false);
            this.Controls.Add(pnlTable);

            this.BackColor = Color.FromArgb(63, 63, 63);

            this.MinimumSize = new Size(320, 240);
            this.Text = "HTML Generated";
        }
    }
}
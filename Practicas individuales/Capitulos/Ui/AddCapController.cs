using System.Threading;
using CapitulosDIA.Core;
using WFrms = System.Windows.Forms;

namespace CapitulosDIA
{
    public class AddCapController
    {
        public AddCapController(RegistroCapitulos rc)
        {
            this.View = new AddCapView();
            
            
            this.View.btnAddCap.Click +=
                (sender, e) => this.AddCap(rc);
            this.View.ShowDialog();
            
        }
        
        public AddCapView View
        {
            get; private set;
        }

        public void AddCap(RegistroCapitulos rc)
        {
            rc.Add(new Capitulo(this.View.txtTitulo.Text, this.View.txtNotas.Text));
            this.View.Close();
        }
    }
}
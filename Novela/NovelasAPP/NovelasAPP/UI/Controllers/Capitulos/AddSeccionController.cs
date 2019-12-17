using NovelasAPP.Core.Capitulos;
using NovelasAPP.UI.Views;
using System;
using System.Collections.Generic;
using WFrms = System.Windows.Forms;

namespace NovelasAPP.UI.Controllers
{
    public class AddSeccionController
    {
        public AddSeccionController(RegistroCapitulos rc, string capitulo)
        {
            this.View = new AddSeccionView();
            this.View.Show();
            
            this.View.btnAddSec.Click +=
                (sender, e) => this.AddSec(rc, capitulo);
        }
        
        public AddSeccionView View
        {
            get; private set;
        }

        public void AddSec(RegistroCapitulos rc, string capitulo)
        {
            rc.AddSeccion(capitulo, this.View.txtNotas.Text, this.View.txtTitulo.Text);
            this.View.Close();
        }
    }
}
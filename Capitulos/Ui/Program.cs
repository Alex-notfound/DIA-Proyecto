using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WFrms = System.Windows.Forms;

namespace CapitulosDIA
{
    public static class Program
    {
        
        public static void Main()
        {
            WFrms.Application.Run(new PanelDataGridController().View);
            //WFrms.Application.Run(new MainWindowController().View);
        }
    }
}
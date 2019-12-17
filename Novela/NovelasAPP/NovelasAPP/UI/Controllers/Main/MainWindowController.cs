using NovelasAPP.UI.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace NovelasAPP.UI.Controllers
{
    class MainWindowController
    {
        public MainWindowController()
        {
            this.Build();
        }

        void Build()
        {
            MainView = new MainWindowView();
            MainView.BtnPersonajes.Click += (sender, args) =>
            {
                this.BuildPersonajes();
                MainView.Hide();
            };
            MainView.BtnCapitulos.Click += (sender, args) =>
            {
                this.BuildCapitulos();
                MainView.Hide();
            };
        }

        void BuildCapitulos()
        {
            capController = new PanelDataGridController();
            PanelDataGridView view = capController.View;
            view.Show();
            view.FormClosed += (sender, args) => MainView.Show();
        }

        void BuildPersonajes()
        {
            pejController = new PersonajesController();
            PersonajesView view = pejController.View;
            view.Show();
            view.FormClosed += (sender, args) => MainView.Show();
        }

        public MainWindowView MainView
        {
            get; set;
        }

        public PersonajesController pejController
        {
            get; private set;
        }

        public PanelDataGridController capController
        {
            get; private set;
        }
    }

}

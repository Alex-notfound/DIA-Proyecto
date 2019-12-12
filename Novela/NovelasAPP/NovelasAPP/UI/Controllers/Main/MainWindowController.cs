using PersonajesNovelas;
using PersonajesNovelas.UI;
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
            mainView = new MainWindowView();

            mainView.btnPersonajes.Click += (sender, args) => this.BuildPersonajes(new PersonajesController()); mainView.Hide();
        }

        void BuildPersonajes(PersonajesController pj)
        {
            PersonajesView view = pj.View;

            view.Show();

            view.FormClosed += (sender, args) => mainView.Show();
        }

        


        public MainWindowView mainView
        {
            get; set;
        }
    }

}

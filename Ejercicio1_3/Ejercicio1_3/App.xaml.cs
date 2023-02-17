using Ejercicio1_3.Controlador;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio1_3
{
    public partial class App : Application
    {

        static BaseDeDatos db;

        public static BaseDeDatos DBase
        {
            get
            {
                if(db == null)
                {
                    String FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DBGente.db3");
                    db = new BaseDeDatos(FolderPath);
                }
                return db;
            }
        }



        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

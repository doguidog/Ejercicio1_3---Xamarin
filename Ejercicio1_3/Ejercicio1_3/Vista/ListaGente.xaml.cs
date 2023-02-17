using Ejercicio1_3.Modelo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio1_3.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaGente : ContentPage
    {
        public ListaGente()
        {
            InitializeComponent();
        }

        private async void Cargar_Registros()
        {
            var registros = await App.DBase.getListGente();
            Lista.ItemsSource = registros;
        }
        private async void mItemDelete_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Confirmacion", "¿Desea eliminar el registro?", "Si", "No");
            Debug.WriteLine("Answer: " + answer);

            if (answer == true)
            {
                var id = (Gente)(sender as MenuItem).CommandParameter;
                var result = await App.DBase.DeleteGente(id);

                if (result == 1)
                {
                    await DisplayAlert("Aviso", "Registro Eliminado", "OK");
                    Cargar_Registros();
                }
                else
                {
                    await DisplayAlert("Aviso", "Revisa", "OK");
                }
            };
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            Lista.ItemsSource = await App.DBase.getListGente();
        }

        private async void Lista_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var registro = (Gente)e.Item;

            bool answer = await DisplayAlert("Confirmacion", "¿Desea editar el registro?", "si", "no");
            Debug.WriteLine("answer: " + answer);

            if (answer == true)
            {
                MainPage pagina = new MainPage();
                pagina.BindingContext = registro;
                await Navigation.PushAsync(pagina);
            };
        }
    }
}
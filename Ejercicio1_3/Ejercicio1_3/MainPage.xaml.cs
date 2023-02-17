using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Ejercicio1_3.Modelo;
using Ejercicio1_3.Vista;

namespace Ejercicio1_3
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            var gente = new Gente
            {
                id = 0,
                nombres = txtNombre.Text,
                apellidos = txtApellido.Text,
                edad = txtEdad.Text,
                correo = txtEmail.Text,
                direccion = txtDireccion.Text,
            };

            var resultado = await App.DBase.GuardarGente(gente);

            if(resultado > 0)
            {
                await DisplayAlert("aviso", "Registro Guardado", "OK");
            }
            else
            {
                await DisplayAlert("aviso", "Error,no se actualizo", "OK");
            }

        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            var gente = new Gente
            {
                id = Convert.ToInt32(txtId.Text),
                nombres = txtNombre.Text,
                apellidos = txtApellido.Text,
                edad = txtEdad.Text,
                correo = txtEmail.Text,
                direccion = txtDireccion.Text,
            };

            var resultado = await App.DBase.GuardarGente(gente);

            if (resultado > 0)
            {
                await DisplayAlert("aviso", "Registro Actualizado", "OK");
            }
            else
            {
                await DisplayAlert("aviso", "Error,no se actualizo", "OK");
            }
        }

        private async void toolLista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaGente());
        }
    }
}

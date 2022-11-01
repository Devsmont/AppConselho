using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using AppConselho.Model;
using AppConselho.Services;

namespace AppConselho
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Title = "Concelho";

            this.BindingContext = new Conselhos();
        }

        private async void BtnConselho_Clicked(object sender, EventArgs e)
        {
            try
            {
                Conselhos conselhos = await DataService.GetConselhos();
                this.BindingContext = conselhos;
                BtnConselho.Text = "Novo Conselho";
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "ok");
            }
        }
    }
}

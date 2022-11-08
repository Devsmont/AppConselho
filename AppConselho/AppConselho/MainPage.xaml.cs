using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using AppConselho.Model;
using AppConselho.Services;
using Xamarin.Forms.Xaml;

namespace AppConselho
{
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class MainPage : ContentPage
    {
        public async void Defeault()
        {
            Conselhos Conselho = await DataService.getConselhoByNum("2");

            this.BindingContext = Conselho;
        }
        public MainPage()
        {
            InitializeComponent();
            

            this.BindingContext = new Conselhos();
            Defeault();
        }

        private async void BtnConselho_Clicked(object sender, EventArgs e)
        {
            try
            {
               if(!String.IsNullOrEmpty(ent_Num.Text))
                {
                    Conselhos Conselho = await DataService.getConselhoByNum(ent_Num.Text);

                    this.BindingContext = Conselho;

                }else
                    {
                    Conselhos Conselho = await DataService.GetConselhos();
                    this.BindingContext = Conselho;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "ok");
            }
        }
    }
}

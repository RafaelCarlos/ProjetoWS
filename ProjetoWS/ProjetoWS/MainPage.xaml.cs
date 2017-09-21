using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjetoWS
{
    public partial class MainPage : ContentPage
    {
        Cep cep;
        public MainPage()
        {
            InitializeComponent();
            cep = new Cep();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            atividade.IsVisible = true;
            atividade.IsRunning = true;
            //Validação de tamanho
            if (txtCep.Text != null && txtCep.Text.Length == 8)
            {
                //Consumir serviço
                //lblResultado.Text = await ServicoCEP.BuscaCEP(txtCep.Text);
                Cep resultado = await ServicoCEP.BuscaCEP(txtCep.Text);

                lblCep.Text = "Cep: " + resultado.cep;
                lblEndereco.Text = "Endereço: " + resultado.logradouro;
                lblComplemento.Text = "Complemento: " + resultado.complemento;
                lblBairro.Text = "Bairro: " + resultado.bairro;
                lblCidade.Text = "Cidade: " + resultado.localidade;
                lblUf.Text = "UF: " + resultado.uf;
                atividade.IsVisible = false;
                atividade.IsRunning = false;

            }
            else
            {
                DisplayAlert("ERRO", "CEP informado é inválido!", "OK");

                //lblResultado.Text = "O CEP informado é inválido!";
                //lblResultado.TextColor = Color.Red;
            }
        }
    }
}

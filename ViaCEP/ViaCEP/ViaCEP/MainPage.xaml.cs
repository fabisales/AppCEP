using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ViaCEP.Servico.Modelo;
using ViaCEP.Servico;

namespace ViaCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {

            //  Lógica do programa
            string cep = CEP.Text.Trim();

            if (isValidCEP(cep))
            {
                Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                RESULTADO.Text = string.Format("Endereço: {0} - {1},{2},{3}", end.logradouro, end.bairro, end.localidade, end.uf);
            }
        }

        //  Validações
        private bool isValidCEP(string cep)
        {
            bool valido = true;

            if (cep.Length != 8)
            {
                DisplayAlert("Erro", "CEP Inválido! O CEP deve conter 8 caracteres.", "OK");
                valido = false;
            }

            int NovoCEP = 0;
            if (!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("Erro", "CEP Inválido! O CEP deve conter apenas números.", "OK");
                valido = false;
            }

            return valido;
        }
    }
}

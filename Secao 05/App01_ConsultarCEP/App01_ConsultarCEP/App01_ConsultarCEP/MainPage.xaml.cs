using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico.Modelo;
using App01_ConsultarCEP.Servico;

namespace App01_ConsultarCEP
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
            //TODO - LOGICA DO PROGRAMA

            //TODO - VALIDACOES



            string cep = CEP.Text.Trim();
            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço é {0} - {1} - {2} - {3}", end.logradouro, end.bairro, end.localidade, end.uf);
                    }
                    else
                    {
                        DisplayAlert("Erro", "O CEP " + cep + "não foi encontrado!", "OK");
                    }
                    

                }catch(Exception e)
                {
                    DisplayAlert("Erro", e.Message, "OK");
                }
            }
        }

        private bool isValidCEP(string cep)
        {

            bool valido = true;
            if (cep.Length != 8)
            {
                DisplayAlert("Erro", "Cep Invalido! O CEP deve conter 8 caracteres.", "OK");
                valido = false;
            }
            int NovoCep = 0;
            if (!int.TryParse(cep, out NovoCep))
            {
                DisplayAlert("Erro", "Cep Invalido! O CEP ser numerico", "OK");
                valido = false;
            }

            return valido;

        }
    }


}

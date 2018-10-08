using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using ViaCEP.Servico.Modelo;
using Newtonsoft.Json;

namespace ViaCEP
{
    public class ViaCEPServico
    {
        private static string EndereçoURL = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string NovoEnderecoURL = string.Format(EndereçoURL, cep);

            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            return end;
        }
    }
}

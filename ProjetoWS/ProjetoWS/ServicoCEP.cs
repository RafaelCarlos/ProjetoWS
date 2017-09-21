using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace ProjetoWS
{
    public class ServicoCEP
    {
        public static string UrlBase = "https://viacep.com.br/ws/{0}/json/";

        public async static Task<Cep> BuscaCEP(string cep)
        {
            string URL = string.Format(UrlBase, cep);
            HttpClient http = new HttpClient();
            //Esperando para poder obter o resultado.
            string json = await http.GetStringAsync(URL);

            //Deserializando objeto.
            Cep objetoCEP = JsonConvert.DeserializeObject<Cep>(json);
            //string resultado = string.Format("CEP: {0} " + "\n" +
            //                                "UF: {1}" + "\n" +
            //                                "Endereco: {2}  " + "\n" +
            //                                "Cidade: {3}", objetoCEP.cep, objetoCEP.uf, objetoCEP.logradouro, objetoCEP.localidade);

            //string resultado = string.Format("CEP: {0} " + "\n" +
            //                                "UF: {1}" + "\n" +
            //                                "Endereco: {2}  " + "\n" +
            //                                "Cidade: {3}", objetoCEP.cep, objetoCEP.uf, objetoCEP.logradouro, objetoCEP.localidade);



            return objetoCEP;
        }
    }
}

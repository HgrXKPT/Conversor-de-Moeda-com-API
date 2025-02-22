using Newtonsoft.Json;
using static CurrencyConvesor.RespostaAPI;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Globalization;
using CurrencyConvesor;

class Program {
    private static readonly HttpClient client = new HttpClient();

    static async Task Main(string[] args) {
        try {
            Console.WriteLine("Escolha uma moeda para converter");
            string fromCurrency = Console.ReadLine();
            Console.WriteLine("Para qual moeda deseja converter?");
            string toCurrency = Console.ReadLine();
            string url = $"https://economia.awesomeapi.com.br/json/last/{fromCurrency}-{toCurrency}";

            var response = await client.GetStringAsync(url);
            var exchangeRateResponse = JsonConvert.DeserializeObject<Dictionary<string,ExchangeRateResponse>>(response);
            string key = $"{fromCurrency}{toCurrency}";

            Console.WriteLine($"Escolha um valor em {fromCurrency} Para ser convertido. Obs: por em numero real");
            decimal valor = decimal.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
            Console.WriteLine(valor);





            if(exchangeRateResponse.TryGetValue($"{fromCurrency + toCurrency}",out ExchangeRateResponse rate)) {
                Console.WriteLine($"Taxa de câmbio de {fromCurrency} para {toCurrency}: {rate.Bid}");
                decimal result = valor * rate.Bid;

                Console.WriteLine($"Convertendo o valor que foi colocado ficaria: {result:F2}");
            } else {
                Console.WriteLine($"Não foi possível encontrar a taxa de câmbio para {fromCurrency}-{toCurrency}");
            }
        } catch(HttpRequestException ex) {
            Console.WriteLine($"Alguma das moedas não existem, Código de error: {ex}");
        } catch(Exception ex) {
            Console.WriteLine($"Algum error inusitado aconteceu {ex}");
        }

        
    }
}

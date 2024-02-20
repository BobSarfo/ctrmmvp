using System.Text;
using System.Text.Json;
using ctrmmvp.Data.Currency;
using ctrmmvp.Services.Interface;

namespace ctrmmvp.Services.Implementation
{
    public class CurrenciesService : ICurrenciesService
    {
        public async Task<CurrencyRates> GetCurrenciesAsync(string currency, string token)
        {
            string url = "http://acumatica.local/dev2/entity/CTRM/2020.1/CurrencyRates?$expand=EffectiveRates";

            var toCurrency = new ToCurrencyRequest
            {
                ToCurrency = new Value { value = currency }
            };

            string jsonContent = JsonSerializer.Serialize(toCurrency);

            using HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync(url, httpContent);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                // Handle the response body
                var currencyRates = JsonSerializer.Deserialize<CurrencyRates>(responseBody);
                return currencyRates;
            }

            return null;
        }
    }
}
using ctrmmvp.Data.Currency;
using ctrmmvp.DTOs.Currency;
using System.Text;
using System.Text.Json;

namespace ctrmmvp.Services.Implementation
{
    public static class CurrenciesService
    {
        public static async Task<CurrencyRates> GetCurrenciesToAsync(string currency, string token)
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

        public static async Task<IEnumerable<Currency>> GetCurrenciesAsync(string token)
        {
            string url = "http://acumatica.local/dev2/entity/Default/20.200.001/Currency";

            using HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                // Handle the response body
                var currencies = JsonSerializer.Deserialize<List<Currency>>(responseBody);

                return currencies.Where(x => x.UseForAccounting.value == true);
            }

            return null;
        }
    }
}
using System.Text;
using System.Text.Json;
using ctrmmvp.Data.Currency;

public class CurrenciesService
{
    public async Task<CurrencyRates> GetCurrenciesAsync(string currency)
    {
        string url = "http://acumatica.local/dev2/entity/CTRM/2020.1/CurrencyRates?$expand=EffectiveRates";
        string bearerToken = "1c229352046ddbf2da3f53ec3572c83e";
        
        var toCurrency = new ToCurrency
        {
            Value = new Value { value = currency }
        };

        string jsonContent = JsonSerializer.Serialize(toCurrency);

        using HttpClient client = new HttpClient();

        client.DefaultRequestHeaders.Clear();
        client.DefaultRequestHeaders.Add("Accept", "application/json");
        client.DefaultRequestHeaders.Add("Content-Type", "application/json");
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");

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

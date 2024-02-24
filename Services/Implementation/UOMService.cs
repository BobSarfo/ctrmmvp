using ctrmmvp.DTOs.UOM;
using System.Text.Json;

namespace ctrmmvp.Services.Implementation
{
    public class UOMService
    {
        public static async Task<object> GetUOMAsync(string token, string toUOM = "", string fromUOM = "")
        {
            string url = $"http://acumatica.local/dev2/(W(5))//entity/Default/22.200.001/UnitsOfMeasure?";

            var isFiltered = false;
            if (!string.IsNullOrEmpty(toUOM))
            {
                url += "$filter= ";
                url += $"{url} ToUOM eq {toUOM}";
                isFiltered = true;
            }

            if (!string.IsNullOrEmpty(fromUOM))
            {
                if (!isFiltered)
                {
                    url += $"$filter= FromUOM eq {fromUOM}";
                }
                else
                {
                    url += $"and FromUOM eq {fromUOM}";
                }
            }

            using HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                // Handle the response body
                var currencyRates = JsonSerializer.Deserialize<List<AcuUom>>(responseBody);
                return currencyRates;
            }

            return null;
        }
    }
}
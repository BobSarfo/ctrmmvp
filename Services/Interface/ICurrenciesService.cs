using ctrmmvp.Data.Currency;

namespace ctrmmvp.Services.Interface
{
    public interface ICurrenciesService
    {
        Task<CurrencyRates> GetCurrenciesAsync(string currency, string token);
    }
}
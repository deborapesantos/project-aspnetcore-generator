using MarketplaceWorker.Core.Domain.Enum;

namespace MarketplaceWorker.Core.Domain.Interfaces
{
    public interface IHttpClientHelper
    {
        Task<string> PostJsonAsync(string urlAPI, string jsonBody, EnumTypeAuthorization enumType, string token = "", string name = "");
        string PostJson(string urlAPI, string jsonBody, EnumTypeAuthorization enumType, string token = "", string name = "");
        Task<string> GetAsync(string urlAPI, EnumTypeAuthorization enumType = EnumTypeAuthorization.bearer_Token, string token = "", string name = "");
        Task<string> PutJsonAsync(string urlAPI, string jsonBody, EnumTypeAuthorization enumType, string token = "", string name = "");

    }
}

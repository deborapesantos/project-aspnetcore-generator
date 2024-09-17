using TemplateHexagonal.Core.Domain.Enum;
using TemplateHexagonal.Core.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using System.Text;

namespace TemplateHexagonal.Core.Application.Shared.Helpers
{
    public class HttpClientHelper : IHttpClientHelper
    {
        private readonly ILogger<HttpClientHelper> _logger;

        public HttpClientHelper(ILogger<HttpClientHelper> logger)
        {
            _logger = logger;
        }

        public async Task<string> PostJsonAsync(string urlAPI, string jsonBody, EnumTypeAuthorization enumType = EnumTypeAuthorization.bearer_Token, string token = "", string name = "")
        {
            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromMinutes(5);

                if (!string.IsNullOrEmpty(token))
                    SetAuthorization(client, enumType, token, name);

                using (var content = new StringContent(jsonBody, Encoding.UTF8, "application/json"))
                {
                    var message = await client.PostAsync(urlAPI, content);

                    if (!message.IsSuccessStatusCode)
                    {
                        _logger.LogError("POST request to {Url} failed with status code {StatusCode}. Response: {Response}", urlAPI, message.StatusCode, await message.Content.ReadAsStringAsync());
                    }

                    return await message.Content.ReadAsStringAsync();
                }
            }
        }

        public string PostJson(string urlAPI, string jsonBody, EnumTypeAuthorization enumType = EnumTypeAuthorization.bearer_Token, string token = "", string name = "")
        {
            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromMinutes(5);

                if (!string.IsNullOrEmpty(token))
                    SetAuthorization(client, enumType, token, name);

                using (var content = new StringContent(jsonBody, Encoding.UTF8, "application/json"))
                {
                    var message = client.PostAsync(urlAPI, content).Result;

                    if (!message.IsSuccessStatusCode)
                    {
                        _logger.LogError("POST request to {Url} failed with status code {StatusCode}. Response: {Response}", urlAPI, message.StatusCode, message.Content.ReadAsStringAsync().Result);
                    }

                    return message.Content.ReadAsStringAsync().Result;
                }
            }
        }

        public async Task<string> GetAsync(string urlAPI, EnumTypeAuthorization enumType = EnumTypeAuthorization.bearer_Token, string token = "",string name="")
        {
            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromMinutes(5);

                if (!string.IsNullOrEmpty(token))
                    SetAuthorization(client, enumType, token, name);

                var message = await client.GetAsync(urlAPI);

                if (!message.IsSuccessStatusCode)
                {
                    _logger.LogError("GET request to {Url} failed with status code {StatusCode}. Response: {Response}", urlAPI, message.StatusCode, await message.Content.ReadAsStringAsync());
                }

                return await message.Content.ReadAsStringAsync();
            }
        }

        public async Task<string> PutJsonAsync(string urlAPI, string jsonBody, EnumTypeAuthorization enumType = EnumTypeAuthorization.bearer_Token, string token = "", string name = "")
        {
            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromMinutes(5);

                if (!string.IsNullOrEmpty(token))
                    SetAuthorization(client, enumType, token, name);

                using (var content = jsonBody == null ? null : new StringContent(jsonBody, Encoding.UTF8, "application/json"))
                {
                    var message = await client.PutAsync(urlAPI, content);

                    if (!message.IsSuccessStatusCode)
                    {
                        _logger.LogError("PUT request to {Url} failed with status code {StatusCode}. Response: {Response}", urlAPI, message.StatusCode, await message.Content.ReadAsStringAsync());
                    }

                    return await message.Content.ReadAsStringAsync();
                }
            }
        }

        private void SetAuthorization(HttpClient client, EnumTypeAuthorization enumType, string token,string name)
        {
            if (enumType == EnumTypeAuthorization.basic_Auth)
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", token);
            else if(enumType == EnumTypeAuthorization.bearer_Token)
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            else
                client.DefaultRequestHeaders.Add(name, token);

        }
    }
}

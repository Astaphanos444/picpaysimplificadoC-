using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace app.src.Service.Autorizador
{
    public class AutorizadorService : IAutorizadorService
    {
        private readonly HttpClient _httpClient;
        private const string URL = "https://util.devi.tools/api/v2/authorize";

        public AutorizadorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> AutorizeAsync()
        {
            string content = string.Empty;

            var response = await _httpClient.GetAsync(URL);

            if(!response.IsSuccessStatusCode) {return false;};

            response.EnsureSuccessStatusCode();

            content = await response.Content.ReadAsStringAsync();
            
            var result = JsonSerializer.Deserialize<ApiResponse>(content);

            return result?.status == "success";
        }
    }
}
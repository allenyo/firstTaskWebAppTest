using System.Net.Http.Json;

namespace api1Service
{
    public class RequestManager
    {

        private readonly IHttpClientFactory httpClientFactory;
        private  HttpResponseMessage _response;

        public RequestManager(HttpResponseMessage response, IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;

            _response = response;
        }


        public string Status { get; set; } = string.Empty;

        public object? Data { get; set; }

        public bool Success { get; set; }


       internal async Task Request(string url, HttpMethod method, object? data = null)
        {
            var _httpClient = httpClientFactory.CreateClient("yoclient");

            if (data == null && method == HttpMethod.Get)
            {
                _response = await _httpClient.GetAsync(url);
                Data = await _response.Content.ReadAsStringAsync();
            }
            else
            {
                if (data != null && method == HttpMethod.Post)
                {
                    _response = await _httpClient.PostAsJsonAsync(url, data);

                }
                else
                {
                    _response = await _httpClient.PutAsJsonAsync(url, data);

                }

                Status = _response.StatusCode.ToString();

                Success = _response.IsSuccessStatusCode;

            }
        }
    }
}

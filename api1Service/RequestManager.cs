using api1Domain.Models;
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
            try
            {
                var _httpClient = httpClientFactory.CreateClient("yoclient");

                if (data == null && method == HttpMethod.Get)
                {
                    _response = await _httpClient.GetAsync(url);

                }
                else
                {
                    if (data != null && method == HttpMethod.Post)
                    {
                        _response = await _httpClient.PostAsJsonAsync(url, data);

                    }
                    else
                    {
                        if (method == HttpMethod.Delete)
                        {
                            _response = await _httpClient.DeleteAsync(url);
                        }
                        else
                        {
                            _response = await _httpClient.PutAsJsonAsync(url, data);
                        }

                    }
                }

                Status = _response.StatusCode.ToString();

                Success = _response.IsSuccessStatusCode;

                Data = await _response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Data = new ErrorModel { Message = ex.Message, Error = "RequestError", Code = 64 };

            }
        }
    }
}

using api1Domain.Interfaces;
using api1Domain.Models;

namespace api1Service
{
    public class CarService : ICarService
    {
    
        private readonly RequestManager _requestManager;
        private readonly string baseurl = "https://localhost:7234/api/cars/";

        public CarService(RequestManager requestManager)
        {
            _requestManager = requestManager;

        }

        public async Task<bool> Add(Car car)
        {
            await _requestManager.Request($"{baseurl}add", HttpMethod.Post, car);
            return _requestManager.Success;
        }

        public async Task<bool> delete(Car car)
        {
            await _requestManager.Request($"{baseurl}delete", HttpMethod.Delete, car);
            return _requestManager.Success;
        }

        public async Task<object?> GetAll()
        {
           await _requestManager.Request($"{baseurl}getcars", HttpMethod.Get); 
            return _requestManager.Data;
        }

        public async Task<object?> GetById(int id)
        {
            await _requestManager.Request($"{baseurl}getbyid/{id}", HttpMethod.Get);
            return _requestManager.Data;
        }

        public async Task<object?> GetbyMake(string makeName)
        {
            await _requestManager.Request($"{baseurl}getbymake/{makeName}", HttpMethod.Get);
            return _requestManager.Data;
        }

        public async Task<object?> GetByModel(string name)
        {
            await _requestManager.Request($"{baseurl}getbymodel/{name}", HttpMethod.Get);
            return _requestManager.Data;
        }

    }
}

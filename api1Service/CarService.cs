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

        public async Task<bool> Delete(Car car)
        {
            await _requestManager.Request($"{baseurl}delete", HttpMethod.Post, car);
            return _requestManager.Success;
        }

        public async Task<object?> GetAll()
        {
           await _requestManager.Request($"{baseurl}getall", HttpMethod.Get); 
            return _requestManager.Data;
        }

        public async Task<object?> GetById(int id)
        {
            await _requestManager.Request($"{baseurl}getbyid/?id={id}", HttpMethod.Get);
            return _requestManager.Data;
        }

        public async Task<object?> GetbyMake(string makeName)
        {
            await _requestManager.Request($"{baseurl}getbymake/?make={makeName}", HttpMethod.Get);
            return _requestManager.Data;
        }

        public async Task<object?> GetByModel(string name)
        {
            await _requestManager.Request($"{baseurl}getbymodel/?model={name}", HttpMethod.Get);
            return _requestManager.Data;
        }

        public async Task<bool> Update(Car car)
        {
            await _requestManager.Request($"{baseurl}update", HttpMethod.Put, car);
            return _requestManager.Success;
        }
    }
}

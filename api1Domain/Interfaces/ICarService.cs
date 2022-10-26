using api1Domain.Models;

namespace api1Domain.Interfaces
{
    public interface ICarService
    {
        Task<object?> GetAll();
        Task<object?> GetById(int id);
        Task<object?> GetByModel(string name);
        Task<object?> GetbyMake(string makeName);
        Task<bool> Add(Car car);
        Task<bool> delete(Car car);

    }
}

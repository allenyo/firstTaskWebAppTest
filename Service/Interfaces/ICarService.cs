using Domain.Models;

namespace Service
{
    public interface ICarService
    {
        Task<IList<Car>> GetAll();
        Task<Car?> GetById(int id);
        Task<IList<Car>> GetByModel(string name);
        Task<IList<Car>> GetbyMake(string makeName);
        Task<bool> Add(Car car);
        Task<bool> Delete(Car car);
        Task<bool> Update(Car car);

    }
}

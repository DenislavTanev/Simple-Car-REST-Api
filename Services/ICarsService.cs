namespace PrintecExam.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using PrintecExam.Services.Models;

    public interface ICarsService
    {
        Task CreateAsync(CarCreateServiceModel input);

        Task EditAsync(CarEditServiceModel input);

        Task DeleteAsync(string id);

        CarServiceModel GetById(string id);

        IEnumerable<CarServiceModel> GetAllByMake(string make);

        IEnumerable<CarServiceModel> GetAll();
    }
}

namespace PrintecExam.Services
{
    using System.Collections.Generic;

    using PrintecExam.Services.Models;

    public interface IMakesService
    {
        IEnumerable<MakeServiceModel> GetAll();
    }
}

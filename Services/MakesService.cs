namespace PrintecExam.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using PrintecExam.Data;
    using PrintecExam.Services.Models;

    public class MakesService : IMakesService
    {
        private readonly ApplicationDbContext _context;

        public MakesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MakeServiceModel> GetAll()
        {
            var makes = this._context.Makes
                .Select(m => new MakeServiceModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    Models = m.Models.Select(im => new ModelServiceModel
                    {
                        Id = im.Id,
                        Name = im.Name,
                    })
                    .ToList(),
                })
                .ToList();

            return makes;
        }
    }
}

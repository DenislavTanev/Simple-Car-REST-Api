using System.Collections.Generic;

namespace PrintecExam.Services.Models
{
    public class MakeServiceModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<ModelServiceModel> Models { get; set; }
    }
}

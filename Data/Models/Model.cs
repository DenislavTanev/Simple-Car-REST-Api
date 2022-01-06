namespace PrintecExam.Data.Models
{
    using System;
    using System.Collections.Generic;

    using PrintecExam.Data.Common;

    public class Model : BaseModel
    {
        public Model()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Cars = new HashSet<Car>();
        }

        public string Name { get; set; }

        public ICollection<Car> Cars { get; set; }

        public string MakeId { get; set; }

        public Make Make { get; set; }
    }
}

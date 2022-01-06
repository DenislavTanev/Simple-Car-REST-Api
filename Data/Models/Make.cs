namespace PrintecExam.Data.Models
{
    using System;
    using System.Collections.Generic;

    using PrintecExam.Data.Common;

    public class Make : BaseModel
    {
        public Make()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Cars = new HashSet<Car>();
            this.Models = new HashSet<Model>();
        }

        public string Name { get; set; }

        public ICollection<Car> Cars { get; set; }

        public ICollection<Model> Models { get; set; }
    }
}

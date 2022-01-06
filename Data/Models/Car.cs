namespace PrintecExam.Data.Models
{
    using System;

    using PrintecExam.Data.Common;

    public class Car : BaseDeletableModel
    {
        public Car()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string OwnerName { get; set; }

        public string RegistrationPlate { get; set; }

        public int CubicCapacity { get; set; }

        public string Color { get; set; }

        public int HorsePower { get; set; }

        public string ModelId { get; set; }

        public Model Model { get; set; }

        public string MakeId { get; set; }

        public Make Make { get; set; }
    }
}

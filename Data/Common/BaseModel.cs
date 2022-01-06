namespace PrintecExam.Data.Common
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BaseModel : IAuditInfo
    {
        [Key]
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}

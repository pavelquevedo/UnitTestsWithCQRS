using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.DTO
{
    public class CourseDTO
    {
        public Guid CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? PublishDate { get; set; }
        //public DateTime? CreationDate { get; set; }
        public decimal Price { get; set; }
    }
}

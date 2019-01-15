using System;
using System.ComponentModel.DataAnnotations;

namespace MvcCore.Models
{
    public class UserViewModel
    {
        public Guid ID { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }
    }
}

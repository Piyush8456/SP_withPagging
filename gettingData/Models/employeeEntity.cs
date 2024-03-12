using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gettingData.Models
{

    public class employeeEntityModel
    {
        public List<employeeEntity> employees { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }

    public class employeeEntity
    {
        [Key]
        [DisplayName("employeeId")]
        public int employeeId { get; set; }

        [Required]
        [DisplayName("firstName")]
        public string firstName { get; set; }

        [Required]
        [DisplayName("lastName")]
        public string lastName { get; set; }

        [Required]
        [DisplayName("mobileNumber")]
        public string mobileNumber { get; set; }
    }
}
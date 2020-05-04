using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Milestone1.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }

        [Display(Name="Enter name:")]
        [StringLength(20)]
        [Required(ErrorMessage = "Length of a name should be at least 3 characters")]
        public string name { get; set; }

        [Display(Name = "Enter surname:")]
        [StringLength(20)]
        [Required(ErrorMessage = "Length of a surname should be at least 3 characters")]
        public string surname { get; set; }

        [Display(Name = "Enter address:")]
        [StringLength(30)]
        [Required(ErrorMessage = "Length of an address should be at least 3 characters")]
        public string address { get; set; }

        [Display(Name = "Enter telephone number:")] 
        [StringLength(10)]
        [Required(ErrorMessage ="Length of a telephone number should be at least 10 characters")]
        [DataType(DataType.PhoneNumber)]
        public string phone { get; set; }

        [Display(Name = "Enter email:")]
        [StringLength(30)]
        [Required(ErrorMessage = "Length of an email should be at least 3 characters")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }

        public List<OrderDetail> orderDetails { get; set; }

    }
}

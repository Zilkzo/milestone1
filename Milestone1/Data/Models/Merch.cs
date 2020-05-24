using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Milestone1.Data.Models
{
    public class Merch
    {
        public int id { set; get; }

        [Display(Name = "Name:")]
        [StringLength(20)]
        [Required(ErrorMessage = "Length of a name should be at least 3 characters")]
        public string name { set; get; }

        [Display(Name = "Description:")]
        [StringLength(50)]
        [Required(ErrorMessage = "Length of a description should be at least 5 characters")]
        public string desc { set; get; }

        [Display(Name = "URL to img:")]
        [StringLength(20)]
        [Required(ErrorMessage = "Length of an url should be at least 3 characters")]
        public string img { set; get; }

        [Display(Name = "Price:")]
        [Required(ErrorMessage = "Price is required")]
        public uint price { set; get; }

        public bool isFav { set; get; }

        public bool available { set; get; }

        [Display(Name = "Category ID:")]
        [Required(ErrorMessage = "Category ID is required")]
        public int categoryID { set; get; }

        public virtual Category Category { set; get; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Tragate.UI.Models.Company
{
    public class CompanyProductViewModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Product Title")]
        public string ProductTitle { get; set; }
        [DisplayName("Company Title")]
        public string CompanyTitle { get; set; }
        [DisplayName("List Image Path")]
        public string ListImagePath { get; set; }
        [DisplayName("Product Slug")]
        public string ProductSlug { get; set; }
        [DisplayName("Company Slug")]
        public string CompanySlug { get; set; }
        [DisplayName("Status Id")]
        public int StatusId { get; set; }
        [DisplayName("Status")]
        public string Status { get; set; }
        [DisplayName("Created User")]
        public string CreatedUser{ get; set; }

        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Tragate.UI.Models.Company
{
    public class CompanyTaskViewModel
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }

        public string Description { get; set; }

        public string CompanyTaskType { get; set; }

        public string CompanyTitle { get; set; }

        public string CompanySlug { get; set; }

        public string CreatedUser { get; set; }

        public string Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime EndDate { get; set; }

        public string ResponsibleUser { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Tragate.UI.Models.Company
{
    public class CompanyMembershipViewModel
    {
        [DisplayName("Üyelik Paketi")]
        public string MembershipPackage { get; set; }
        [DisplayName("Başlangıç Tarihi")]
        public DateTime StartDate { get; set; }
        [DisplayName("Bitiş Tarihi")]
        public DateTime EndDate { get; set; }
        [DisplayName("Ekleyen Kullanıcı")]
        public string CreatedUser { get; set; }
        [DisplayName("Oluşturma Tarihi")]
        public DateTime CreatedDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using Tragate.UI.Common.Enums;
using Tragate.UI.Models.Category;
using Tragate.UI.Models.User;

namespace Tragate.UI.Models.Company
{
    public class CompanyDetailViewModel
    {
        public int Id { get; set; }

        [DisplayName("İsim")]
        public string FullName { get; set; }

        [DisplayName("Durum")]
        public StatusType StatusType { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Telefon")]
        public string Phone { get; set; }

        [DisplayName("Oluşturulma Zamanı")]
        public DateTime CreatedDate { get; set; }

        [DisplayName("Açıklama")]
        public string Description { get; set; }

        [DisplayName("İşletme Tipi")]
        public string BusinessType { get; set; }

        [DisplayName("Kurulma Tarihi")]
        public string EstablishmentYear { get; set; }

        [DisplayName("Vergi Dairesi")]
        public string TaxOffice { get; set; }

        [DisplayName("Vergi Numarası")]
        public string TaxNumber { get; set; }

        [DisplayName("Adres")]
        public string Address { get; set; }

        [DisplayName("Web Sitesi")]
        public string Website { get; set; }
        public string Skype { get; set; }

        [DisplayName("Cevap Sıklığı")]
        public string ResponseRate { get; set; }

        [DisplayName("Cevap Süresi")]
        public string ResponseTime { get; set; }

        [DisplayName("İşlem Miktarı")]
        public int? TransactionAmount { get; set; }

        [DisplayName("İşlem Sayısı")]
        public int? TransactionCount { get; set; }
        public int EmployeeCountId { get; set; }
        public int AnnualRevenueId { get; set; }
        public int? MembershipTypeId { get; set; }
        public int? MembershipPackageId { get; set; }
        public int? VerificationTypeId { get; set; }

        [DisplayName("Durum")]
        public byte StatusId { get; set; }

        [DisplayName("Firma Durumu")]
        public string Status { get; set; }
        public int UserId { get; set; }
        public int PersonId { get; set; }

        [DisplayName("GÜncelleme Zamanı")]
        public DateTime UpdatedDate { get; set; }
        public UserViewModel User { get; set; }
        public CompanyDataViewModel CompanyData { get; set; }

        [DisplayName("İşletme Tipi")]
        public string BusinessTypes { get; set; }

        [DisplayName("Çalışan Sayısı")]
        public string EmployeeCount { get; set; }

        [DisplayName("Yıllık Gelir")]
        public string AnnualRevenue { get; set; }

        [DisplayName("Üyelik Tipi")]
        public string MembershipType { get; set; }

        [DisplayName("Üyelik Paketi")]
        public string MembershipPackage { get; set; }

        [DisplayName("Onay Tipi")]
        public string VerificationType { get; set; }

        public List<CategoryViewModel> CategoryList { get; set; }

        [DisplayName("Kategoriler")]
        public string Categories { get; set; }

        public string Slug { get; set; }

        public string WebSiteUrl { get; set; }

        public List<CompanyMembershipViewModel> MembershipList { get; set; }
    }
}
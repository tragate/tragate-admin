using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Tragate.UI.Common.Enums;
using Tragate.UI.Models.Dto;
using Tragate.UI.Models.Response;
using Tragate.UI.Models.User;

namespace Tragate.UI.Models.Company
{
    public class CompanyViewModel
    {
        public int Id { get; set; }

        [DisplayName("İsim")]
        public string FullName { get; set; }

        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz")]
        public string Email { get; set; }

        [DisplayName("Telefon")]
        public string Phone { get; set; }

        [DisplayName("Eklenme Zamanı")]
        public DateTime CreatedDate { get; set; }

        [DisplayName("Açıklama")]
        public string Description { get; set; }

        [DisplayName("İşletme Tipi")]
        public string BusinessType { get; set; }

        [DisplayName("Kuruluş Yılı")]
        public string EstablishmentYear { get; set; }

        [DisplayName("Vergi Dairesi")]
        public string TaxOffice { get; set; }

        [DisplayName("Vergi Numarası")]
        public string TaxNumber { get; set; }

        [DisplayName("Adres")]
        public string Address { get; set; }

        [DisplayName("Web sitesi")]
        public string Website { get; set; }
        public string Skype { get; set; }

        [DisplayName("Cevap verme Sıklığı")]
        public string ResponseRate { get; set; }

        [DisplayName("Cevap verme Zamanı")]
        public string ResponseTime { get; set; }

        [DisplayName("İşlem Miktarı")]
        public int? TransactionAmount { get; set; }

        [DisplayName("İşlem Sayısı")]
        public int? TransactionCount { get; set; }

        [DisplayName("Çalışan Sayısı")]
        public int EmployeeCountId { get; set; }

        [DisplayName("Yıllık Gelir")]
        public int AnnualRevenueId { get; set; }

        [DisplayName("Üyelik Tipi")]
        public int? MembershipTypeId { get; set; }

        [DisplayName("Üyelik Paketi")]
        public int? MembershipPackageId { get; set; }

        [DisplayName("Doğrulama tipi")]
        public int? VerificationTypeId { get; set; }

        [DisplayName("Firma Durumu")]
        public byte StatusId { get; set; }
        public int UserId { get; set; }

        public int PersonId { get; set; }

        [DisplayName("Güncelleme Zamanı")]
        public DateTime UpdatedDate { get; set; }
        public UserViewModel User { get; set; }
        public CompanyDataViewModel CompanyData { get; set; }
        public int? CompanyDataId { get; set; }

        [DisplayName("Profil Fotoğrafı")]
        public string ProfileImagePath { get; set; }
        public int LocationId { get; set; }

        [DisplayName("Ülke")]
        public int CountryId { get; set; }

        [DisplayName("Eyalet")]
        public int StateId { get; set; }

        [DisplayName("Şehir")]
        public int? CityId { get; set; }

        [DisplayName("Bölge")]
        public int? DistrictId { get; set; }

        [DisplayName("Kategoriler")]
        [Required]
        public int[] CategoryIds { get; set; }
        public string CategoryIdString { get; set; }

        [Required]
        public int[] BusinessTypeList { get; set; }

        [DisplayName("Web Site Puan")]
        public int? WebsitePoint { get; set; }

        [DisplayName("Web Site Ürün Sayısı")]
        public int? WebsiteProductCount { get; set; }
    }
}
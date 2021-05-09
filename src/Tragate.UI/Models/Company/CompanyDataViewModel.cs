using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Tragate.UI.Models.Response;

namespace Tragate.UI.Models.Company
{
    public class CompanyDataViewModel
    {
        public int Id { get; set; }

        [DisplayName("Başlık")]
        public string Title { get; set; }

        [DisplayName("Etiketler")]
        public string Tags { get; set; }

        [DisplayName("Eklenme Zamanı")]
        public string AddedDate { get; set; }

        [DisplayName("Ülke")]
        public string Country { get; set; }

        [DisplayName("Profil Fotoğrafı Linki")]
        public string ProfileImagePath { get; set; }
        

        [DisplayName("Şirket Profil Linki")]
        public string CompanyProfileLink { get; set; }

        [DisplayName("Üyelik")]
        public string Membership { get; set; }

        [DisplayName("Durum")]
        public byte StatusId { get; set; }

        [DisplayName("Profil Açıklaması")]
        public string ProfileDescription { get; set; }

        [DisplayName("İşletme Tipi")]
        public string BussinessSegment { get; set; }

        [DisplayName("Vergi Numarası")]
        public string TaxNumber { get; set; }

        [DisplayName("Kategori")]
        public string Category { get; set; }

        [DisplayName("Sertifika")]
        public string Certificate { get; set; }

        [DisplayName("Kuruluş Tarihi ve Çalışan Sayısı")]
        public string EstablishedDateAndNumberOfStaff { get; set; }

        [DisplayName("Şirket ve Marka")]
        public string ReleatedCompanyAndBrand { get; set; }

        [DisplayName("İlgili Kişi")]
        public string ContactPerson { get; set; }

        [DisplayName("Adres")]
        public string Address { get; set; }

        [DisplayName("Şehir")]
        public string City { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Telefon")]
        public string Phone { get; set; }

        [DisplayName("Websitesi")]
        public string Website { get; set; }

        [DisplayName("Yıllık Gelir")]
        public string TotalRevenue { get; set; }
    }
}
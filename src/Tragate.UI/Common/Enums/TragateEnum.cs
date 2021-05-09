using System.ComponentModel.DataAnnotations;

namespace Tragate.UI.Common.Enums
{
    public enum StatusType : byte
    {
        [Display(Name = "Aktif")] All = 0,

        [Display(Name = "Yeni")] New = 1,

        [Display(Name = "Onay bekliyor")] WaitingApprove = 2,

        [Display(Name = "Aktif")] Active = 3,

        [Display(Name = "Silindi")] Deleted = 4,

        [Display(Name = "Pasif")] Passive = 5,

        [Display(Name = "Transfer edildi")] Transferred = 6,

        [Display(Name = "Tamamlandý")] Completed = 7
    }

    public enum UserType : byte
    {
        Person = 1,
        Company = 2
    }

    public enum RegisterType : byte
    {
        Tragate = 1,
        Facebook = 2,
        Google = 3,
        Linkedin = 4
    }

    public enum PlatformType
    {
        Web = 1,
        Admin = 2
    }
}
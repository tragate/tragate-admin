using System;
using Newtonsoft.Json;

public class CompanyAdminInsertDto
{
    [JsonProperty("email")]
    public string Email { get; set; }

    [JsonProperty("companyId")]
    public int CompanyId { get; set; }

    [JsonProperty("companyAdminRoleId")]
    public int CompanyAdminRoleId { get; set; }

    [JsonProperty("statusId")]
    public int StatusId { get; set; }
}

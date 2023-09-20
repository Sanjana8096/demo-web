using System;
using System.Collections.Generic;

namespace WebReports.Models;

public partial class Client
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? DisplayName { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string LastUpdatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public DateTime LastUpdatedOn { get; set; }

    public virtual ICollection<ClientMenu> ClientMenus { get; set; } = new List<ClientMenu>();

    public virtual ICollection<ClientUser> ClientUsers { get; set; } = new List<ClientUser>();

    public virtual AspNetUser CreatedByNavigation { get; set; } = null!;

    public virtual AspNetUser LastUpdatedByNavigation { get; set; } = null!;
}

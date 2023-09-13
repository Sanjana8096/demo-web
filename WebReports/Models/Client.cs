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

    public virtual ICollection<ClientMenu> ClientMenus { get; set; } = new List<ClientMenu>();

    public virtual ICollection<ClientUser> ClientUsers { get; set; } = new List<ClientUser>();
}

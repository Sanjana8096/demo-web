using System;
using System.Collections.Generic;

namespace WebReports.Models;

public partial class ClientMenu
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public string MenuUrl { get; set; } = null!;

    public int? MenuOrder { get; set; }

    public bool? IsActive { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string LastUpdatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public DateTime LastUpdateOn { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual AspNetUser CreatedByNavigation { get; set; } = null!;

    public virtual AspNetUser LastUpdatedByNavigation { get; set; } = null!;
}

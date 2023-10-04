using System;
using System.Collections.Generic;

namespace WebReports.Models;

public partial class ClientUser
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public int ClientId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string LastUpdatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public DateTime LastUpdatedOn { get; set; }

    public bool? IsAcive { get; set; }

    public DateTime? DisabledOn { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual AspNetUser CreatedByNavigation { get; set; } = null!;

    public virtual AspNetUser LastUpdatedByNavigation { get; set; } = null!;

    public virtual AspNetUser User { get; set; } = null!;
}

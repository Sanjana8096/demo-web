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

    public virtual Client Client { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace WebReports.Models;

public partial class ClientUser
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public int ClientId { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual AspNetUser User { get; set; } = null!;
}

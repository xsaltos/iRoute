using System;
using System.Collections.Generic;

namespace iRoute.Entities;

public partial class CommerceQuarantine
{
    public int QuaIdReg { get; set; }

    public int? QuaNumDoc { get; set; }

    public string? QuaErrorDescription { get; set; }

    public DateTime? QuaProcessDate { get; set; }
}

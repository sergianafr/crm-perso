﻿using System;
using System.Collections.Generic;

namespace crm_perso.Models;

public partial class LeadAction
{
    public uint Id { get; set; }

    public uint LeadId { get; set; }

    public string? Action { get; set; }

    public DateTime? DateTime { get; set; }

    public virtual TriggerLead Lead { get; set; } = null!;
}

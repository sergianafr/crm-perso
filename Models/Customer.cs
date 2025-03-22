﻿using System;
using System.Collections.Generic;

namespace crm_perso.Models;

public partial class Customer
{
    public uint CustomerId { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public int? UserId { get; set; }

    public string? Description { get; set; }

    public string? Position { get; set; }

    public string? Twitter { get; set; }

    public string? Facebook { get; set; }

    public string? Youtube { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Email { get; set; }

    public int? ProfileId { get; set; }

    public virtual CustomerLoginInfo? Profile { get; set; }

    public virtual ICollection<TriggerContract> TriggerContracts { get; set; } = new List<TriggerContract>();

    public virtual ICollection<TriggerLead> TriggerLeads { get; set; } = new List<TriggerLead>();

    public virtual ICollection<TriggerTicket> TriggerTickets { get; set; } = new List<TriggerTicket>();

    public virtual User? User { get; set; }
}

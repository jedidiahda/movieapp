using System;
using System.Collections.Generic;

namespace MovieWebApp.Models;

public partial class Account
{
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool Active { get; set; }

    public string Role { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}

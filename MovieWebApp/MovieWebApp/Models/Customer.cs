using System;
using System.Collections.Generic;

namespace MovieWebApp.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Address { get; set; }

    public string Gender { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<CustomerBankAccount> CustomerBankAccounts { get; set; } = new List<CustomerBankAccount>();

    public virtual ICollection<CustomerSubscription> CustomerSubscriptions { get; set; } = new List<CustomerSubscription>();

    public virtual Account EmailNavigation { get; set; } = null!;

    public virtual ICollection<RequestedDvd> RequestedDvds { get; set; } = new List<RequestedDvd>();
}

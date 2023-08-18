using System;
using System.Collections.Generic;

namespace MovieWebApp.Models;

public partial class CustomerBankAccount
{
    public string AccountNo { get; set; } = null!;

    public long BankRoute { get; set; }

    public string AccountName { get; set; } = null!;

    public string BankName { get; set; } = null!;

    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}

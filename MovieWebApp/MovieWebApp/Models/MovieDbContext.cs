using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MovieWebApp.Models;

public partial class MovieDbContext : DbContext
{
    public MovieDbContext()
    {
    }

    public MovieDbContext(DbContextOptions<MovieDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerBankAccount> CustomerBankAccounts { get; set; }

    public virtual DbSet<CustomerDeliveryDto> CustomerDeliveryDtos { get; set; }

    public virtual DbSet<CustomerSubscription> CustomerSubscriptions { get; set; }

    public virtual DbSet<Dvdcatalog> Dvdcatalogs { get; set; }

    public virtual DbSet<Dvdcopy> Dvdcopies { get; set; }

    public virtual DbSet<Dvdstatus> Dvdstatuses { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentType> PaymentTypes { get; set; }

    public virtual DbSet<RequestedDvd> RequestedDvds { get; set; }

    public virtual DbSet<Subscription> Subscriptions { get; set; }

    public virtual DbSet<Watchlist> Watchlists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:MovieDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Email);

            entity.ToTable("Account");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("role");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("firstName");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("gender");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("lastName");

            entity.HasOne(d => d.EmailNavigation).WithMany(p => p.Customers)
                .HasForeignKey(d => d.Email)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_Account");
        });

        modelBuilder.Entity<CustomerBankAccount>(entity =>
        {
            entity.HasKey(e => e.AccountNo);

            entity.ToTable("CustomerBankAccount");

            entity.Property(e => e.AccountNo)
                .HasMaxLength(100)
                .HasColumnName("accountNo");
            entity.Property(e => e.AccountName)
                .HasMaxLength(100)
                .HasColumnName("accountName");
            entity.Property(e => e.BankName)
                .HasMaxLength(200)
                .HasColumnName("bankName");
            entity.Property(e => e.BankRoute).HasColumnName("bankRoute");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerBankAccounts)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerBankAccount_Customer");
        });

        modelBuilder.Entity<CustomerDeliveryDto>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CustomerDeliveryDTO");

            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .HasColumnName("code");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.CustomerSubscriptionId).HasColumnName("customerSubscriptionId");
            entity.Property(e => e.DvdcatalogId).HasColumnName("DVDCatalogId");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("firstName");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("gender");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("lastName");
            entity.Property(e => e.Rank).HasColumnName("rank");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
        });

        modelBuilder.Entity<CustomerSubscription>(entity =>
        {
            entity.ToTable("CustomerSubscription");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("endDate");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("startDate");
            entity.Property(e => e.SubscriptId).HasColumnName("subscriptId");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerSubscriptions)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerSubscription_Customer");

            entity.HasOne(d => d.Subscript).WithMany(p => p.CustomerSubscriptions)
                .HasForeignKey(d => d.SubscriptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerSubscription_Subscription");
        });

        modelBuilder.Entity<Dvdcatalog>(entity =>
        {
            entity.ToTable("DVDCatalog");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasColumnName("description");
            entity.Property(e => e.Genre)
                .HasMaxLength(200)
                .HasColumnName("genre");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Language)
                .HasMaxLength(50)
                .HasColumnName("language");
            entity.Property(e => e.NoDisk).HasColumnName("noDisk");
            entity.Property(e => e.ReleasedDate)
                .HasColumnType("date")
                .HasColumnName("releasedDate");
            entity.Property(e => e.StockQty).HasColumnName("stockQty");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Dvdcopy>(entity =>
        {
            entity.ToTable("DVDCopy");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .HasColumnName("code");
            entity.Property(e => e.DvdcatalogId).HasColumnName("DVDCatalogId");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("status");

            entity.HasOne(d => d.Dvdcatalog).WithMany(p => p.Dvdcopies)
                .HasForeignKey(d => d.DvdcatalogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DVDCopy_DVDCatalog");
        });

        modelBuilder.Entity<Dvdstatus>(entity =>
        {
            entity.ToTable("DVDStatus");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CustomerSubscriptionId).HasColumnName("customerSubscriptionId");
            entity.Property(e => e.DeliveredDate)
                .HasColumnType("date")
                .HasColumnName("deliveredDate");
            entity.Property(e => e.DvdcatalogId).HasColumnName("DVDCatalogId");
            entity.Property(e => e.Dvdcode)
                .HasMaxLength(100)
                .HasColumnName("DVDCode");
            entity.Property(e => e.ReturnedDate)
                .HasColumnType("date")
                .HasColumnName("returnedDate");

            entity.HasOne(d => d.CustomerSubscription).WithMany(p => p.Dvdstatuses)
                .HasForeignKey(d => d.CustomerSubscriptionId)
                .HasConstraintName("FK_DVDStatus_CustomerSubscription");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.ToTable("Payment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("money")
                .HasColumnName("amount");
            entity.Property(e => e.BillingAddress)
                .HasMaxLength(200)
                .HasColumnName("billingAddress");
            entity.Property(e => e.CustomerSubscriptionId).HasColumnName("customerSubscriptionId");
            entity.Property(e => e.PaymentDate)
                .HasColumnType("date")
                .HasColumnName("paymentDate");
            entity.Property(e => e.PaymentType).HasColumnName("paymentType");

            entity.HasOne(d => d.CustomerSubscription).WithMany(p => p.Payments)
                .HasForeignKey(d => d.CustomerSubscriptionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_CustomerSubscription");

            entity.HasOne(d => d.PaymentTypeNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.PaymentType)
                .HasConstraintName("FK_Payment_PaymentType");
        });

        modelBuilder.Entity<PaymentType>(entity =>
        {
            entity.ToTable("PaymentType");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
        });

        modelBuilder.Entity<RequestedDvd>(entity =>
        {
            entity.ToTable("RequestedDVD");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.SubmissionDate)
                .HasColumnType("date")
                .HasColumnName("submissionDate");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");

            entity.HasOne(d => d.Customer).WithMany(p => p.RequestedDvds)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RequestedDVD_Customer");
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.ToTable("Subscription");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AtHomeDvd).HasColumnName("atHomeDVD");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.NoDvdperMonth).HasColumnName("noDVDPerMonth");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
        });

        modelBuilder.Entity<Watchlist>(entity =>
        {
            entity.HasKey(e => new { e.DvdcatalogId, e.CustomerId }).HasName("PK_Watchlist_1");

            entity.ToTable("Watchlist");

            entity.Property(e => e.DvdcatalogId).HasColumnName("DVDCatalogId");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.Rank).HasColumnName("rank");

            entity.HasOne(d => d.Dvdcatalog).WithMany(p => p.Watchlists)
                .HasForeignKey(d => d.DvdcatalogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Watchlist_DVDCatalog");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

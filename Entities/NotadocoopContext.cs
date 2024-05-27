using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace PrelimCoop.Entities;

public partial class NotadocoopContext : DbContext
{
    public NotadocoopContext()
    {
    }

    public NotadocoopContext(DbContextOptions<NotadocoopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ClientsInfoTb> ClientsInfoTbs { get; set; }

    public virtual DbSet<LoanDb> LoanDbs { get; set; }

    public virtual DbSet<PaymentsTb> PaymentsTbs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=notadocoop;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.28-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<ClientsInfoTb>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("clients_info_tb");

            entity.Property(e => e.Id)
                .HasColumnType("int(50)")
                .HasColumnName("ID");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Age).HasColumnType("int(50)");
            entity.Property(e => e.Birthday).HasMaxLength(100);
            entity.Property(e => e.CivilStatus)
                .HasMaxLength(100)
                .HasColumnName("Civil_Status");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .HasColumnName("Full_Name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("Last_Name");
            entity.Property(e => e.NameOfFather).HasMaxLength(255);
            entity.Property(e => e.NameOfMother).HasMaxLength(255);
            entity.Property(e => e.Occupation).HasMaxLength(100);
            entity.Property(e => e.Religion).HasMaxLength(100);
            entity.Property(e => e.UserType)
                .HasMaxLength(100)
                .HasColumnName("User_Type");
            entity.Property(e => e.ZipCode)
                .HasColumnType("int(100)")
                .HasColumnName("ZIP_Code");
        });

        modelBuilder.Entity<LoanDb>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("loan_db");

            entity.Property(e => e.Id).HasColumnType("int(50)");
            entity.Property(e => e.Amount).HasColumnType("int(50)");
            entity.Property(e => e.ClientId).HasColumnType("int(10)");
            entity.Property(e => e.DateCreated).HasColumnName("Date_Created");
            entity.Property(e => e.Deduction).HasPrecision(10);
            entity.Property(e => e.DueDate).HasColumnName("Due_Date");
            entity.Property(e => e.Interest).HasPrecision(10);
            entity.Property(e => e.NoOfPayment)
                .HasColumnType("int(10)")
                .HasColumnName("No_Of_Payment");
            entity.Property(e => e.PayableAmount)
                .HasPrecision(10)
                .HasColumnName("Payable_amount");
            entity.Property(e => e.RecievableAmount)
                .HasPrecision(10)
                .HasColumnName("Recievable_Amount");
            entity.Property(e => e.Status).HasMaxLength(200);
            entity.Property(e => e.Term).HasColumnType("int(10)");
            entity.Property(e => e.Type).HasMaxLength(200);
        });

        modelBuilder.Entity<PaymentsTb>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("payments_tb");

            entity.Property(e => e.Id)
                .HasColumnType("int(50)")
                .HasColumnName("id");
            entity.Property(e => e.ClientId)
                .HasColumnType("int(50)")
                .HasColumnName("client_id");
            entity.Property(e => e.Collectable)
                .HasPrecision(10)
                .HasColumnName("collectable");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Deduction)
                .HasPrecision(10)
                .HasColumnName("deduction");
            entity.Property(e => e.LoanId)
                .HasColumnType("int(50)")
                .HasColumnName("loan_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

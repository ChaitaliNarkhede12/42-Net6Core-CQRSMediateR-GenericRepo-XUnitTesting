using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TCCS.DataAccess.Models;

public partial class TccsContext : DbContext
{
    public TccsContext()
    {
    }

    public TccsContext(DbContextOptions<TccsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Temp> Temps { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{

    //}
        //=> optionsBuilder.UseSqlServer("Data Source=DESKTOP-PN1JAFF;Initial Catalog=TCCS;TrustServerCertificate=True;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC0794F5A633");

            entity.ToTable("Employee");

            entity.Property(e => e.EmailId)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Temp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Temp__3214EC07A0BECF48");

            entity.ToTable("Temp");

            entity.Property(e => e.EmailId)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

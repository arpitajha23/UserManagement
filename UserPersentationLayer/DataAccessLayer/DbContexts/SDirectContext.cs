using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UserPersentationLayer.Models;

namespace DataAccessLayer.DbContexts;

public partial class SDirectContext : DbContext
{
    public SDirectContext()
    {
    }

    public SDirectContext(DbContextOptions<SDirectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ArAddress> ArAddresses { get; set; }

    public virtual DbSet<ArPhoneNumber> ArPhoneNumbers { get; set; }

    public virtual DbSet<ArUsers> ArUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ArAddress>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__ArAddres__091C2AFB650C04BE");

            entity.Property(e => e.AddressType).HasMaxLength(10);
            entity.Property(e => e.Addresss).HasMaxLength(256);
            entity.Property(e => e.City).HasMaxLength(60);
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.States).HasMaxLength(60);
            entity.Property(e => e.ZipCode).HasMaxLength(20);

            entity.HasOne(d => d.User).WithMany(p => p.ArAddresses)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__ArAddress__UserI__6A70BD6B");
        });

        modelBuilder.Entity<ArPhoneNumber>(entity =>
        {
            entity.HasKey(e => e.PhoneNumberId).HasName("PK__ArPhoneN__D2D34F914D59852E");

            entity.Property(e => e.PhoneNumber).HasMaxLength(12);
            entity.Property(e => e.PhoneType).HasMaxLength(10);

            entity.HasOne(d => d.User).WithMany(p => p.ArPhoneNumbers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__ArPhoneNu__UserI__6F357288");
        });

        modelBuilder.Entity<ArUsers>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__ArUsers__1788CC4CE7F1B0E4");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Email).HasMaxLength(40);
            entity.Property(e => e.FirstName).HasMaxLength(30);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.ImageUrl).HasMaxLength(1);
            entity.Property(e => e.IsActive).HasDefaultValue(false);
            entity.Property(e => e.LastName).HasMaxLength(30);
            entity.Property(e => e.MiddleName).HasMaxLength(30);
            entity.Property(e => e.Passwords).HasMaxLength(256);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

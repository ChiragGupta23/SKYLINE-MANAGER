using System;
using System.Collections.Generic;
using ARH.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;


namespace reg_login.Models;

public partial class UserauthdbContext : DbContext
{
	public UserauthdbContext()
	{
	}

	public UserauthdbContext(DbContextOptions<UserauthdbContext> options)
		: base(options)
	{
	}

	public virtual DbSet<User> Users { get; set; }
	public DbSet<ARH.Models.LoginRequest> loginRequests { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		if (!optionsBuilder.IsConfigured)
		{

		}
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<User>(entity =>
		{
			entity.HasKey(e => e.Id)
			.HasName("PK__users__3214EC07E35806F4");

			entity.ToTable("users");

			entity.Property(e => e.Email).HasMaxLength(100);
			entity.Property(e => e.MobileNumber).HasMaxLength(15);
			entity.Property(e => e.Name).HasMaxLength(100);
		});

		modelBuilder.Entity<ARH.Models.LoginRequest>(entity =>
		{
			entity.HasNoKey();
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

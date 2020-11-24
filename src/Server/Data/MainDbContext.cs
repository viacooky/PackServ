using System;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NuGet.Versioning;
using Server.Models;
using Version = Server.Models.Version;

namespace Server.Data
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }

        public DbSet<Application> Applications { get; set; }
        // public DbSet<Version> Versions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new ApplicationEntityTypeConfiguration().Configure(modelBuilder.Entity<Application>());
            new VersionEntityTypeConfiguration().Configure(modelBuilder.Entity<Version>());
        }
    }

    public class VersionEntityTypeConfiguration : IEntityTypeConfiguration<Version>
    {
        public void Configure(EntityTypeBuilder<Version> builder)
        {
            builder.ToTable("t_version").HasKey(ver => ver.Id);
            builder.Property(ver => ver.Id).HasColumnName("FId").IsRequired();
            builder.Property(ver => ver.CreateTime).HasColumnName("FCreateTime");
            builder.Property(ver => ver.Url).HasColumnName("FUrl");
            builder.Property(ver => ver.Value).HasColumnName("FValue");
            builder.Property(ver => ver.ApplicationId).HasColumnName("FApplicationId");
            builder.Ignore(ver => ver.NuGetVersion);
        }
    }

    public class ApplicationEntityTypeConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.ToTable("t_application").HasKey(app => app.Id);
            builder.Property(app => app.Id).HasColumnName("FId").IsRequired();
            builder.Property(app => app.Name).HasColumnName("FName");
            builder.Property(app => app.CreateTime).HasColumnName("FCreateTime");
            builder.Property(app => app.Description).HasColumnName("FDescription");
            builder.HasMany(app => app.Versions)
                   .WithOne()
                   .HasForeignKey(ver => ver.ApplicationId);
        }
    }
}
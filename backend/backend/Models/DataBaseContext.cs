using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

public partial class DataBaseContext : DbContext
{
    public DataBaseContext()
    {
    }

    public DataBaseContext(DbContextOptions<DataBaseContext> options)
        : base(options)
    {
    }


    public virtual DbSet<Favorite> Favorites { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=.\\Database\\DataBase.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasKey(e => new { e.Email, e.IdPlayer });

            entity.ToTable("Favorite");

            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.IdPlayer).HasColumnName("idPlayer");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.ToTable("Player");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FirstName).HasColumnName("first_name");
            entity.Property(e => e.HeightFeet).HasColumnName("height_feet");
            entity.Property(e => e.HeightInches).HasColumnName("height_inches");
            entity.Property(e => e.LastName).HasColumnName("last_name");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.TeamId).HasColumnName("teamId");
            entity.Property(e => e.WeightPounds).HasColumnName("weight_pounds");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

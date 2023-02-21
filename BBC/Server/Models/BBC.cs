﻿using System;
using System.Collections.Generic;
using BBC.Shared.BBC.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BBC.Shared.Models;

public partial class BBC : DbContext
{
    public BBC()
    {
    }

    public BBC(DbContextOptions<BBC> options)
        : base(options)
    {
    }

    public virtual DbSet<DisplaySetting> DisplaySettings { get; set; }

    public virtual DbSet<IngredientId> IngredientIds { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Progress> Progresses { get; set; }

    public virtual DbSet<Pump> Pumps { get; set; }

    public virtual DbSet<Ratio> Ratios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=C:\\Users\\bpoch\\source\\repos\\BBC\\BBC\\Server\\db\\db.sqlite3;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DisplaySetting>(entity =>
        {
            entity.ToTable("Display_Settings");

            entity.HasIndex(e => e.Color, "IX_Display_Settings_color").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Color)
                .HasColumnType("varchar(50)")
                .HasColumnName("color");
            entity.Property(e => e.DrinksPerRow).HasColumnName("drinks_per_row");
        });

        modelBuilder.Entity<IngredientId>(entity =>
        {
            entity.HasKey(e => e.Ingredient);

            entity.ToTable("ingredient_id");

            entity.Property(e => e.Ingredient)
                .HasColumnType("varchar(50)")
                .HasColumnName("ingredient");
            entity.Property(e => e.Dtype)
                .HasColumnType("varchar(2)")
                .HasColumnName("dtype");
            entity.Property(e => e.PumpPicture)
                .HasColumnType("varchar(100)")
                .HasColumnName("pump_picture");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.ToTable("menu");

            entity.HasIndex(e => e.Name, "IX_menu_name").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatorId)
                .HasColumnType("varchar(20)")
                .HasColumnName("creator_id");
            entity.Property(e => e.Name)
                .HasColumnType("varchar(50)")
                .HasColumnName("name");
            entity.Property(e => e.Picture)
                .HasColumnType("varchar(100)")
                .HasColumnName("picture");
            entity.Property(e => e.TypeId)
                .HasColumnType("varchar(2)")
                .HasColumnName("type_id");
        });

        modelBuilder.Entity<Progress>(entity =>
        {
            entity.ToTable("progress");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.InProgress)
                .HasColumnType("varchar(1)")
                .HasColumnName("in_progress");
        });

        modelBuilder.Entity<Pump>(entity =>
        {
            entity.HasKey(e => e.Pump1);

            entity.ToTable("pumps");

            entity.Property(e => e.Pump1)
                .ValueGeneratedNever()
                .HasColumnName("pump");
            entity.Property(e => e.IngredientId)
                .HasColumnType("varchar(100)")
                .HasColumnName("ingredient_id");
            entity.Property(e => e.VolumeLeft).HasColumnName("volume_left");
        });

        modelBuilder.Entity<Ratio>(entity =>
        {
            entity.ToTable("ratio");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("varchar(4)")
                .HasColumnName("amount");
            entity.Property(e => e.Ingredient)
                .HasColumnType("varchar(50)")
                .HasColumnName("ingredient");
            entity.Property(e => e.MenuId).HasColumnName("menu_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
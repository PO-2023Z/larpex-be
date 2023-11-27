﻿using System;
using System.Collections.Generic;
using larpex_events.Persistance.DTOs;
using Microsoft.EntityFrameworkCore;

namespace larpex_events.Persistance;

public partial class LarpexdbContext : DbContext
{
    public LarpexdbContext()
    {
    }

    public LarpexdbContext(DbContextOptions<LarpexdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Equipment> Equipments { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<Gamerole> Gameroles { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Place> Places { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userscredential> Userscredentials { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.Equipmentid).HasName("equipments_pkey");

            entity.ToTable("equipments");

            entity.Property(e => e.Equipmentid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("equipmentid");
            entity.Property(e => e.Itemid).HasColumnName("itemid");
            entity.Property(e => e.Itemstate)
                .HasMaxLength(50)
                .HasColumnName("itemstate");
            entity.Property(e => e.Playerid).HasColumnName("playerid");

            entity.HasOne(d => d.Item).WithMany(p => p.Equipment)
                .HasForeignKey(d => d.Itemid)
                .HasConstraintName("equipments_itemid_fkey");

            entity.HasOne(d => d.Player).WithMany(p => p.Equipment)
                .HasForeignKey(d => d.Playerid)
                .HasConstraintName("equipments_playerid_fkey");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Eventid).HasName("events_pkey");

            entity.ToTable("events");

            entity.Property(e => e.Eventid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("eventid");
            entity.Property(e => e.Descriptionforclients)
                .HasMaxLength(1000)
                .HasColumnName("descriptionforclients");
            entity.Property(e => e.Descriptionforemployees)
                .HasMaxLength(1000)
                .HasColumnName("descriptionforemployees");
            entity.Property(e => e.Enddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("enddate");
            entity.Property(e => e.Eventname)
                .HasMaxLength(50)
                .HasColumnName("eventname");
            entity.Property(e => e.Eventprice)
                .HasColumnType("money")
                .HasColumnName("eventprice");
            entity.Property(e => e.Eventstate)
                .HasMaxLength(50)
                .HasColumnName("eventstate");
            entity.Property(e => e.Gameid).HasColumnName("gameid");
            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .HasColumnName("icon");
            entity.Property(e => e.Isexternalorganiser).HasColumnName("isexternalorganiser");
            entity.Property(e => e.Isvisible).HasColumnName("isvisible");
            entity.Property(e => e.Maxplayerlimit).HasColumnName("maxplayerlimit");
            entity.Property(e => e.Owneremail)
                .HasMaxLength(50)
                .HasColumnName("owneremail");
            entity.Property(e => e.Paidfor).HasColumnName("paidfor");
            entity.Property(e => e.Placeid).HasColumnName("placeid");
            entity.Property(e => e.Priceperuser)
                .HasColumnType("money")
                .HasColumnName("priceperuser");
            entity.Property(e => e.Startdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("startdate");
            entity.Property(e => e.Technicaldescription)
                .HasMaxLength(1000)
                .HasColumnName("technicaldescription");

            entity.HasOne(d => d.Game).WithMany(p => p.Events)
                .HasForeignKey(d => d.Gameid)
                .HasConstraintName("events_gameid_fkey");

            entity.HasOne(d => d.Place).WithMany(p => p.Events)
                .HasForeignKey(d => d.Placeid)
                .HasConstraintName("events_placeid_fkey");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.Gameid).HasName("games_pkey");

            entity.ToTable("games");

            entity.Property(e => e.Gameid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("gameid");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasColumnName("description");
            entity.Property(e => e.Difficulty).HasColumnName("difficulty");
            entity.Property(e => e.Gamename)
                .HasMaxLength(50)
                .HasColumnName("gamename");
            entity.Property(e => e.Map)
                .HasMaxLength(1000)
                .HasColumnName("map");
            entity.Property(e => e.Maximumplayer).HasColumnName("maximumplayer");
            entity.Property(e => e.Scenario)
                .HasMaxLength(1000)
                .HasColumnName("scenario");
        });

        modelBuilder.Entity<Gamerole>(entity =>
        {
            entity.HasKey(e => e.Gameroleid).HasName("gameroles_pkey");

            entity.ToTable("gameroles");

            entity.Property(e => e.Gameroleid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("gameroleid");
            entity.Property(e => e.Gameid).HasColumnName("gameid");
            entity.Property(e => e.Roledescription)
                .HasMaxLength(1000)
                .HasColumnName("roledescription");
            entity.Property(e => e.Rolename)
                .HasMaxLength(50)
                .HasColumnName("rolename");

            entity.HasOne(d => d.Game).WithMany(p => p.Gameroles)
                .HasForeignKey(d => d.Gameid)
                .HasConstraintName("gameroles_gameid_fkey");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Itemid).HasName("items_pkey");

            entity.ToTable("items");

            entity.Property(e => e.Itemid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("itemid");
            entity.Property(e => e.Gameid).HasColumnName("gameid");
            entity.Property(e => e.Itemdescription)
                .HasMaxLength(250)
                .HasColumnName("itemdescription");
            entity.Property(e => e.Itemicon)
                .HasMaxLength(150)
                .HasColumnName("itemicon");
            entity.Property(e => e.Itemname)
                .HasMaxLength(50)
                .HasColumnName("itemname");
            entity.Property(e => e.Rarity)
                .HasMaxLength(50)
                .HasColumnName("rarity");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");

            entity.HasOne(d => d.Game).WithMany(p => p.Items)
                .HasForeignKey(d => d.Gameid)
                .HasConstraintName("items_gameid_fkey");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Paymentid).HasName("payments_pkey");

            entity.ToTable("payments");

            entity.Property(e => e.Paymentid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("paymentid");
            entity.Property(e => e.Eventid).HasColumnName("eventid");
            entity.Property(e => e.Paymentamount)
                .HasColumnType("money")
                .HasColumnName("paymentamount");
            entity.Property(e => e.Paymentdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("paymentdate");
            entity.Property(e => e.Paymentstate)
                .HasMaxLength(50)
                .HasColumnName("paymentstate");
            entity.Property(e => e.Paymenttype)
                .HasMaxLength(50)
                .HasColumnName("paymenttype");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(50)
                .HasColumnName("userEmail");

            entity.HasOne(d => d.Event).WithMany(p => p.Payments)
                .HasForeignKey(d => d.Eventid)
                .HasConstraintName("payments_eventid_fkey");

            entity.HasOne(d => d.UserEmailNavigation).WithMany(p => p.Payments)
                .HasPrincipalKey(p => p.Email)
                .HasForeignKey(d => d.UserEmail)
                .HasConstraintName("payments_users_email_fk");
        });

        modelBuilder.Entity<Place>(entity =>
        {
            entity.HasKey(e => e.Placeid).HasName("places_pkey");

            entity.ToTable("places");

            entity.Property(e => e.Placeid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("placeid");
            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .HasColumnName("address");
            entity.Property(e => e.Details)
                .HasMaxLength(1000)
                .HasColumnName("details");
            entity.Property(e => e.Priceperhour)
                .HasColumnType("money")
                .HasColumnName("priceperhour");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.Playerid).HasName("players_pkey");

            entity.ToTable("players");

            entity.Property(e => e.Playerid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("playerid");
            entity.Property(e => e.Coordinates).HasColumnName("coordinates");
            entity.Property(e => e.Eventid).HasColumnName("eventid");
            entity.Property(e => e.Gameroleid).HasColumnName("gameroleid");
            entity.Property(e => e.Nick)
                .HasMaxLength(50)
                .HasColumnName("nick");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Event).WithMany(p => p.Players)
                .HasForeignKey(d => d.Eventid)
                .HasConstraintName("players_eventid_fkey");

            entity.HasOne(d => d.Gamerole).WithMany(p => p.Players)
                .HasForeignKey(d => d.Gameroleid)
                .HasConstraintName("players_gameroleid_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Players)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("players_userid_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "users_pk").IsUnique();

            entity.Property(e => e.Userid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("userid");
            entity.Property(e => e.Avatar)
                .HasMaxLength(150)
                .HasColumnName("avatar");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Userscredential>(entity =>
        {
            entity.HasKey(e => e.Usercredentialid).HasName("userscredential_pkey");

            entity.ToTable("userscredential");

            entity.Property(e => e.Usercredentialid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("usercredentialid");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(50)
                .HasColumnName("userEmail");

            entity.HasOne(d => d.UserEmailNavigation).WithMany(p => p.Userscredentials)
                .HasPrincipalKey(p => p.Email)
                .HasForeignKey(d => d.UserEmail)
                .HasConstraintName("userscredential_users_email_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

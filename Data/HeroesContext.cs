using System;
using System.Collections.Generic;
using Heroes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Heroes.Data;

public partial class HeroesContext : IdentityDbContext <IdentityUser>
{
    public HeroesContext(DbContextOptions<HeroesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Heroe> Heroe { get; set; }

    public virtual DbSet<SuperPoderes> SuperPoderes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Heroe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Heroes__3214EC07979B2AA9");
        });

        modelBuilder.Entity<SuperPoderes>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SuperPod__3214EC077C0F17B7");

            entity.HasOne(d => d.Heroe).WithMany(p => p.SuperPoderes).HasConstraintName("FK_SuperPoderes_Heroes");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

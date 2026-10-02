using iRoute.DTO;
using iRoute.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace iRoute.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Commerce> Commerces { get; set; }

    public virtual DbSet<CommerceQuarantine> CommerceQuarantines { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=IRoute;User Id=sa;Password=sa;TrustServerCertificate=True");


    public async Task InsertaCommerce(int numdoc, string descripcion,  string fecha)
    {
        //var sqlStr = "EXEC InsertaCommerce @p0, @p1, @p2 ";
        await Database.ExecuteSqlRawAsync("EXEC InsertaCommerce @p0, @p1, @p2 ", numdoc, descripcion,  fecha);
    }

    public virtual DbSet<Commerce> Commerce { get; set; }
    public async Task<List<Commerce>> ConsultaCommerce()
    {
        return await Commerce
        .FromSqlRaw("EXEC ConsultaCommerce")
        .ToListAsync();
    }






    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Commerce>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("commerce");

            entity.Property(e => e.PcNomcomred)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pc_nomcomred");
            entity.Property(e => e.PcNumdoc)
                .ValueGeneratedOnAdd()
                .HasColumnName("pc_numdoc");
            entity.Property(e => e.PcProcessdate)
                .HasColumnType("datetime")
                .HasColumnName("pc_processdate");
        });

        modelBuilder.Entity<CommerceQuarantine>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("commerce_quarantine");

            entity.Property(e => e.QuaErrorDescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("qua_error_description");
            entity.Property(e => e.QuaIdReg)
                .ValueGeneratedOnAdd()
                .HasColumnName("qua_id_reg");
            entity.Property(e => e.QuaNumDoc).HasColumnName("qua_num_doc");
            entity.Property(e => e.QuaProcessDate)
                .HasColumnType("datetime")
                .HasColumnName("qua_process_date");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

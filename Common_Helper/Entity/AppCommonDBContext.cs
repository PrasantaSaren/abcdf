using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Common_Helper.Entity
{
    public partial class AppCommonDBContext : DbContext
    {
        public AppCommonDBContext(DbContextOptions<AppCommonDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BeAuditLog> BeAuditLogs { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BeAuditLog>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_BE_AuditLog");

                entity.ToTable("BeAuditLog");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Browser).HasMaxLength(20);
                entity.Property(e => e.Code).HasMaxLength(255);
                entity.Property(e => e.EventId).HasColumnName("EventID");
                entity.Property(e => e.Form).HasMaxLength(50);
                entity.Property(e => e.Ip)
                    .HasMaxLength(50)
                    .HasColumnName("IP");
                entity.Property(e => e.LogTime).HasColumnType("datetime");
                entity.Property(e => e.TableId)
                    .HasMaxLength(50)
                    .HasColumnName("TableID");
                entity.Property(e => e.UserEmail).HasMaxLength(50);
            });




        }


    }
}

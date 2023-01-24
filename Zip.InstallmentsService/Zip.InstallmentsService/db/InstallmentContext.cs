using Microsoft.EntityFrameworkCore;
using Zip.InstallmentsService.Models;

namespace Zip.InstallmentsService.db
{
    public partial class InstallmentContext : DbContext
    {
        public InstallmentContext(DbContextOptions<InstallmentContext> options): base(options) { }

        public virtual DbSet<Installment> Installmentes { get; set; }
        public virtual DbSet<PaymentPlan> PaymentPlans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\Repos\\Zip.InstallmentsService\\Zip.InstallmentsService\\Zip.InstallmentsService\\db\\InstallmentDB.mdf;Integrated Security=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Installment>(entity =>
            {
                entity.ToTable(nameof(Installment)).HasKey(e => e.Id).IsClustered();
                entity.Property(e => e.DueDate).HasColumnName("due_date");
                entity.Property(e => e.Amount).
                HasColumnName("amount").
                HasColumnType<decimal>("decimal(18,2)").
                IsRequired(true);
                entity.Property(e => e.PaymentPlanId).HasColumnName("payment_plan_id");

                entity.HasOne(d => d.PaymentPlan).WithMany(p => p.Installments)
                                .HasForeignKey(d => d.PaymentPlanId)
                                .OnDelete(DeleteBehavior.Cascade)
                                .HasConstraintName("FK_service_id");
            });
            modelBuilder.Entity<PaymentPlan>(entity =>
            {
                entity.ToTable(nameof(PaymentPlan)).HasKey(e => e.Id).IsClustered();
                //entity.HasKey(e => e.Id).HasColumnName("id").
                //IsRequired(true);
                entity.Property(e => e.PurchaseAmount).
                HasColumnName("purchase_amount").
                HasColumnType<decimal>("decimal(18,2)").
                IsRequired(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyCashIdentityProject.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=OPER;initial catalog=EasyCashDb; integrated Security=True");
        }

        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<CustomerAccountProcess> CustomerAccountProcesses { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CustomerAccountProcess>()
                .HasOne(x => x.SenderCustomer).WithMany(x => x.CustomerSender).HasForeignKey(x => x.SenderId).OnDelete(DeleteBehavior.ClientNoAction);

            builder.Entity<CustomerAccountProcess>()
                .HasOne(x => x.ReceiverCustomer).WithMany(x => x.CustomerReceiver).HasForeignKey(x => x.ReceiverId).OnDelete(DeleteBehavior.ClientNoAction);

            base.OnModelCreating(builder);
        }
    }
}
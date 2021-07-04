using System;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;

#nullable disable

namespace DataAccess.Concrete.EntityFramework
{
    public partial class CmsContext : DbContext
    {
        public CmsContext()
        {
        }

        public CmsContext(DbContextOptions<CmsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Campaign> Campaigns { get; set; }
        public virtual DbSet<CampaignDay> CampaignDays { get; set; }
        public virtual DbSet<CampaignHour> CampaignHours { get; set; }
        public virtual DbSet<CampaignReward> CampaignRewards { get; set; }
        public virtual DbSet<CampaignRewardType> CampaignRewardTypes { get; set; }
        public virtual DbSet<CampaignRule> CampaignRules { get; set; }
        public virtual DbSet<CampaignRuleType> CampaignRuleTypes { get; set; }
        public virtual DbSet<CampaignType> CampaignTypes { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Channel> Channels { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<OperationClaim> OperationClaims { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<TransactionProduct> TransactionProducts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                optionsBuilder
                .EnableSensitiveDataLogging(true)
                .UseLoggerFactory(LoggerFactory.Create(optionsBuilder => optionsBuilder.AddConsole()))
                .UseSqlServer("Server=DESKTOP-T6IPPDN\\SQLEXPRESS;Database=CampaignManagementDb;Trusted_Connection=true");
        }       
    }
}

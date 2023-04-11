using AdvBoxCRM.Boxes;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using AdvBoxCRM.Employees;
using AdvBoxCRM.Guests;
using AdvBoxCRM.Maintanances;

namespace AdvBoxCRM.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class AdvBoxCRMDbContext :
    AbpDbContext<AdvBoxCRMDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{


    public DbSet<Box> Boxes  { get; set; }
    public DbSet<Maintanance> Maintanances  { get; set; }
    public DbSet<Employee> Employees  { get; set; }
    public DbSet<Guest> Guests  { get; set; }




    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public AdvBoxCRMDbContext(DbContextOptions<AdvBoxCRMDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */


        builder.Entity<Box>(b =>
        {
            b.ToTable(AdvBoxCRMConsts.DbTablePrefix + "Boxes",
                AdvBoxCRMConsts.DbSchema);
            b.ConfigureByConvention();    //auto configure for the base class props
            b.Property(x => x.BoxNumber).IsRequired().HasMaxLength(10);
            b.Property(x => x.LastMaintenanceDate).IsRequired();
            b.Property(x=>x.BoxAdress).IsRequired();
            b.Property(x => x.BoxCorrosion).IsRequired();
            b.Property(x=>x.BoxFullness).IsRequired();
            b.Property(x=>x.Status).IsRequired();
        });

        builder.Entity<Guest>(b =>
        {
            b.ToTable(AdvBoxCRMConsts.DbTablePrefix + "Guest", AdvBoxCRMConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.GuestName).IsRequired().HasMaxLength(50);
            b.Property(x => x.GuestSurname).IsRequired().HasMaxLength(50);
            b.Property(x => x.GuestPhone).IsRequired().HasMaxLength(11);
        });
        builder.Entity<Employee>(b =>
        {
            b.ToTable(AdvBoxCRMConsts.DbTablePrefix + "Employees", AdvBoxCRMConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.EmployeeName).IsRequired().HasMaxLength(50);
            b.Property(x => x.EmployeeSurname).IsRequired().HasMaxLength(50);
            b.Property(x => x.EmployeePhone).IsRequired().HasMaxLength(11);
            b.Property(x => x.Email).IsRequired();
            
        });
        builder.Entity<Maintanance>(b =>
        {
            b.ToTable(AdvBoxCRMConsts.DbTablePrefix + "Maintanances", AdvBoxCRMConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.MaintenanceDate).IsRequired();
            b.HasOne<Box>().WithMany().HasForeignKey(x => x.BoxID).IsRequired();
            b.HasOne<Employee>().WithMany().HasForeignKey(x => x.EmployeeID).IsRequired();
        });


    }
}

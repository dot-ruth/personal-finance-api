using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using personal_finance_api.Models;
using Microsoft.AspNetCore.Identity;

namespace personal_finance_api;

public  class PersonalFinanceDBContext : IdentityDbContext<User> 
{
    public PersonalFinanceDBContext(DbContextOptions<PersonalFinanceDBContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<User>(entity => 
        {
            entity.ToTable(name: "User");
        });

        modelBuilder.Entity<IdentityRole>(entity => 
        {
            entity.ToTable(name: "Roles");
        });

        modelBuilder.Entity<IdentityUserRole<string>>(entity => 
        {
            entity.ToTable("UserRoles");
        });

        modelBuilder.Entity<IdentityUserClaim<string>>(entity => 
        {
            entity.ToTable("UserClaims");
        });

        modelBuilder.Entity<IdentityUserLogin<string>>(entity => 
        {
            entity.ToTable("UserLogins");
        });

        modelBuilder.Entity<IdentityRoleClaim<string>>(entity => 
        {
            entity.ToTable("RoleClaims");
        });

        modelBuilder.Entity<IdentityUserToken<string>>(entity => 
        {
            entity.ToTable("UserTokens");
        });
    }

        
}


using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UserAuthInMemoryApp.Data
{
    // This will in herit the standard tables for users, roles, and Claims
    
 
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext(options) 
    {}
    
    
}
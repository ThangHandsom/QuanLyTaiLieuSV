using Microsoft.EntityFrameworkCore;
using WebApp1.Areas.Admin.Models;

namespace WebApp1.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<AdminMenu> AdminMenus { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
        public DbSet<SubComment> SubComments { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Contact> Contacts { get; set; }    
      
    }
}

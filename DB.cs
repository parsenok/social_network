using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using social_network.Entities;


public class YourDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    private readonly IUserService _userService;
    public DbSet<User> Users { get; set; }
    public DbSet<Chat> Chats { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Friends_list> Friends_lists { get; set; }
    public DbSet<Lenta> Lenta { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Sub> Subs { get; set; }
    public DbSet<u_sub> u_subs { get; set; }
    public YourDbContext(DbContextOptions<YourDbContext> options, IConfiguration configuration, IUserService userService)
        : base(options)
    {
        _configuration = configuration;
        _userService = userService;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            
            string connectionString = _configuration.GetConnectionString("MyDatabase");

            
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}

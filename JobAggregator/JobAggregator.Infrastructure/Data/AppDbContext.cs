using JobAggregator.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JobAggregator.Infrastructure.Data;

public class AppDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<Article> Articles { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Vacancy> Vacancies { get; set; }
    public DbSet<Chat> Chats { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Offer> Offers { get; set; }
    public DbSet<OrganizationAplication> OrganizationAplications { get; set; }
    public DbSet<Requirement> Requirements { get; set; }
    public DbSet<Responsibility> Responsibilities { get; set; }
    public DbSet<Resume> Resumes { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Specialisation> Specializations { get; set; }
    public DbSet<UserAplication> UserAplications { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}

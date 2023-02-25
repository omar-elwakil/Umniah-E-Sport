using Microsoft.EntityFrameworkCore;
using Umniah_E_Sport.Domain.Entities;

namespace Umniah_E_Sport.Persistence
{
    public class UmniahContext : DbContext
    {
        public UmniahContext(DbContextOptions<UmniahContext> options)
         : base(options)
        {
        }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<UserTournaments> UserTournaments { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<UserGames> UserGames { get; set; }
        public DbSet<NewsEntity> News { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<TermsAndConditions> TermsAndConditions { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<TournamentType> TournamentTypes { get; set; }
        public DbSet<Arena> Arenas { get; set; }
        public DbSet<NotificationLog> NotificationLogs { get; set; }
        public DbSet<CasualCategory> CasualCategories { get; set; }
        public DbSet<CasualGame> CasualGames { get; set; }
        public DbSet<CasualGameImage> CasualGameImages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // n : m relation between User and Tournament
            modelBuilder.Entity<UserTournaments>().HasKey(e => new { e.UserId, e.TournamentId });
            // 1 : n relation between User and UserTournaments
            modelBuilder.Entity<UserTournaments>()
                .HasOne<User>(ut => ut.User)
                .WithMany(u => u.UserTournaments)
                .HasForeignKey(ut => ut.UserId);
            // 1 : n relation between Tournament and UserTournament
            modelBuilder.Entity<UserTournaments>()
                .HasOne<Tournament>(ut => ut.Tournament)
                .WithMany(t => t.UserTournaments)
                .HasForeignKey(ut => ut.TournamentId);

            // n : m relation between User and Games
            modelBuilder.Entity<UserGames>().HasKey(e => new { e.UserId, e.GameId });
            // 1 : n relation between User and UserGames
            modelBuilder.Entity<UserGames>()
                .HasOne<User>(ug => ug.User)
                .WithMany(u => u.UserGames)
                .HasForeignKey(ut => ut.UserId);
            // 1 : n relation between Game and UserGames
            modelBuilder.Entity<UserGames>()
                .HasOne<Game>(ug => ug.Game)
                .WithMany(g => g.UserGames)
                .HasForeignKey(ug => ug.GameId);
            modelBuilder.Entity<CasualGame>()
                .HasOne<CasualCategory>(cg => cg.CasualCategory)
                .WithMany(cc => cc.CasualGames)
                .HasForeignKey(cg => cg.CasualCategoryId);
            modelBuilder.Entity<CasualGameImage>()
                .HasOne<CasualGame>(cg => cg.CasualGame)
                .WithMany(cc => cc.CasualGameImages)
                .HasForeignKey(cg => cg.CasualGameId);


            // 1 : 1 relation between TermsAndConditions and Game
            // Where the forign key constrain is on the Game enitity
            // i.e., Game can't have duplicate or invalid TermsAndConditionsIds
            // While TermsAndConditions can have duplicate or invalid GameIds
            modelBuilder.Entity<TermsAndConditions>() ///// TODO: check if this should be reverted
                .HasOne(e => e.Game)
                .WithOne(e => e.TermsAndConditions)
                .HasForeignKey<Game>(e => e.TermsAndConditionsId);

            // Global filter for soft deleted & for entities not available yet
            modelBuilder.Entity<Game>().HasQueryFilter(q => !q.IsDeleted);
            modelBuilder.Entity<Tournament>().HasQueryFilter(q => !q.IsDeleted);
            modelBuilder.Entity<Location>().HasQueryFilter(q => !q.IsDeleted);
            modelBuilder.Entity<TournamentType>().HasQueryFilter(q => !q.IsDeleted);
            modelBuilder.Entity<Arena>().HasQueryFilter(q => !q.IsDeleted);
            modelBuilder.Entity<Achievement>().HasQueryFilter(q => !q.IsDeleted);
            modelBuilder.Entity<Video>().HasQueryFilter(q => !q.IsDeleted);
            modelBuilder.Entity<NewsEntity>().HasQueryFilter(q => !q.IsDeleted);
            modelBuilder.Entity<CasualCategory>().HasQueryFilter(q => !q.IsDeleted);
            modelBuilder.Entity<CasualGame>().HasQueryFilter(q => !q.IsDeleted);
            modelBuilder.Entity<CasualGameImage>().HasQueryFilter(q => !q.IsDeleted);

        }
    }
}
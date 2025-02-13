using ZooWeb.Data.Extensions;
using ZooWeb.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ZooWeb.Web.Data
{
    public class ZooWebDbContext : IdentityDbContext<ZooWebUser>
    {
        public DbSet<Attachment> Attachments { get; set; }

        public DbSet<ZooWebCommunity> Communities { get; set; }

        public DbSet<ZooWebThread> Threads { get; set; }

        public DbSet<ZooWebThread> Tags { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Reaction> Reactions { get; set; }

        public DbSet<ZooWebRole> ForumRoles { get; set; }

        public ZooWebDbContext(DbContextOptions<ZooWebDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserThreadReaction>()
                .HasOne(utr => utr.Thread)
                .WithMany(t => t.Reactions)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ZooWebUser>()
                .HasOne(u => u.ForumRole)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.ConfigureMetadataEntity<ZooWebRole>();
            builder.ConfigureMetadataEntity<ZooWebTag>();

            builder.Entity<ZooWebCommunity>()
                .HasOne(gc => gc.ThumbnailPhoto)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ZooWebCommunity>()
                .HasOne(gc => gc.BannerPhoto)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ZooWebCommunity>()
                .HasMany(gc => gc.Tags)
                .WithMany();

            builder.Entity<ZooWebThread>()
                .HasMany(gt => gt.Tags)
                .WithMany();

            builder.Entity<Comment>()
                .HasMany(c => c.Attachments)
                .WithMany();

            builder.Entity<Comment>()
                .HasMany(c => c.Replies)
                .WithOne(c => c.Parent)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ZooWebCommunity>()
                .HasOne(gc => gc.ThumbnailPhoto);

            builder.Entity<ZooWebCommunity>()
                .HasOne(gc => gc.BannerPhoto);

            builder.Entity<ZooWebThread>()
                .HasMany(gt => gt.Attachments)
                .WithMany();


            base.OnModelCreating(builder);
        }
    }
}

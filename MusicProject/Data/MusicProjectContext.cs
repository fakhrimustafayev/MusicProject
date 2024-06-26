﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MusicProject.Models;

namespace MusicProject.Data
{
    public class MusicProjectContext : IdentityDbContext<User>
    {
        public MusicProjectContext (DbContextOptions<MusicProjectContext> options)
            : base(options)
        {
        }
        public DbSet<UserFavorite> UserFavorites { get; set; }

        public DbSet<MusicProject.Models.User> User { get; set; } = default!;
        public DbSet<SpoTrack> SpoTracks { get; set; }
        public DbSet<MusicProject.Models.Playlist> Playlist { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserFavorite>()
          .HasKey(uf => new { uf.UserId, uf.TrackId });

            modelBuilder.Entity<SpoTrack>()
                .HasKey(track => track.id);


            modelBuilder.Entity<SpoAlbum>()
          .HasMany(album => album.artists)
          .WithOne(artist => artist.Album)
          .HasForeignKey(artist => artist.AlbumId);

            modelBuilder.Entity<SpoTrack>().Ignore(e => e.external_ids);
            modelBuilder.Entity<SpoAlbum>().Ignore(e => e.external_urls);
            modelBuilder.Entity<SpoArtist>().Ignore(e => e.external_urls);
            modelBuilder.Entity<SpoTrack>().Ignore(e => e.external_urls);
            modelBuilder.Entity<Linked_From>().Ignore(e => e.external_urls);
            modelBuilder.Entity<SpoAlbum>().Ignore(e => e.images);
            // Configure other entities and relationships as needed
        }








        // public DbSet<MusicProject.Models.Category> Category { get; set; } = default!;
        //public DbSet<MusicProject.Models.Art.Artist> Artist { get; set; } = default!;

        //public DbSet<MusicProject.Models.Album> Album { get; set; } = default!;

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Artist>()
        //        .HasMany(a => a.Songs) // Artist has many Tracks
        //        .WithOne(t => t.Artist) // Track has one Artist
        //        .HasForeignKey(t => t.ArtistId); // Foreign key relationship

        //    // Other configurations
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Track>()
        //        .HasOne(t => t.Artist)
        //        .WithMany()
        //        .HasForeignKey(t => t.Id)
        //        .OnDelete(DeleteBehavior.NoAction); // Specify ON DELETE NO ACTION for the Artist relationship

        //    modelBuilder.Entity<Track>()
        //        .HasOne(t => t.Album)
        //        .WithMany(a => a.Tracklist)
        //        .HasForeignKey(t => t.AlbumId);

        //    base.OnModelCreating(modelBuilder);
        //}


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<External_Urls1>().HasNoKey();
        //    base.OnModelCreating(modelBuilder);
        //}

    }
}

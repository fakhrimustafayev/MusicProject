using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicProject.Migrations
{
    /// <inheritdoc />
    public partial class econdigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Artist_ArtistId",
                table: "Album");

            migrationBuilder.DropForeignKey(
                name: "FK_Track_Artist_ArtistId",
                table: "Track");

            migrationBuilder.DropIndex(
                name: "IX_Album_ArtistId",
                table: "Album");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Album");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Track",
                newName: "TitleVersion");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Playlist",
                newName: "Tracklist");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Album",
                newName: "Type");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Track",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExplicitContentCover",
                table: "Track",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExplicitContentLyrics",
                table: "Track",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ExplicitLyrics",
                table: "Track",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Track",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Md5Image",
                table: "Track",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Preview",
                table: "Track",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Rank",
                table: "Track",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Readable",
                table: "Track",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "TimeAdd",
                table: "Track",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Track",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TitleShort",
                table: "Track",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Checksum",
                table: "Playlist",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Collaborative",
                table: "Playlist",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Playlist",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Playlist",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Playlist",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Playlist",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Fans",
                table: "Playlist",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsLovedTrack",
                table: "Playlist",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Playlist",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Md5Image",
                table: "Playlist",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NbTracks",
                table: "Playlist",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Playlist",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PictureBig",
                table: "Playlist",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PictureMedium",
                table: "Playlist",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PictureSmall",
                table: "Playlist",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PictureType",
                table: "Playlist",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PictureXl",
                table: "Playlist",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Public",
                table: "Playlist",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Share",
                table: "Playlist",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Playlist",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Artist",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tracklist",
                table: "Artist",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Artist",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "Album",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CoverBig",
                table: "Album",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CoverMedium",
                table: "Album",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CoverSmall",
                table: "Album",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CoverXl",
                table: "Album",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Md5Image",
                table: "Album",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Album",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tracklist",
                table: "Album",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Creator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tracklist = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creator", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Playlist_CreatorId",
                table: "Playlist",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlist_Creator_CreatorId",
                table: "Playlist",
                column: "CreatorId",
                principalTable: "Creator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Track_Artist_ArtistId",
                table: "Track",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlist_Creator_CreatorId",
                table: "Playlist");

            migrationBuilder.DropForeignKey(
                name: "FK_Track_Artist_ArtistId",
                table: "Track");

            migrationBuilder.DropTable(
                name: "Creator");

            migrationBuilder.DropIndex(
                name: "IX_Playlist_CreatorId",
                table: "Playlist");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Track");

            migrationBuilder.DropColumn(
                name: "ExplicitContentCover",
                table: "Track");

            migrationBuilder.DropColumn(
                name: "ExplicitContentLyrics",
                table: "Track");

            migrationBuilder.DropColumn(
                name: "ExplicitLyrics",
                table: "Track");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "Track");

            migrationBuilder.DropColumn(
                name: "Md5Image",
                table: "Track");

            migrationBuilder.DropColumn(
                name: "Preview",
                table: "Track");

            migrationBuilder.DropColumn(
                name: "Rank",
                table: "Track");

            migrationBuilder.DropColumn(
                name: "Readable",
                table: "Track");

            migrationBuilder.DropColumn(
                name: "TimeAdd",
                table: "Track");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Track");

            migrationBuilder.DropColumn(
                name: "TitleShort",
                table: "Track");

            migrationBuilder.DropColumn(
                name: "Checksum",
                table: "Playlist");

            migrationBuilder.DropColumn(
                name: "Collaborative",
                table: "Playlist");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Playlist");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Playlist");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Playlist");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Playlist");

            migrationBuilder.DropColumn(
                name: "Fans",
                table: "Playlist");

            migrationBuilder.DropColumn(
                name: "IsLovedTrack",
                table: "Playlist");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "Playlist");

            migrationBuilder.DropColumn(
                name: "Md5Image",
                table: "Playlist");

            migrationBuilder.DropColumn(
                name: "NbTracks",
                table: "Playlist");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Playlist");

            migrationBuilder.DropColumn(
                name: "PictureBig",
                table: "Playlist");

            migrationBuilder.DropColumn(
                name: "PictureMedium",
                table: "Playlist");

            migrationBuilder.DropColumn(
                name: "PictureSmall",
                table: "Playlist");

            migrationBuilder.DropColumn(
                name: "PictureType",
                table: "Playlist");

            migrationBuilder.DropColumn(
                name: "PictureXl",
                table: "Playlist");

            migrationBuilder.DropColumn(
                name: "Public",
                table: "Playlist");

            migrationBuilder.DropColumn(
                name: "Share",
                table: "Playlist");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Playlist");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "Tracklist",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "Cover",
                table: "Album");

            migrationBuilder.DropColumn(
                name: "CoverBig",
                table: "Album");

            migrationBuilder.DropColumn(
                name: "CoverMedium",
                table: "Album");

            migrationBuilder.DropColumn(
                name: "CoverSmall",
                table: "Album");

            migrationBuilder.DropColumn(
                name: "CoverXl",
                table: "Album");

            migrationBuilder.DropColumn(
                name: "Md5Image",
                table: "Album");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Album");

            migrationBuilder.DropColumn(
                name: "Tracklist",
                table: "Album");

            migrationBuilder.RenameColumn(
                name: "TitleVersion",
                table: "Track",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Tracklist",
                table: "Playlist",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Album",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "Album",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Album_ArtistId",
                table: "Album",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Artist_ArtistId",
                table: "Album",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Track_Artist_ArtistId",
                table: "Track",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id");
        }
    }
}

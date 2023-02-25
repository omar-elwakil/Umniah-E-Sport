using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UmniahESport.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initialdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arenas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEN = table.Column<string>(name: "Name_EN", type: "nvarchar(300)", nullable: false),
                    NameAR = table.Column<string>(name: "Name_AR", type: "nvarchar(300)", nullable: false),
                    CountryNameEN = table.Column<string>(name: "CountryName_EN", type: "nvarchar(300)", nullable: false),
                    CountryNameAR = table.Column<string>(name: "CountryName_AR", type: "nvarchar(300)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arenas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Badges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEN = table.Column<string>(name: "Name_EN", type: "nvarchar(300)", nullable: false),
                    NameAR = table.Column<string>(name: "Name_AR", type: "nvarchar(300)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    ImageSize = table.Column<string>(type: "nvarchar(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CasualCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEN = table.Column<string>(name: "Name_EN", type: "nvarchar(max)", nullable: false),
                    NameAR = table.Column<string>(name: "Name_AR", type: "nvarchar(max)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasualCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TextEN = table.Column<string>(name: "Text_EN", type: "nvarchar(300)", nullable: false),
                    TextAR = table.Column<string>(name: "Text_AR", type: "nvarchar(300)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MSISDN = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    ActionType = table.Column<int>(type: "int", nullable: false),
                    Response = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    CreationTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TermsAndConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    ContentEN = table.Column<string>(name: "Content_EN", type: "nvarchar(2000)", nullable: false),
                    ContentAR = table.Column<string>(name: "Content_AR", type: "nvarchar(2000)", nullable: false),
                    EndTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermsAndConditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TournamentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TextEN = table.Column<string>(name: "Text_EN", type: "nvarchar(300)", nullable: false),
                    TextAR = table.Column<string>(name: "Text_AR", type: "nvarchar(300)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Msisdn = table.Column<string>(type: "nvarchar(300)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(300)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    CreationTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UnsubscribeTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SubscribeTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSubscribe = table.Column<bool>(type: "bit", nullable: false),
                    RenewalDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CasualGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleEN = table.Column<string>(name: "Title_EN", type: "nvarchar(max)", nullable: false),
                    TitleAR = table.Column<string>(name: "Title_AR", type: "nvarchar(max)", nullable: false),
                    DescriptionEN = table.Column<string>(name: "Description_EN", type: "nvarchar(max)", nullable: false),
                    DescriptionAR = table.Column<string>(name: "Description_AR", type: "nvarchar(max)", nullable: false),
                    GameLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BannerImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThumbnailImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<int>(type: "int", nullable: false),
                    IsFreatured = table.Column<bool>(type: "bit", nullable: false),
                    ProvidingBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfClicked = table.Column<int>(type: "int", nullable: false),
                    CasualCategoryId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasualGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CasualGames_CasualCategories_CasualCategoryId",
                        column: x => x.CasualCategoryId,
                        principalTable: "CasualCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleEN = table.Column<string>(name: "Title_EN", type: "nvarchar(300)", nullable: false),
                    TitleAR = table.Column<string>(name: "Title_AR", type: "nvarchar(300)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    ShortCode = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    GameLink = table.Column<string>(type: "nvarchar(300)", nullable: true),
                    TermsAndConditionsId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_TermsAndConditions_TermsAndConditionsId",
                        column: x => x.TermsAndConditionsId,
                        principalTable: "TermsAndConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Achievements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    NameEN = table.Column<string>(name: "Name_EN", type: "nvarchar(300)", nullable: false),
                    NameAR = table.Column<string>(name: "Name_AR", type: "nvarchar(300)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Achievements_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CasualGameImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CasualGameId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasualGameImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CasualGameImages_CasualGames_CasualGameId",
                        column: x => x.CasualGameId,
                        principalTable: "CasualGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    TitleEN = table.Column<string>(name: "Title_EN", type: "nvarchar(300)", nullable: false),
                    TitleAR = table.Column<string>(name: "Title_AR", type: "nvarchar(300)", nullable: false),
                    DescriptionEN = table.Column<string>(name: "Description_EN", type: "nvarchar(2000)", nullable: false),
                    DescriptionAR = table.Column<string>(name: "Description_AR", type: "nvarchar(2000)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    ArenaId = table.Column<int>(type: "int", nullable: true),
                    TitleEN = table.Column<string>(name: "Title_EN", type: "nvarchar(300)", nullable: false),
                    TitleAR = table.Column<string>(name: "Title_AR", type: "nvarchar(300)", nullable: false),
                    DescriptionEN = table.Column<string>(name: "Description_EN", type: "nvarchar(2000)", nullable: false),
                    DescriptionAR = table.Column<string>(name: "Description_AR", type: "nvarchar(2000)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    BannerName = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    OrganizerEN = table.Column<string>(name: "Organizer_EN", type: "nvarchar(300)", nullable: false),
                    OrganizerAR = table.Column<string>(name: "Organizer_AR", type: "nvarchar(300)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    TournamentTypeId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    PrizeAmount = table.Column<int>(type: "int", nullable: false),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false),
                    SubscriptionFee = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegisterationStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegisterationEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationTimeSpan = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DiscordLink = table.Column<string>(type: "nvarchar(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tournaments_Arenas_ArenaId",
                        column: x => x.ArenaId,
                        principalTable: "Arenas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tournaments_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tournaments_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tournaments_TournamentTypes_TournamentTypeId",
                        column: x => x.TournamentTypeId,
                        principalTable: "TournamentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGames",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    UserScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGames", x => new { x.UserId, x.GameId });
                    table.ForeignKey(
                        name: "FK_UserGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGames_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    VideoFileName = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    TitleEN = table.Column<string>(name: "Title_EN", type: "nvarchar(300)", nullable: false),
                    TitleAR = table.Column<string>(name: "Title_AR", type: "nvarchar(300)", nullable: false),
                    DescriptionEN = table.Column<string>(name: "Description_EN", type: "nvarchar(2000)", nullable: false),
                    DescriptionAR = table.Column<string>(name: "Description_AR", type: "nvarchar(2000)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videos_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTournaments",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TournamentId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    IngameId = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsTheFirst = table.Column<bool>(type: "bit", nullable: false),
                    IsJoinSmsSent = table.Column<bool>(type: "bit", nullable: false),
                    IsDailySmsSent = table.Column<bool>(type: "bit", nullable: false),
                    IsHourlySmsSent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTournaments", x => new { x.UserId, x.TournamentId });
                    table.ForeignKey(
                        name: "FK_UserTournaments_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTournaments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_UserId",
                table: "Achievements",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CasualGameImages_CasualGameId",
                table: "CasualGameImages",
                column: "CasualGameId");

            migrationBuilder.CreateIndex(
                name: "IX_CasualGames_CasualCategoryId",
                table: "CasualGames",
                column: "CasualCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_TermsAndConditionsId",
                table: "Games",
                column: "TermsAndConditionsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_News_GameId",
                table: "News",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_ArenaId",
                table: "Tournaments",
                column: "ArenaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_GameId",
                table: "Tournaments",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_LocationId",
                table: "Tournaments",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_TournamentTypeId",
                table: "Tournaments",
                column: "TournamentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGames_GameId",
                table: "UserGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTournaments_TournamentId",
                table: "UserTournaments",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_GameId",
                table: "Videos",
                column: "GameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achievements");

            migrationBuilder.DropTable(
                name: "Badges");

            migrationBuilder.DropTable(
                name: "CasualGameImages");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "NotificationLogs");

            migrationBuilder.DropTable(
                name: "UserGames");

            migrationBuilder.DropTable(
                name: "UserTournaments");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "CasualGames");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CasualCategories");

            migrationBuilder.DropTable(
                name: "Arenas");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "TournamentTypes");

            migrationBuilder.DropTable(
                name: "TermsAndConditions");
        }
    }
}

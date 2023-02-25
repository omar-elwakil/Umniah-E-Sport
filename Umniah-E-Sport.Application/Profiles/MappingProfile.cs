using AutoMapper;
using Umniah_E_Sport.Application.Features.Arenas.Quereis.GetAllArenas;
using Umniah_E_Sport.Application.Features.Videos.Queries.GetAllVideos;
using Umniah_E_Sport.Application.Features.Videos.Queries.GetLatestVideos;
using Umniah_E_Sport.Application.Features.Videos.Queries.GetRelatedVideos;
using Umniah_E_Sport.Application.Features.Videos.Queries.GetVideoById;
using Umniah_E_Sport.Application.Features.Videos.Queries.GetVideosByGame;
using Umniah_E_Sport.Application.Features.Games.Queries.GetAllGames;
using Umniah_E_Sport.Application.Features.Games.Queries.GetTrendingGames;
using Umniah_E_Sport.Application.Features.News.Quereis.GetAllNews;
using Umniah_E_Sport.Application.Features.News.Quereis.GetLatestNews;
using Umniah_E_Sport.Application.Features.News.Quereis.GetNews;
using Umniah_E_Sport.Domain.Entities;
using Umniah_E_Sport.Application.Features.Users.Queries.ValidateOTP;
using Umniah_E_Sport.Application.Features.Users.Commands.SubscribeUser;
using Umniah_E_Sport.Application.Features.Users.Commands.UnsubscribeUser;
using Umniah_E_Sport.Application.Features.Tournaments.Queries.GetAllTournamets;
using Umniah_E_Sport.Application.Features.Tournaments.Queries.GetFeaturedTournaments;
using Umniah_E_Sport.Application.Features.Tournaments.Queries.GetUpcomingTournaments;
using System;
using Umniah_E_Sport.Application.Features.Tournaments.Queries.GetLiveTournaments;
using Umniah_E_Sport.Application.Features.Tournaments.Queries.GetFinishedTournaments;
using Umniah_E_Sport.Application.Features.Tournaments.Queries.GetTournamentLeaderboard;
using Umniah_E_Sport.Application.Features.Tournaments.Queries.GetTournament;
using Umniah_E_Sport.Application.Features.Users.Queries.GetLeaderBoard;
using Umniah_E_Sport.Application.Features.TermsAndCondtions.Queries.GetTermsAndConditionsByTournament;
using Umniah_E_Sport.Application.Features.Users.Queries.GetUserProfile;
using Umniah_E_Sport.Application.Features.Users.Queries.GetUserAchievements;
using Umniah_E_Sport.Domain.Enums;
using Umniah_E_Sport.Application.Features.Users.Queries.MyLeaderBoard;
using Umniah_E_Sport.Domain.DTOs.LeaderBoard;
using Umniah_E_Sport.Application.Features.Arenas.Quereis.GetArena;
using Umniah_E_Sport.Application.Features.Arenas.Commands.CreateArena;
using Umniah_E_Sport.Application.Features.Arenas.Commands.UpdateArena;
using Umniah_E_Sport.Application.Features.Locations.Commands.CreateLocation;
using Umniah_E_Sport.Application.Features.Locations.Queries.GetAllLocations;
using Umniah_E_Sport.Application.Features.Locations.Commands.UpdateLocation;
using Umniah_E_Sport.Application.Features.News.Commands.CreateNews;
using Umniah_E_Sport.Application.Features.News.Commands.UpdateNews;
using Umniah_E_Sport.Application.Features.Achievements.Queries.GetAchievementById;
using Umniah_E_Sport.Application.Features.Achievements.Commands.AddAchievementToUser;
using Umniah_E_Sport.Application.Features.Videos.Commands.AddVideoToGame;
using Umniah_E_Sport.Application.Features.Videos.Commands.UpdateVideoById;
using Umniah_E_Sport.Application.Features.Games.Commands.AddGame;
using Umniah_E_Sport.Application.Features.Games.Commands.UpdateGame;
using Umniah_E_Sport.Application.Features.Games.Queries.GetGame;
using Umniah_E_Sport.Application.Features.UserGameFeature.Queries.GetUsersByGame;
using Umniah_E_Sport.Application.Features.UserGameFeature.Queries.GetUsersGames;
using Umniah_E_Sport.Application.Features.Users.Queries.GetAllUsersOrderedByScore;
using Umniah_E_Sport.Application.Features.Users.Queries.GetUsersWithKeywordOrderedByScore;
using Umniah_E_Sport.Application.Features.Tournaments.Queries.GetTournamentsByUserId;
using Umniah_E_Sport.Application.Features.TournamentTypeFeature.GetAllTournamentTypes;
using Umniah_E_Sport.Application.Features.TournamentTypeFeature.Commands.CreateTournamentType;
using Umniah_E_Sport.Application.Features.TournamentTypeFeature.Commands.UpdateTournamentType;
using Umniah_E_Sport.Application.Features.Tournaments.Commands.CreateTournament;
using Umniah_E_Sport.Application.Features.Tournaments.Commands.UpdateTournament;
using Umniah_E_Sport.Application.Features.TournamentTypeFeature.Queries.GetTournamentTypeById;
using Umniah_E_Sport.Application.Features.Locations.Queries.GetLocationById;
using Umniah_E_Sport.Application.Features.Games.Queries.GetUserGamesByUserId;
using Umniah_E_Sport.Application.Features.Achievements.Queries.GetUserAchievementsByUserId;
using Umniah_E_Sport.Application.Features.Achievements.Commands.UpdateUserAchievement;
using Umniah_E_Sport.Application.Features.Badges.Queries.GetAllBadges;
using Umniah_E_Sport.Application.Features.Tournaments.Queries.GetFinishedTournamentsByArenaId;
using Umniah_E_Sport.Application.Features.Tournaments.Queries.GetLiveTournamentsByArenaId;
using Umniah_E_Sport.Application.Features.Tournaments.Queries.GetUpcomingTournamentsByArenaId;
using Umniah_E_Sport.Application.Features.Tournaments.Queries.GetTournamentsByGameId;
using Umniah_E_Sport.Application.Responses;
using Umniah_E_Sport.Application.Features.Users.Queries.SendSMS;
using Umniah_E_Sport.Application.Features.Users.Queries.GetUserMailProfile;
using Umniah_E_Sport.Application.Features.CasualCategories.Queries.GetAllCasualCategories;
using Umniah_E_Sport.Application.Features.CasualCategories.Commands.CreateCasualCategory;
using Umniah_E_Sport.Application.Features.CasualCategories.Commands.UpdateCasualCategory;
using Umniah_E_Sport.Application.Features.CasualGames.Queries.GetAllCasualGames;
using Umniah_E_Sport.Application.Features.CasualGames.Queries.GetCasualGameById;
using Umniah_E_Sport.Application.Features.CasualGames.Queries.GetCasualGamesByCategoryId;
using Umniah_E_Sport.Application.Features.CasualGames.Queries.GetFeaturedCasualGames;
using Umniah_E_Sport.Application.Features.CasualGames.Commands.CreateCasualGame;
using Umniah_E_Sport.Application.Features.CasualGames.Commands.UpdateCasualGame;
using Umniah_E_Sport.Application.Features.CasualGameImages.Commands.CreateCasualGameImage;
using Umniah_E_Sport.Application.Features.CasualGameImages.Commands.DeleteCasualGameImage;
using Umniah_E_Sport.Application.Features.CasualGameImages.Commands.UpdateCasualGameImage;
using Umniah_E_Sport.Application.Features.CasualGames.Queries;
using Umniah_E_Sport.Application.Features.CasualCategories.Queries.GetCasualCategory;
using Umniah_E_Sport.Application.Features.Users.Queries.SendSMSContent;
using Umniah_E_Sport.Domain.DTOs.SubscribtionFlowAPI;
using Umniah_E_Sport.Domain.DTOs.SubscribtionAPI;

namespace Umniah_E_Sport.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Arena
            CreateMap<Arena, ArenaCardVM>()
                .ForMember(c => c.NumberOfTournaments, opt => opt.MapFrom(s => s.Tournaments.Count))
                .ReverseMap();

            CreateMap<Arena, GetArenaVM>()
                .ForMember(c => c.NumberOfTournaments, opt => opt.MapFrom(s => s.Tournaments.Count))
                .ReverseMap();

            CreateMap<CreateArenaCommand, Arena>().ReverseMap();

            CreateMap<UpdateArenaCommand, Arena>().ReverseMap();
            #endregion

            #region Game
            CreateMap<Game, GetAllGamesVM>().ReverseMap();
            CreateMap<Game, GetTrendingGamesVM>().ReverseMap();
            //CreateMap<Game, GetUserGamesByUserIdVm>()
            //    .ForMember(d => d.Title_AR, opt => opt.MapFrom(s => s.Title_AR))
            //    .ForMember(d => d.ti, opt => opt.MapFrom(s => s.Title_EN))
            //    .ReverseMap();
            CreateMap<AddGameCommand, Game>()
                .ForPath(d => d.TermsAndConditions.CreationTimeStamp, opt => opt.MapFrom(s => DateTime.Now))
                .ReverseMap();
            CreateMap<UpdateGameCommand, Game>()
                .ForPath(d => d.TermsAndConditions.Content_AR, opt => opt.MapFrom(s => s.TermsAndConditionsContent_AR))
                .ForPath(d => d.TermsAndConditions.Content_EN, opt => opt.MapFrom(s => s.TermsAndConditionsContent_EN))
                .ForPath(d => d.TermsAndConditions.EndTimeStamp, opt => opt.MapFrom(s => s.TermsAndConditionsEndTimeStamp))
                .ReverseMap();
            CreateMap<Game, GetGameVM>()
                .ForMember(d => d.TermsAndConditionsContent_AR, opt => opt.MapFrom(s => s.TermsAndConditions.Content_AR))
                .ForMember(d => d.TermsAndConditionsContent_EN, opt => opt.MapFrom(s => s.TermsAndConditions.Content_EN))
                .ReverseMap();
            #endregion

            #region Video
            CreateMap<Video, GetAllVideosVm>().ReverseMap();
            CreateMap<Video, GetVideoByIdVm>().ReverseMap();
            CreateMap<Video, GetRelatedVideosVm>().ReverseMap();
            CreateMap<Video, GetLatestVideosVm>().ReverseMap();
            CreateMap<Video, GetVideosByGameVm>().ReverseMap();
            CreateMap<AddVideoToGameCommand, Video>()
                .ForMember(dest => dest.CreationTimeStamp, options => options.MapFrom(src => DateTime.Now))
                .ReverseMap();
            CreateMap<UpdateVideoByIdCommand, Video>().ReverseMap();
            #endregion

            #region News

            CreateMap<NewsEntity, NewsCardVM>()
                .ReverseMap();
            CreateMap<NewsEntity, NewsCardDetailVM>()
                .ReverseMap();
            CreateMap<NewsEntity, RelatedNewsCardVM>()
                .ReverseMap();
            CreateMap<NewsEntity, LatestNewsCardVM>()
                .ReverseMap();
            CreateMap<CreateNewsCommand, NewsEntity>().ReverseMap();
            CreateMap<UpdateNewsCommand, NewsEntity>().ReverseMap();
            #endregion

            #region Users

            CreateMap<ResponseGenOTP, ValidateOTPQueryReponse>()
                .ForMember(c => c.Success, s => s.MapFrom(c => c.status.Equals("0")))
                .ForMember(d => d.Message, s => s.MapFrom(d => d.resdescription))
                //.ForMember(d => d.otpId, s => s.MapFrom(d => d.otpid))
                .ReverseMap();
            CreateMap<BaseResponse, ValidateOTPQueryReponse>()
                .ReverseMap();
            CreateMap<ResponseSubService, SubscribeUserCommandResponse>()
                .ForMember(c => c.Success, s => s.MapFrom(c => c.status.Equals("0")))
                .ForMember(d => d.Message, s => s.MapFrom(d => d.resdescription))
                .ReverseMap();

            CreateMap<ResponseSubService, UnsubscribeUserCommandResponse>()
                .ForMember(c => c.Success, s => s.MapFrom(c => c.status.Equals("0")))
                .ForMember(d => d.Message, s => s.MapFrom(d => d.resdescription))
                .ReverseMap();
            CreateMap<BaseResponse, UnsubscribeUserCommandResponse>()
                .ReverseMap();

            CreateMap<UserGames, UserProfileGameScoreVM>()
                .ForMember(d => d.GameTitle_EN, opt => opt.MapFrom(s => s.Game.Title_EN))
                .ForMember(d => d.GameTitle_AR, opt => opt.MapFrom(s => s.Game.Title_AR))
                .ForMember(d => d.GameImageName, opt => opt.MapFrom(s => s.Game.ImageName))
                .ForMember(d => d.Score, opt => opt.MapFrom(s => s.UserScore))
                .ReverseMap();

            CreateMap<User, GetLeaderBoardVM>()
                .ForMember(c => c.Achievements, opt => opt.MapFrom(c => c.Achievements));

            CreateMap<Game, MyLeaderBoardVM>().ReverseMap();
            CreateMap<LeaderBoardRankDTO, LeaderBoardRankVM>().ReverseMap();

            CreateMap<User, GetUserProfileVM>().ReverseMap();

            CreateMap<User, GetUserMailProfileVM>().ReverseMap();

            CreateMap<User, GetAllUsersOrderedByScoreVm>().ReverseMap();
            CreateMap<User, GetUsersWithKeywordOrderedByScoreVm>().ReverseMap();
            CreateMap<SendSMSQueryResponse, BaseResponse>().ReverseMap();
            CreateMap<SendSMSContentResponse, BaseResponse>().ReverseMap();

            #endregion

            #region Tournament Type
            CreateMap<TournamentType, GetAllTournamentTypesVM>().ReverseMap();
            CreateMap<CreateTournamentTypeCommand, TournamentType>().ReverseMap();
            CreateMap<UpdateTournamentTypeCommand, TournamentType>().ReverseMap();
            CreateMap<GetTournamentTypeByIdVm, TournamentType>().ReverseMap();
            #endregion

            #region Tournaments
            CreateMap<Tournament, GetAllTournamentsVM>()
                .ForMember(d => d.TournamentTypeText_AR, opt => opt.MapFrom(s => s.TournamentType.Text_AR))
                .ForMember(d => d.TournamentTypeText_EN, opt => opt.MapFrom(s => s.TournamentType.Text_EN))
                .ForMember(d => d.LocationText_EN, opt => opt.MapFrom(s => s.Location.Text_EN))
                .ForMember(d => d.LocationText_AR, opt => opt.MapFrom(s => s.Location.Text_AR))
                .ForMember(d => d.Status, opt => opt.MapFrom(s =>
                (s.StartDate > DateTime.Now) ? TournamentStatus.Upcoming :
                ((s.StartDate < DateTime.Now && s.EndDate > DateTime.Now) ? TournamentStatus.Live : TournamentStatus.Finished)))
                .ForMember(d => d.RegisterationStatus, opt => opt.MapFrom(s =>
                (s.RegisterationStartDate < DateTime.Now && s.RegisterationEndDate > DateTime.Now) ? RegisterationStatus.Open : RegisterationStatus.Close))
                 .ReverseMap();

            CreateMap<Tournament, GetFeaturedTournamentsVM>()
                .ForMember(d => d.TournamentTypeText_AR, opt => opt.MapFrom(s => s.TournamentType.Text_AR))
                .ForMember(d => d.TournamentTypeText_EN, opt => opt.MapFrom(s => s.TournamentType.Text_EN))
                .ForMember(d => d.LocationText_EN, opt => opt.MapFrom(s => s.Location.Text_EN))
                .ForMember(d => d.LocationText_AR, opt => opt.MapFrom(s => s.Location.Text_AR))
                .ForMember(d => d.Status, opt => opt.MapFrom(s =>
                (s.StartDate > DateTime.Now) ? TournamentStatus.Upcoming :
                ((s.StartDate < DateTime.Now && s.EndDate > DateTime.Now) ? TournamentStatus.Live : TournamentStatus.Finished)))
                .ForMember(d => d.RegisterationStatus, opt => opt.MapFrom(s =>
                (s.RegisterationStartDate < DateTime.Now && s.RegisterationEndDate > DateTime.Now) ? RegisterationStatus.Open : RegisterationStatus.Close))
                 .ReverseMap();

            CreateMap<Tournament, GetUpcomingTournamentsVM>()
                .ForMember(d => d.TimeStamp, opt => opt.MapFrom(s => new DateTimeOffset(s.StartDate.ToUniversalTime()).ToUnixTimeSeconds()))
                .ForMember(d => d.TournamentTypeText_AR, opt => opt.MapFrom(s => s.TournamentType.Text_AR))
                .ForMember(d => d.TournamentTypeText_EN, opt => opt.MapFrom(s => s.TournamentType.Text_EN))
                .ForMember(d => d.LocationText_EN, opt => opt.MapFrom(s => s.Location.Text_EN))
                .ForMember(d => d.LocationText_AR, opt => opt.MapFrom(s => s.Location.Text_AR))
                .ForMember(d => d.NumberOfMillisecond, opt => opt.MapFrom(s => s.StartDate.Subtract(DateTime.UnixEpoch).TotalMilliseconds / 1000))
                .ReverseMap();

            CreateMap<Tournament, GetLiveTournamentsVM>()
                .ForMember(d => d.TournamentTypeText_AR, opt => opt.MapFrom(s => s.TournamentType.Text_AR))
                .ForMember(d => d.TournamentTypeText_EN, opt => opt.MapFrom(s => s.TournamentType.Text_EN))
                .ForMember(d => d.LocationText_EN, opt => opt.MapFrom(s => s.Location.Text_EN))
                .ForMember(d => d.LocationText_AR, opt => opt.MapFrom(s => s.Location.Text_AR))
                .ForMember(d => d.Status, opt => opt.MapFrom(s => TournamentStatus.Live))
                .ForMember(d => d.RegisterationStatus, opt => opt.MapFrom(s => RegisterationStatus.Close))
                 .ForMember(d => d.NumberOfMillisecond, opt => opt.MapFrom(s => s.StartDate.Subtract(DateTime.UnixEpoch).TotalMilliseconds / 1000))
                .ReverseMap();

            CreateMap<Tournament, GetFinishedTournamentsVM>()
                .ForMember(d => d.TournamentTypeText_AR, opt => opt.MapFrom(s => s.TournamentType.Text_AR))
                .ForMember(d => d.TournamentTypeText_EN, opt => opt.MapFrom(s => s.TournamentType.Text_EN))
                .ForMember(d => d.LocationText_EN, opt => opt.MapFrom(s => s.Location.Text_EN))
                .ForMember(d => d.LocationText_AR, opt => opt.MapFrom(s => s.Location.Text_AR))
                .ForMember(d => d.Status, opt => opt.MapFrom(s => TournamentStatus.Finished))
                .ForMember(d => d.RegisterationStatus, opt => opt.MapFrom(s => RegisterationStatus.Close))
                .ForMember(d => d.NumberOfMillisecond, opt => opt.MapFrom(s => s.StartDate.Subtract(DateTime.UnixEpoch).TotalMilliseconds / 1000))
                .ReverseMap();

            CreateMap<Tournament, GetFinishedTournamentsByArenaIdVM>()
                .ForMember(d => d.NumberOfMillisecond, opt => opt.MapFrom(s => s.StartDate.Subtract(DateTime.UnixEpoch).TotalMilliseconds / 1000))
               .ForMember(d => d.TournamentTypeText_AR, opt => opt.MapFrom(s => s.TournamentType.Text_AR))
                .ForMember(d => d.TournamentTypeText_EN, opt => opt.MapFrom(s => s.TournamentType.Text_EN))
                .ForMember(d => d.LocationText_EN, opt => opt.MapFrom(s => s.Location.Text_EN))
                .ForMember(d => d.LocationText_AR, opt => opt.MapFrom(s => s.Location.Text_AR))
                .ForMember(d => d.Status, opt => opt.MapFrom(s => TournamentStatus.Finished))
                .ForMember(d => d.RegisterationStatus, opt => opt.MapFrom(s => RegisterationStatus.Close))
                .ReverseMap();

            CreateMap<Tournament, GetLiveTournamentsByArenaIdVM>()
                .ForMember(d => d.NumberOfMillisecond, opt => opt.MapFrom(s => s.StartDate.Subtract(DateTime.UnixEpoch).TotalMilliseconds / 1000))
                .ForMember(d => d.TournamentTypeText_AR, opt => opt.MapFrom(s => s.TournamentType.Text_AR))
                .ForMember(d => d.TournamentTypeText_EN, opt => opt.MapFrom(s => s.TournamentType.Text_EN))
                .ForMember(d => d.LocationText_EN, opt => opt.MapFrom(s => s.Location.Text_EN))
                .ForMember(d => d.LocationText_AR, opt => opt.MapFrom(s => s.Location.Text_AR))
                .ForMember(d => d.Status, opt => opt.MapFrom(s => TournamentStatus.Live))
                .ForMember(d => d.RegisterationStatus, opt => opt.MapFrom(s => RegisterationStatus.Close))
                .ReverseMap();

            CreateMap<Tournament, GetUpcomingTournamentsByArenaIdVM>()
                .ForMember(d => d.NumberOfMillisecond, opt => opt.MapFrom(s => s.StartDate.Subtract(DateTime.UnixEpoch).TotalMilliseconds / 1000))
                .ForMember(d => d.TournamentTypeText_AR, opt => opt.MapFrom(s => s.TournamentType.Text_AR))
                .ForMember(d => d.TournamentTypeText_EN, opt => opt.MapFrom(s => s.TournamentType.Text_EN))
                .ForMember(d => d.LocationText_EN, opt => opt.MapFrom(s => s.Location.Text_EN))
                .ForMember(d => d.LocationText_AR, opt => opt.MapFrom(s => s.Location.Text_AR))
                .ForMember(d => d.Status, opt => opt.MapFrom(s => TournamentStatus.Upcoming))
                .ForMember(d => d.RegisterationStatus, opt => opt.MapFrom(s =>
                (s.RegisterationStartDate < DateTime.Now && s.RegisterationEndDate > DateTime.Now) ? RegisterationStatus.Open : RegisterationStatus.Close))
                 .ReverseMap();

            CreateMap<Tournament, GetTournamentsByGameIdVM>()
                .ForMember(d => d.LocationText_EN, opt => opt.MapFrom(s => s.Location.Text_EN))
                .ForMember(d => d.LocationText_AR, opt => opt.MapFrom(s => s.Location.Text_AR))
                .ForMember(d => d.TournamentTypeText_EN, opt => opt.MapFrom(s => s.TournamentType.Text_EN))
                .ForMember(d => d.TournamentTypeText_AR, opt => opt.MapFrom(s => s.TournamentType.Text_AR))
                .ForMember(d => d.Status, opt => opt.MapFrom(s =>
                (s.StartDate > DateTime.Now) ? TournamentStatus.Upcoming :
                ((s.StartDate < DateTime.Now && s.EndDate > DateTime.Now) ? TournamentStatus.Live : TournamentStatus.Finished)))
                .ForMember(d => d.RegisterationStatus, opt => opt.MapFrom(s =>
                (s.RegisterationStartDate < DateTime.Now && s.RegisterationEndDate > DateTime.Now) ? RegisterationStatus.Open : RegisterationStatus.Close))
                  .ForMember(d => d.NumberOfMillisecond, opt => opt.MapFrom(s => s.StartDate.Subtract(DateTime.UnixEpoch).TotalMilliseconds / 1000))
                  .ReverseMap();

            CreateMap<UserTournaments, GetTournamentLeaderboardVM>()
                .ReverseMap();

            CreateMap<Tournament, GetTournamentVM>()
                .ForMember(d => d.TournamentTypeText_AR, opt => opt.MapFrom(s => s.TournamentType.Text_AR))
                .ForMember(d => d.TournamentTypeText_EN, opt => opt.MapFrom(s => s.TournamentType.Text_EN))
                .ForMember(d => d.LocationText_EN, opt => opt.MapFrom(s => s.Location.Text_EN))
                .ForMember(d => d.LocationText_AR, opt => opt.MapFrom(s => s.Location.Text_AR))
                .ForMember(d => d.Status, opt => opt.MapFrom(s =>
                (s.StartDate > DateTime.Now) ? TournamentStatus.Upcoming :
                ((s.StartDate < DateTime.Now && s.EndDate > DateTime.Now) ? TournamentStatus.Live : TournamentStatus.Finished)))
                .ForMember(d => d.RegisterationStatus, opt => opt.MapFrom(s =>
                (s.RegisterationStartDate < DateTime.Now && s.RegisterationEndDate > DateTime.Now) ? RegisterationStatus.Open : RegisterationStatus.Close))
                 .ForMember(d => d.NumberOfMillisecond, opt => opt.MapFrom(s => s.StartDate.Subtract(DateTime.UnixEpoch).TotalMilliseconds / 1000))
            .ReverseMap();

            CreateMap<Tournament, UserProfileTournamentsVM>()
               .ForMember(d => d.TimeStamp, opt => opt.MapFrom(s => new DateTimeOffset(s.StartDate.ToUniversalTime()).ToUnixTimeSeconds()))
               .ReverseMap();
            CreateMap<Tournament, GetTournamentsByUserIdVm>().ReverseMap();
            CreateMap<CreateTournamentCommand, Tournament>()
                .ForMember(d => d.DurationTimeSpan, opt => opt.MapFrom(s => TimeSpan.Parse(s.DurationTimeSpan)))
                .ReverseMap();

            CreateMap<UpdateTournamentCommand, Tournament>()
                .ForMember(d => d.DurationTimeSpan, opt => opt.MapFrom(s => TimeSpan.Parse(s.DurationTimeSpan)))
                .ReverseMap();

            #endregion

            #region Terms And Conditions
            CreateMap<TermsAndConditions, GetTermsAndConditionsByTournamentVM>()
                .ReverseMap();
            CreateMap<TermsAndConditions, AddGameCommand>()
                .ReverseMap();
            #endregion

            #region Achievement
            CreateMap<Achievement, GetUserAchievementsVm>()
                .ReverseMap();
            CreateMap<Achievement, GetAchievementByIdVm>()
                .ReverseMap();
            CreateMap<Achievement, AddAchievementToUserCommand>()
                .ReverseMap();
            CreateMap<Achievement, GetUserAchievementsByUserIdVm>()
                .ReverseMap();
            CreateMap<Achievement, UpdateUserAchievementCommand>()
                .ReverseMap();
            CreateMap<Achievement, UserProfileAchievmentsVM>()
                .ReverseMap();
            #endregion

            #region Location
            CreateMap<Location, GetAllLocationsVM>().ReverseMap();
            CreateMap<CreateLocationCommand, Location>().ReverseMap();
            CreateMap<UpdateLocationCommand, Location>().ReverseMap();
            CreateMap<GetLocationByIdVm, Location>().ReverseMap();

            #endregion

            #region UserGame
            CreateMap<UserGames, GetUsersByGameVM>().ReverseMap();
            CreateMap<UserGames, GetUsersGamesVM>().ReverseMap();
            CreateMap<UserGames, GetUserGamesByUserIdVm>()
                .ForMember(d => d.Title_AR, opt => opt.MapFrom(s => s.Game.Title_AR))
                .ForMember(d => d.Title_EN, opt => opt.MapFrom(s => s.Game.Title_EN))
                .ReverseMap();
            #endregion

            #region Casual Category
            CreateMap<CasualCategory, GetAllCasualCategoriesVm>().ReverseMap();
            CreateMap<CasualCategory, CreateCasualCategoryCommand>().ReverseMap();
            CreateMap<CasualCategory, UpdateCasualCategoryCommand>().ReverseMap();
            CreateMap<CasualCategory, GetCasualCategoryVm>().ReverseMap();
            #endregion

            #region
            CreateMap<CasualGame, GetAllCasualGamesVm>()
                .ForMember(d => d.CasualCategoryId, opt => opt.MapFrom(s => s.CasualCategoryId))
                .ForMember(d => d.CasualCategoryName_EN, opt => opt.MapFrom(s => s.CasualCategory.Name_EN))
                .ForMember(d => d.CasualCategoryName_AR, opt => opt.MapFrom(s => s.CasualCategory.Name_AR))
                .ForMember(d => d.CasualCategoryImageName, opt => opt.MapFrom(s => s.CasualCategory.ImageName))
                .ForMember(d => d.CasualGameImagesVm, opt => opt.MapFrom(s => s.CasualGameImages))
                .ReverseMap();
            CreateMap<CasualGame, GetCasualGameByIdVm>()
                .ForMember(d => d.CasualCategoryId, opt => opt.MapFrom(s => s.CasualCategoryId))
                .ForMember(d => d.CasualCategoryName_EN, opt => opt.MapFrom(s => s.CasualCategory.Name_EN))
                .ForMember(d => d.CasualCategoryName_AR, opt => opt.MapFrom(s => s.CasualCategory.Name_AR))
                .ForMember(d => d.CasualCategoryImageName, opt => opt.MapFrom(s => s.CasualCategory.ImageName))
                .ForMember(d => d.CasualGameImagesVm, opt => opt.MapFrom(s => s.CasualGameImages))
                .ReverseMap();
            CreateMap<CasualGame, GetCasualGamesByCategoryIdVm>()
                .ForMember(d => d.CasualCategoryId, opt => opt.MapFrom(s => s.CasualCategoryId))
                .ForMember(d => d.CasualCategoryName_EN, opt => opt.MapFrom(s => s.CasualCategory.Name_EN))
                .ForMember(d => d.CasualCategoryName_AR, opt => opt.MapFrom(s => s.CasualCategory.Name_AR))
                .ForMember(d => d.CasualCategoryImageName, opt => opt.MapFrom(s => s.CasualCategory.ImageName))
                .ForMember(d => d.CasualGameImagesVm, opt => opt.MapFrom(s => s.CasualGameImages))
                .ReverseMap();
            CreateMap<CasualGame, GetFeaturedCasualGamesVm>()
                .ForMember(d => d.CasualCategoryId, opt => opt.MapFrom(s => s.CasualCategoryId))
                .ForMember(d => d.CasualCategoryName_EN, opt => opt.MapFrom(s => s.CasualCategory.Name_EN))
                .ForMember(d => d.CasualCategoryName_AR, opt => opt.MapFrom(s => s.CasualCategory.Name_AR))
                .ForMember(d => d.CasualCategoryImageName, opt => opt.MapFrom(s => s.CasualCategory.ImageName))
                .ForMember(d => d.CasualGameImagesVm, opt => opt.MapFrom(s => s.CasualGameImages))
                .ReverseMap();
            CreateMap<CasualGame, CreateCasualGameCommand>().ReverseMap();
            CreateMap<CasualGame, UpdateCasualGameCommand>().ReverseMap();

            #endregion

            #region Casual Game Image
            CreateMap<CasualGameImage, CreateCasualGameImageCommand>().ReverseMap();
            CreateMap<CasualGameImage, DeleteCasualGameImageCommand>().ReverseMap();
            CreateMap<CasualGameImage, UpdateCasualGameImageCommand>().ReverseMap();
            CreateMap<CasualGameImage, CasualGameImageVm>().ReverseMap();
            #endregion
            #region
            CreateMap<Badge, GetAllBadgesVm>().ReverseMap();
            #endregion
        }
    }
}

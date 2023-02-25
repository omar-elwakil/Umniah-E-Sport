using Umniah_E_Sport.Application.Contracts.Persistence;
using Umniah_E_Sport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Umniah_E_Sport.Persistence.Repos
{
    public class VideoRepo : BaseManager<Video>, IVideoManager
    {
        public VideoRepo(UmniahContext context) : base(context)
        {
        }

        public IEnumerable<Video> GetLatestVideos(int videoCount)
        {
            return _context.Videos.AsQueryable().OrderByDescending(v=>v.TimeStamp).Take(videoCount);
        }

        public IEnumerable<Video> GetRelatedVideos(int videoId)
        {
            var video = _context.Videos.AsQueryable().FirstOrDefault(e => e.Id == videoId);
            if (video == null)
            {
                return new List<Video>();
            }
            return _context.Videos.AsQueryable()
                .Where(e => e.GameId == video.GameId && e.Id != videoId)
                .Take(4);
        }

        public IEnumerable<Video> GetVideosByGame(int gameId)
        {
            return _context.Videos.AsQueryable().Where(e => e.GameId == gameId);
        }
    }
}

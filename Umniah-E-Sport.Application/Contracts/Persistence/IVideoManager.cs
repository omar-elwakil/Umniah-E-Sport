using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umniah_E_Sport.Domain.Entities;

namespace Umniah_E_Sport.Application.Contracts.Persistence
{
    public interface IVideoManager : IAsyncManager<Video>
    {
        public IEnumerable<Video> GetRelatedVideos(int videoId);
        public IEnumerable<Video> GetVideosByGame(int gameId);
        public IEnumerable<Video> GetLatestVideos(int videoCount);
    }
}

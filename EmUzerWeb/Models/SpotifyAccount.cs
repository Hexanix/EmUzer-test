using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Newtonsoft.Json.Linq;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using System.Threading.Tasks;

namespace EmUzerWeb.Models
{
    public class SpotifyAccount
    {
        private static SpotifyWebAPI _spotify;

        

        public int UserID { get; set; }

        public string AccessToken { get; set; }

        public string Username { get; set; }

        public string ModelError { get; set; }

        public string currentEmotion { get; set; }


        public List<SavedTrack> savedTracks { get; set; }

        public List<FullTrack> outputPlaylst { get; set; }



        public async Task<SpotifyWebAPI> ConnectToSpotifyAsync(SpotifyWebAPI _spotify)
        {
            WebAPIFactory webApiFactory = new WebAPIFactory(
                "http://localhost",
                 44333,
                "509976e01ef2432c9135a8dd26085d9d",
                Scope.PlaylistModifyPrivate | Scope.PlaylistModifyPublic | Scope.Streaming | Scope.UserFollowModify |
                Scope.UserFollowRead | Scope.UserLibraryRead | Scope.UserReadPrivate | Scope.UserTopRead,
                TimeSpan.FromSeconds(20));

            try
            {
                //This will open the user's browser and returns once
                //the user is authorized.
                _spotify = await webApiFactory.GetWebApi();
            }
            catch (Exception ex)
            {
                ModelError = ex.Message;
            }

            if (_spotify == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                return await Task.FromResult<SpotifyWebAPI>(_spotify);
            }
        }

        public async void SetAccountProperties()
        {
            var AuthResult = await ConnectToSpotifyAsync(_spotify);
            this.AccessToken = AuthResult.AccessToken;
        }

    }
}
using System.Web.Mvc;
using System.Web;
using EmUzerWeb.Models;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;

namespace EmUzerWeb.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        
        private static SpotifyWebAPI _spotify = new SpotifyWebAPI();
        SpotifyAccount user = new SpotifyAccount();


        public ActionResult Index()
        {
            
            
            user.SetAccountProperties();
            user.ConnectToSpotifyAsync(_spotify);
            return View(user);
        }

        public ActionResult Scanner()
        {

            foreach (var item in _spotify.GetSavedTracks().Items)
            {
                user.outputPlaylst.Add(item.Track);
            }



            return View(user);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }





    }
}
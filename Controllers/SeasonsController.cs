using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClickomyOMDbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonsController : ControllerBase
    {
       
        [HttpGet]
        public String Get(String SeriesTitle, String SeriesSeason)
        {
            string apiKey = "50310e5a";
            string baseUri = $"https://www.omdbapi.com/?apikey={apiKey}&t={SeriesTitle}&Season={SeriesSeason}";

            var request = HttpWebRequest.Create(baseUri);
            request.Timeout = 1000;
            request.Method = "GET";
            request.ContentType = "application/json";

            string result = string.Empty;

            try
            {
                using (var response =  request.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            result = reader.ReadToEnd();
                        }
                        stream.Close();
                    }
                }
            }
            catch (WebException e)
            {
                Console.WriteLine(e);
                return e.Message;
            }
            List<Episode> episodes = new List<Episode>();

            var jobject = JObject.Parse(result);
            var episodes_list = jobject["Episodes"];
          
            String episodes_string = "[";

            foreach (var item in episodes_list)
            {
                episodes_string += "{";
                String title = item["Title"].Value<String>();
                String released = item["Released"].Value<String>();
                String rating = item["imdbRating"].Value<String>();
                String episode_num = item["Episode"].Value<String>();
              
                episodes_string += title + "," + released + "," + episode_num + "," + rating + "}_";
            }
            episodes_string = episodes_string.Remove(episodes_string.Length-1) + "]";
          
            return episodes_string;
        }
    }
}
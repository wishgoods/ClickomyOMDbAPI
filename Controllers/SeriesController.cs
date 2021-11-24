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
    public class SeriesController : ControllerBase
    {
       
        [HttpGet]
        public String Get(String SeriesTitle)
        {
            string apiKey = "50310e5a";
            string baseUri = $"https://www.omdbapi.com/?apikey={apiKey}&t={SeriesTitle}";

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
            var jobject = JObject.Parse(result);
            String title = jobject["Title"].Value<String>();
            String year = jobject["Year"].Value<String>();
            String rating = jobject["imdbRating"].Value<String>();
            String req_type = jobject["Type"].Value<String>();
            String total_seasons = jobject["totalSeasons"].Value<String>();
            Series series = new Series(title,year, rating, req_type, total_seasons);

            return series.getResponseString();

        }
    }
}
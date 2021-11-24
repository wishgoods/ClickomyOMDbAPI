using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClickomyOMDbAPI
{
    public class Episode
    {
        private String title { get;set;}
        private String released { get; set; }
        private String episode { get; set; }
        private String rating { get; set; }

        public Episode(String title, String released,  String episode, String rating) {
            this.title = title;
            this.released = released;
            this.rating = rating;
            this.episode = episode;
        }

        internal string getResponseString()
        {
            return this.title+","+this.released+","+this.rating+","+this.episode;
        }
    }
}

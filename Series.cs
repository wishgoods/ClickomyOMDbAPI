using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClickomyOMDbAPI
{
    public class Series
    {
        private String title { get;set;}
        private String year { get; set; }
        private String rating { get; set; }
        private String req_type { get; set; }
        private String totalSeasons { get; set; }

        public Series(String title, String year, String rating, String req_type, String total_seasons) {
            this.title = title;
            this.year = year;
            this.rating = rating;
            this.req_type = req_type;
            this.totalSeasons = total_seasons;
        }

        internal string getResponseString()
        {
            return "{"+this.title+","+this.year+","+this.rating+","+this.req_type+","+this.totalSeasons+"}";
        }
    }
}

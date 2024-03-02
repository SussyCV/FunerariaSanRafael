using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunerariaSanRafael.Models.DTO
{
    public class dataC
    {
        public int id { get; set; }
        public int? cat_id { get; set; }
        public int? cc_id { get; set; }
        public int? ent_id { get; set; }
        public object? agencyid { get; set; }
        public object? agentid { get; set; }
        public int? paxn { get; set; }
        public int? adults { get; set; }
        public int? infants { get; set; }
        public int? children { get; set; }
        public string? chd_ages { get; set; }
        public string name { get; set; }
        public string? id_type { get; set; }
        public string idnum { get; set; }
        public string email { get; set; }
        public string? country_code { get; set; }
        public string paxphone { get; set; }
        public string? numfin { get; set; }
        public string? numfout { get; set; }
        public string datein { get; set; }
        public string? dateout { get; set; }
        public string requested { get; set; }
        public int? owner { get; set; }
        public string? crdate { get; set; }
        public int? cnt_id_from { get; set; }
        public int? cnt_id_to { get; set; }
        public int? cobrand { get; set; }
        public int? from_website { get; set; }
        public string amount_avail { get; set; }
    }

    public class ResponseGetClients
    {
        public object error { get; set; }
        public List<dataC> data { get; set; }
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunerariaSanRafael.Models.DTO
{
    
    public class data
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public int bnk_id { get; set; }
        public int curr_id { get; set; }
        public string curr_type { get; set; }
        public int type { get; set; }
        public int debit { get; set; }
        public int active { get; set; }
        public int prnt_acc_id { get; set; }
        public string desc { get; set; }
    }

    public class ResponseGetAccounts
    {
        public object error { get; set; }
        public List<data> data { get; set; }
    }
}

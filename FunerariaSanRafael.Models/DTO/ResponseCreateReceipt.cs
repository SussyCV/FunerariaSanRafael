using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunerariaSanRafael.Models.DTO
{
    public class Aporte
    {
        public decimal monto { get; set; }
        public int id_cuenta_banco { get; set; }
    }

    public class Otro
    {
        public decimal monto { get; set; }
        public string id_referencia { get; set; } 
        public string referencia { get; set; }
        public int id_cuenta { get; set; }
    }

    public class ResponseCreateReceipt
    {
        public string mod { get; set; }
        public string fn { get; set; }
        public string dbName { get; set; }
        public int file_id { get; set; }
        public string id_referencia { get; set; }
        public string fecha { get; set; }
        public List<Aporte> aporte { get; set; }
        public List<Otro> otros { get; set; }
    }
}


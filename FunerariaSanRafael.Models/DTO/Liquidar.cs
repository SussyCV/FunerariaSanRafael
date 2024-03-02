using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunerariaSanRafael.Models.DTO
{
    public class Liquidar
    {
        public int file_id { get; set; }
        public string id_referencia { get; set; }
        public string fecha { get; set; }
        public decimal aporte { get; set; }
        public List<aporte>? aportes { get; set; }
        public List<otro>? otros { get; set; }

    }

    public class aporte
    {
        public decimal monto { get; set; }
        public int id_cuenta_banco { get; set; }
    }

    public class otro
    {
        public decimal monto2 { get; set; }
        public string id_referencia2 { get; set; }
        public string referencia { get; set; }
        public int id_cuenta { get; set; }
    }
}

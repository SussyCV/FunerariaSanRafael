using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FunerariaSanRafael.Models
{
    public class mst_Servicio
    {
        [Key]
        public int idServicio { get; set; }
        public string? serv_desc { get; set; }
        public decimal serv_costo { get; set; }
        public string? serv_tipo { get; set; }
        public string? serv_tipo_costo { get; set; }
        public string? serv_cuenta_contable { get; set; }
        public char serv_status { get; set; }
        public DateTime? createdAt { get; set; }
        public string? createdBy { get; set; }
        public DateTime? updatedAt { get; set; }
        public string? updatedBy { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace FunerariaSanRafael.Models
{
    public class mst_MetodoPago
    {
        [Key]
        public int idMetodoPago { get; set; }
        public string? mpa_descripcion { get; set; }
        public string? mpa_cuenta_contable { get; set; }
        public char mpa_status { get; set; }
        public DateTime createdAt { get; set; }
        public string? createdBy { get; set; }
        public DateTime? updatedAt { get; set; }
        public string? updatedBy { get; set; }

    }
}

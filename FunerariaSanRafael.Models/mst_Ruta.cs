using System.ComponentModel.DataAnnotations;

namespace FunerariaSanRafael.Models
{
    public class mst_Ruta
    {
        [Key]
        public int idRuta { get; set; }
        public string? ruta_nombre { get; set; }
        public string? ruta_Telefono { get; set; }
        public DateTime createdAt { get; set; }
        public string? createdBy { get; set; }
        public DateTime? updatedAt { get; set; }
        public string? updatedBy { get; set; }
    }
}

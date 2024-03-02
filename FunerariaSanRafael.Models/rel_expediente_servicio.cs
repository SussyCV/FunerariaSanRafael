using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FunerariaSanRafael.Models
{
    public class rel_expediente_servicio
    {

        [Key]
        public int id_expediente_servicio { get; set; }
        public int cod_expediente { get; set; }
        public int idServicio { get; set; }
        public DateTime createdAt { get; set; }
        public string? createdBy { get; set; }
        public string? rel_es_status { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FunerariaSanRafael.Models
{
    public class mst_Recibo
    {
        
        public int cod_expediente { get; set; }
        public DateTime rec_fechaPago { get; set; }
        public string? rec_status { get; set; }
        public decimal rec_aporte_anterior { get; set; }
        public decimal rec_monto { get; set; }
        public decimal? rec_deducciones { get; set; }
        public int rec_periodo { get; set; }
        public DateTime createdAt { get; set; }
        public string? createdBy { get; set; }
        public DateTime updatedAt { get; set; }
        public string? updatedBy { get; set; }
        public int idRuta { get; set; }
        [Key]
        public int numRecibo { get; set; }
        public DateTime? rec_fechaLiquidacion { get; set; }
        public decimal? rec_monto_minimo { get; set; }
        [NotMapped]
        public bool Selec { get; set; }

    }
}

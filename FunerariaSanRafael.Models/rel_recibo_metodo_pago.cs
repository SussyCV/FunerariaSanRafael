using System.ComponentModel.DataAnnotations;
namespace FunerariaSanRafael.Models

{
    public class rel_recibo_metodo_pago
    {
        public int cod_expediente { get; set; }
        public int rec_periodo { get; set; }
        public decimal? mpa_monto_recibido { get; set; }
        public int idMetodoPago { get; set; }
        public DateTime? createdAt { get; set; }
        public string? createdBy { get; set; }
        public DateTime? updatedAt { get; set; }
        public string? updatedBy { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace FunerariaSanRafael.Models
{
    public class mst_Expediente
    {
        [Key]
        public int cod_expediente { get; set; }
        public decimal exp_saldo { get; set; }
        public int idRuta { get; set; }
        public char exp_status { get; set; }
        public DateTime createdAt { get; set; }
        public string? createdBy { get; set; }
        public DateTime? updatedAt { get; set; }
        public string? updatedBy { get; set; }
        public string? exp_nombre { get; set; }
        public string? exp_email { get; set; }
        public string? exp_celular { get; set; }
        public string? exp_telefono { get; set; }
        public string? exp_cedula { get; set; }
        public string? exp_provincia { get; set; }
        public DateTime? exp_fec_ini_contrato { get; set; }
        public string? exp_direccion { get; set; }
        public DateTime? exp_fec_utlimo_abono { get; set; }
        public string? exp_categoria { get; set; }
        public string? exp_comentarios { get; set; }
    }
}

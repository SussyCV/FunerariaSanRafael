using System.ComponentModel.DataAnnotations;

namespace FunerariaSanRafael.Models
{
    public class mst_User
    {
        [Key]
        public string? idUser { get; set; }
        public string? user_name { get; set; }
        public string? user_Password { get; set; }
        public DateTime createdAt { get; set; }
        public string? createdBy { get; set; }
        public DateTime updatedAt { get; set; }
        public string? updatedBy { get; set; }

    }
}

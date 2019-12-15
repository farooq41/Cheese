using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheeseModel
{
    public class CheesePicture
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public byte[] Picture { get; set; }

        public int CheeseId { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }
        [NotMapped]
        public string ImageBase64 { get; set; }
    }
}

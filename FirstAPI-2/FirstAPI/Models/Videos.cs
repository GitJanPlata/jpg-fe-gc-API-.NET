using System.ComponentModel.DataAnnotations.Schema;

namespace FirstAPI.Models
{
    [Table("videos")]

    public class Video
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Director { get; set; }
    }

}

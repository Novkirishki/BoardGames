namespace BoardGames.Data.Models
{
    using Common.Models;
    using System.ComponentModel.DataAnnotations;

    public class File : BaseModel<int>
    {
        [StringLength(100)]
        public string ContentType { get; set; }

        public byte[] Content { get; set; }
    }
}

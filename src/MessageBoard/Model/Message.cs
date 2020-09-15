using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;

namespace MessageBoard.Model
{
    public class Message
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Content { get; set; }

        [JsonIgnore]
        public DateTime LastModifiedDate { get; set; }

        [JsonIgnore]
        public string LastModifiedBy { get; set; }
    }
}

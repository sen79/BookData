using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookData.Services.Models
{
    public class Book 
    {
        [Key]
        public int BookId { get; set; }
        [StringLength(250)]
        public string Publisher { get; set; } = "";
        [Remote(action: "VerifyName", controller: "Home", AdditionalFields = "BookId")]
        [StringLength(250)]
        public string Title { get; set; } = "";
        [StringLength(250)]
        public string AuthorFirstName { get; set; } = "";
        [StringLength(250)]
        public string AuthorLastName { get; set; } = ""; 
        [Column(TypeName = "numeric(18, 2)")]
        public decimal Price { get; set; } = decimal.Zero;

    }
}

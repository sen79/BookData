using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BookData.Models
{
    [Keyless]
    public class TotalPrice
    {
        public decimal Value { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}

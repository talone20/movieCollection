using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace movieCollection.Models
{
    public class MovieResponse
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        // Build foreign key relationship
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        // The rest of the table variables
        [Required]
        public string MovieTitle { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool Edited  { get; set; }
        public string LentTo { get; set; }

        [MaxLength(25)]
        public string Notes { get; set; }
    }
}

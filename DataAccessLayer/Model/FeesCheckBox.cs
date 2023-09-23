using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer
{
    public class FeesCheckBox
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string FeesHeader { get; set; }
        [Required]
        public string Fees { get; set; }
        [Required]
        public int paid { get; set; }
        [Required]
        public int balance { get; set; }
        [Required]
        public DateTime ToBePaid { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Payment.Models
{
    public class UserTest
    {
        [Key]
      public int UserTestId { get; set; }
        public string UserTestNamse { get; set; }
        public int Age { get; set; }
        public string Nickname { get; set; }
    }
}

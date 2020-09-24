using System;
using System.ComponentModel.DataAnnotations;

namespace BCX_CORE
{
    public class CommonEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedTS { get; set; }
        public DateTime UpdatedTS { get; set; }
        public bool CANCELLED { get; set; }


    }
}

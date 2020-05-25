using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieStudio.Core
{
    public class Theaters
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string  Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Adress { get; set; }
        public PerformanceType Performance { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.School
{
    public class Trainer
    {
        public int TrainerId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}

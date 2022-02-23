using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace Entities.School
{
    public class Grade
    {
        public int GradeId { get; set; }
        
        
        public string Type { get; set; }

    }
}

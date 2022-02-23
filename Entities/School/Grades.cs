using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace Entities.School
{
    public class Grades
    {

        [Range(0, 100,ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Grade { get; set; }
        
        

    }
}

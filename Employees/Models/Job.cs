using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.Models
{
    public class Job
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Job name is missing")]
        public string JobName { get; set; }


        public  List<EmployeeJob> EmployeeJobs { get; set; }

        //public List<EmployeeJob> EmployeeJobs { get; set; }
    }
}

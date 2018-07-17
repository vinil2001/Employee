using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is missing")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Surename is missing")]
        public string LastName { get; set; }

        [NotMapped]
        public string Name { get { return FirstName + " " + LastName; } }

        [Required(ErrorMessage = "Date is missing")]
        [Display(Name= "Employment Date")]
        [DataType(DataType.Date)]
        public DateTime EmploymentDate { get; set; }      //(date + time)

        [Required(ErrorMessage = "Rate is missing")]
        public decimal Rate { get; set; }

        public DateTime CreationDate { get; set; }        // (save in db, can not show on UI)

        [Display(Name = "Job title")]
        [Required(ErrorMessage = "Job title is missing")]
        public ICollection<EmployeeJob> EmployeeJobs { get; set; }

        //public int JobId { get; set; }
        //public List<EmployeeJob> EmployeeJobs { get; set; }
    }
}

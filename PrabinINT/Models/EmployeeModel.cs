using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrabinINT.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee Name Required")]
        public string Employee_Name { get; set; }

        [Required(ErrorMessage = "Address Required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "DOB Required")]
        public System.DateTime Date_Of_Birth { get; set; }

        [Required(ErrorMessage = "Salary Required")]
        public decimal Salary { get; set; }
        public List<EmployeeModel> EmployeeModellist { get; set; }
    }
}
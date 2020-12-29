//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Source_Control_Final.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    public partial class Employee
    {
         public int Employee_Id { get; set; }

        [DisplayName("Employee Name")]
        [Required]
        [StringLength(50, ErrorMessage = "Only 50 character are allowed")]

        public string Name { get; set; }


        [DisplayName("Employee Age")]
        [Required]
        [Range(18,60, ErrorMessage = "Please enter Age Between 18 to 60.")]

        public int Age { get; set; }


        [DisplayName("Employee Gender")]
        [Required]

        public string Gender { get; set; }

        [DisplayName("Employee Date-Of-Birth")]
        [Required]
        [DataType(DataType.Date)]

        public System.DateTime DOB { get; set; }


        [DisplayName("Employee Contact No.")]
        [Required]
        [DataType(DataType.PhoneNumber)]

        public long Contact_No { get; set; }


        [DisplayName("Employee Designation")]
        [Required]

        public string Designation { get; set; }

        [DisplayName("Employee Email Id")]
        [Required]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter Valid Email ID")]

        public string Email { get; set; }



        [DisplayName("Employee Password")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }


        [Required]
        [DisplayName("Employee Confirm-Password")]
        [Compare("Password",ErrorMessage ="Confirm Password & Passsword Isn't Match.")]
        [DataType(DataType.Password)]
        public string Confirm_Password { get; set; }


        [DisplayName("Employee Address")]
        [DataType(DataType.MultilineText)]
        [Required]


        public string Address { get; set; }



        [DisplayName("Employee Image")]
        public string Image_path { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneBookMVC.Models
{
    [MetadataType(typeof(PersonMetaData))]
    public partial class Person
    {

    }
    public class PersonMetaData
    {
        [Required(ErrorMessage = "Wypełnij to pole.")]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}
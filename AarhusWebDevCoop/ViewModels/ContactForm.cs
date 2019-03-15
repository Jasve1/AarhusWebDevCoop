using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AarhusWebDevCoop.ViewModels
{
    public class ContactForm
    {
        [Required(ErrorMessage = "Please write your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please write your email")]
        [EmailAddress(ErrorMessage = "Please write an email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please write a subject")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Please write a message")]
        public string Message { get; set; }
    }
}
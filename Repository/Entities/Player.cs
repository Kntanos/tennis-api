using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace Repository.Entities
{
    public class Player
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        
        public int NationalityId { get; set; }

        //[Required(ErrorMessage = "Nationality is required")]
        public Nationality Nationality { get; set; }

        [MinimumAge(16)]
        public DateTime BirthDate { get; set; }

        public int Points { get; set; }

        public int Games { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2018.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string FirstName { get; set; }

        [Required, StringLength(255)]
        public string LastName { get; set; }

        public bool IsSubscribedNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }

        public DateTime? Birthdate { get; set; }
    }
}
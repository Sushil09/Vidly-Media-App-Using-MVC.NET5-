using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly_Most_Final.Models
{
    public class Customers
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter the Name")]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Type of Membership")]
        public byte MembershipTypeId { get; set; }

        [Display(Name="Date of Birth")]
        [Min18yearifAMember]
        public DateTime? BirthDate { get; set; }
    }
}
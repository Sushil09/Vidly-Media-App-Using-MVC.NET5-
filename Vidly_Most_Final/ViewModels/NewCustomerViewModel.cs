using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_Most_Final.Models;

namespace Vidly_Most_Final.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customers Customers { get; set; }
    }
}
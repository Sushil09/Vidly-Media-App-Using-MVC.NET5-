using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_Most_Final.Models;

namespace Vidly_Most_Final.ViewModels
{
    public class RandomViewViewModel
    {
        public Movies movies { get; set; }
        public List<Customers> customers { get; set; }
    }
}
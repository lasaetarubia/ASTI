using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTI_Helper.Models
{
    public class Application
    {
        public int ApplicationNumber { get; set; }

        public DateTime DateOfRegistration { get; set; }

        public bool IsPending { get; set; }
    }
}

using KYHProject.App_Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYHProject.Models
{
    public class Result
    {
        public int ResultId { get; set; }
        public DateTime CreatedOn { get; set; }
        public Shape? Shape { get; set; }        
        public Calculator? Calculator { get; set; }
        public Game? Game { get; set; }

    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OekakiTradingSite.Models
{
    public class User:IdentityUser<int>
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public int TotalCurrency { get; set; }
    }
}

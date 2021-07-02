using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iBOSApi.Models
{
    public class iBOS
    {
        [Key]
        public int intColdDrinksId { get; set; }
        public string strColdDrinksName { get; set; }
        public decimal numQuantity { get; set; }
        public decimal numUnitPrice { get; set; }
    }
}

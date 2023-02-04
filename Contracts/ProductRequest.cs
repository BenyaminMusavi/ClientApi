using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class ProductRequest
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public DateTime DateTime { get; set; }
        public int Amount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_K_accounting.Models
{
    public class BillViewModel
    {
        public string Login { get; set; }
        public string ServiceName { get; set; }
        public decimal Amount { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueToDate { get; set; }
    }
}

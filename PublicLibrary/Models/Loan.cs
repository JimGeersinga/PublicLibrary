using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicLibrary.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public Customer Customer { get; set; }
        public DateTime LoanDate { get; set; }
    }
}

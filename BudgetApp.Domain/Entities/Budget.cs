using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Domain.Entities
{
    public class Budget
    {
        public int Id { get; set; }
        public string Category { get; set; } = string.Empty;
        public decimal MontlyLimit { get; set; }
        public decimal SpentAmount { get; set; } = 0;
        public DateTime Month { get; set; }
    }
}

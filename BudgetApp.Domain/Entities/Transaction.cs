using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? Category { get; set; }
        public bool IsResolved { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

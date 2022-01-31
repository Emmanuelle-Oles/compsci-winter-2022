using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ============================================================================
// (c) Sandy Bultena 2018
// * Released under the GNU General Public License
// ============================================================================

namespace Budget
{
    // ====================================================================
    // CLASS: BudgetItem
    //        A single budget item, includes Category and Expense
    // ====================================================================
    /// <summary>
    /// A class that holds a single item. 
    /// </summary>
    public class BudgetItem
    {
        public int CategoryID { get; set; }
        public int ExpenseID { get; set; }
        public DateTime Date { get; set; }
        public String Category { get; set; }
        public String ShortDescription { get; set; }
        public Double Amount { get; set; }
        public Double Balance { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    public class BudgetItemsByMonth
    {
        public String Month { get; set; }
        public List<BudgetItem> Details { get; set; }
        public Double Total { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class BudgetItemsByCategory
    {
        public String Category { get; set; }
        public List<BudgetItem> Details { get; set; }
        public Double Total { get; set; }

    }


}

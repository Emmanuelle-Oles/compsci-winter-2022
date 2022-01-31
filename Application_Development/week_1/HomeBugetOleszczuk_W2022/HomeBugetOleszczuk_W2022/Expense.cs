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
    //                              CLASS: Expense
    // ====================================================================
    
    /// <summary>
    /// A class that represents an expense. 
    /// </summary>
    public class Expense
    {
        // ====================================================================
        //                           Properties
        // ====================================================================
       
        /// <summary>
        /// Property that gets a numerical id of an expense. 
        /// </summary>
        public int Id { get; }
       
        /// <summary>
        /// Property that gets date on a expense.
        /// </summary>
        public DateTime Date { get;  }
        
        /// <summary>
        /// Property that gets and sets the monetary value of the expense.
        /// </summary>
        public Double Amount { get; set; }
        
        /// <summary>
        /// Property that gets and sets the description of the expense.
        /// </summary>
        public String Description { get; set; }
        
        /// <summary>
        /// Property that gets and sets a numerical id of an categories.
        /// </summary>
        public int Category { get; set; }
        
        
        // ====================================================================
        //                               Constructor
        // ====================================================================
       
        /// <summary>
        /// Constructor creates an instance of Expense with the specified parameters.
        /// </summary>
        /// <param name="id"> Numerical representation of the expense. </param>
        /// <param name="date"> Date and time of the expense. </param>
        /// <param name="category"> Numerical representation of the category of the expense. </param>
        /// <param name="amount"> The monetary value of the expense. </param>
        /// <param name="description"> The description of the expense. </param>
        public Expense(int id, DateTime date, int category, Double amount, String description)
        {
            this.Id = id;
            this.Date = date;
            this.Category = category;
            this.Amount = amount;
            this.Description = description;
        }

        // ====================================================================
        //                  Copy constructor - does a deep copy
        // ====================================================================
        /// <summary>
        /// Constructor receives an instance of Expense and makes a deep copy of specified expense.
        /// </summary>
        /// <param name="obj"> Expense to be copied. </param>
        public Expense (Expense obj)
        {
            this.Id = obj.Id;
            this.Date = obj.Date;
            this.Category = obj.Category;
            this.Amount = obj.Amount;
            this.Description = obj.Description;
           
        }
    }
}

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
    // CLASS: Category
    //        - An individual category for budget program
    //        - Valid category types: Income, Expense, Credit, Saving
    // ====================================================================
    public class Category
    {
        // ====================================================================
        // Properties
        // ====================================================================
        public int Id { get; set; }
        public String Description { get; set; }
        public CategoryType Type { get; set; }
        public enum CategoryType
        {
            Income,
            Expense,
            Credit,
            Savings
        };

        // ====================================================================
        // Constructor
        // ====================================================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"> Numerical id assigned to the category. </param>
        /// <param name="description"> Description of the category. </param>
        /// <param name="type"> Type of category. </param>
        public Category(int id, String description, CategoryType type = CategoryType.Expense)
        {
            this.Id = id;
            this.Description = description;
            this.Type = type;
        }

        // ====================================================================
        // Copy Constructor
        // ====================================================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        public Category(Category category)
        {
            this.Id = category.Id;;
            this.Description = category.Description;
            this.Type = category.Type;
        }
        // ====================================================================
        // String version of object
        // ====================================================================
        /// <summary>
        /// Method ToString represensation of category. 
        /// </summary>
        /// <returns> Description of category. </returns>
        public override string ToString()
        {
            return Description;
        }

    }
}


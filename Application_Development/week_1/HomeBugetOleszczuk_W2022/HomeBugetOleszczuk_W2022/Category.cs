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

        /// <summary>
        /// Property that gets and sets a numerical id for a category. 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property that gets and sets the description of the category.
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// Property that gets and sets the category type from the CategoryType enum. 
        /// </summary>
        public CategoryType Type { get; set; }

        /// <summary>
        /// Enum that contains the default list of categories. 
        /// </summary>
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
        /// Constructor that creates an instance of category with the specificied id, description
        /// and type. If the type is not specified, it will be set by default to expense. 
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
        /// Constructor that takes the specified instance of category and makes a deep 
        /// copy. 
        /// </summary>
        /// <param name="category"></param>
        public Category(Category category)
        {
            this.Id = category.Id;;
            this.Description = category.Description;
            this.Type = category.Type;
        }

        // ====================================================================
        //                          Behaviours
        // ====================================================================
        /// <summary>
        /// Method that outputs the description of the category. 
        /// </summary>
        /// <returns> Description of category. </returns>
        /// <example>
        /// <code>
        /// 
        /// <![CDATA[
        /// Category category = new Category(12, "Food", Category.CategoryType.Expense);
        /// Console.WriteLine(category.ToString());
        ///
        /// ]]>
        /// 
        /// </code>
        /// </example>
        public override string ToString()
        {
            return Description;
        }

    }
}


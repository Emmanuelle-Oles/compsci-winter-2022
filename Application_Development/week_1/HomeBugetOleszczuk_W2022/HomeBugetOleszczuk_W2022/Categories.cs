using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

// ============================================================================
// (c) Sandy Bultena 2018
// * Released under the GNU General Public License
// ============================================================================

namespace Budget
{
    // ====================================================================
    //                          CLASS: categories
    // ====================================================================

    /// <summary>
    /// A class that represents a list of category items to organize a budget. 
    /// </summary>
    public class Categories
    {
        private static String DefaultFileName = "budgetCategories.txt";
        private List<Category> _Cats = new List<Category>();
        private string _FileName;
        private string _DirName;

        // ====================================================================
        // Properties
        // ====================================================================
        /// <summary>
        /// Property that gets the file name.
        /// </summary>
        public String FileName { get { return _FileName; } }

        /// <summary>
        /// Property that get the directory name.
        /// </summary>
        public String DirName { get { return _DirName; } }

        // ====================================================================
        // Constructor
        // ====================================================================

        /// <summary>
        /// Default constructor that populates the categories to default values.
        /// </summary>
        public Categories()
        {
            SetCategoriesToDefaults();
        }

        // ====================================================================
        // get a specific category from the list where the id is the one specified
        // ====================================================================

        /// <summary>
        /// Method that gets the category object based on the specified id.
        /// Throws a exception, if the category can not be found.
        /// </summary>
        /// <param name="i"> Numerical id for a specific category.</param>
        /// <returns> Category with the corresponding id. </returns>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// 
        /// Categories categories = new Categories();
        /// Category category = categories.GetCategoryFromId(12);
        ///
        /// ]]>
        /// </code>
        /// </example>
        public Category GetCategoryFromId(int i)
        {
            Category c = _Cats.Find(x => x.Id == i);
            if (c == null)
            {
                throw new Exception("Cannot find category with id " + i.ToString());
            }
            return c;
        }

        // ====================================================================
        // populate categories from a file
        // if filepath is not specified, read/save in AppData file
        // Throws System.IO.FileNotFoundException if file does not exist
        // Throws System.Exception if cannot read the file correctly (parsing XML)
        // ====================================================================

        /// <summary>
        /// Method reads from specified file to extract the categories.
        /// </summary>
        /// <param name="filepath"> File path to read from. </param>
        /// <example>
        /// <code>
        /// <![CDATA[

        /// ]]>
        /// </code>
        /// </example>
        public void ReadFromFile(String filepath = null)
        {

            // ---------------------------------------------------------------
            // reading from file resets all the current categories,
            // ---------------------------------------------------------------
            _Cats.Clear();

            // ---------------------------------------------------------------
            // reset default dir/filename to null 
            // ... filepath may not be valid, 
            // ---------------------------------------------------------------
            _DirName = null;
            _FileName = null;

            // ---------------------------------------------------------------
            // get filepath name (throws exception if it doesn't exist)
            // ---------------------------------------------------------------
            filepath = BudgetFiles.VerifyReadFromFileName(filepath, DefaultFileName);

            // ---------------------------------------------------------------
            // If file exists, read it
            // ---------------------------------------------------------------
            _ReadXMLFile(filepath);
            _DirName = Path.GetDirectoryName(filepath);
            _FileName = Path.GetFileName(filepath);
        }

        // ====================================================================
        // save to a file
        // if filepath is not specified, read/save in AppData file
        // ====================================================================

        /// <summary>
        /// Method saves to specified file.
        /// The file is 
        /// </summary>
        /// <param name="filepath"> File path to save to. </param>
        public void SaveToFile(String filepath = null)
        {
            // ---------------------------------------------------------------
            // if file path not specified, set to last read file
            // ---------------------------------------------------------------
            if (filepath == null && DirName != null && FileName != null)
            {
                filepath = DirName + "\\" + FileName;
            }

            // ---------------------------------------------------------------
            // just in case filepath doesn't exist, reset path info
            // ---------------------------------------------------------------
            _DirName = null;
            _FileName = null;

            // ---------------------------------------------------------------
            // get filepath name (throws exception if it doesn't exist)
            // ---------------------------------------------------------------
            filepath = BudgetFiles.VerifyWriteToFileName(filepath, DefaultFileName);

            // ---------------------------------------------------------------
            // save as XML
            // ---------------------------------------------------------------
            _WriteXMLFile(filepath);

            // ----------------------------------------------------------------
            // save filename info for later use
            // ----------------------------------------------------------------
            _DirName = Path.GetDirectoryName(filepath);
            _FileName = Path.GetFileName(filepath);
        }

        // ====================================================================
        // set categories to default
        // ====================================================================
        /// <summary>
        /// Method sets categories to default values.
        /// </summary>
        public void SetCategoriesToDefaults()
        {
            // ---------------------------------------------------------------
            // reset any current categories,
            // ---------------------------------------------------------------
            _Cats.Clear();

            // ---------------------------------------------------------------
            // Add Defaults
            // ---------------------------------------------------------------
            Add("Utilities", Category.CategoryType.Expense);
            Add("Rent", Category.CategoryType.Expense);
            Add("Food", Category.CategoryType.Expense);
            Add("Entertainment", Category.CategoryType.Expense);
            Add("Education", Category.CategoryType.Expense);
            Add("Miscellaneous", Category.CategoryType.Expense);
            Add("Medical Expenses", Category.CategoryType.Expense);
            Add("Vacation", Category.CategoryType.Expense);
            Add("Credit Card", Category.CategoryType.Credit);
            Add("Clothes", Category.CategoryType.Expense);
            Add("Gifts", Category.CategoryType.Expense);
            Add("Insurance", Category.CategoryType.Expense);
            Add("Transportation", Category.CategoryType.Expense);
            Add("Eating Out", Category.CategoryType.Expense);
            Add("Savings", Category.CategoryType.Savings);
            Add("Income", Category.CategoryType.Income);

        }

        // ====================================================================
        // Add category
        // ====================================================================
        /// <summary>
        /// Method adds a category. 
        /// </summary>
        /// <param name="cat"> Category to be added. </param>
        private void Add(Category cat)
        {
            _Cats.Add(cat);
        }

        /// <summary>
        /// Overloaded methods that adds category
        /// </summary>
        /// <param name="desc"> Description of category. </param>
        /// <param name="type"> Type of category. </param>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// 
        /// Categories categories = new Categories();
        /// 
        /// categories.Add("Leisure", Category.CategoryType.Expense);
        /// categories.Add("Freelancing", Category.CategoryType.Income);
        /// 
        ///
        /// ]]> 
        /// </code>
        /// </example>
        public void Add(String desc, Category.CategoryType type)
        {
            int new_num = 1;
            if (_Cats.Count > 0)
            {
                new_num = (from c in _Cats select c.Id).Max();
                new_num++;
            }
            _Cats.Add(new Category(new_num, desc, type));
        }

        /// <summary>
        /// Method that removes/delete category from the list.
        /// </summary>
        /// <param name="Id"> Id of category to be removed. </param>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// Categories categories = new Categories();
        /// 
        /// categories.Add("Leisure", Category.CategoryType.Expense);
        /// 
        /// categories.Add("Freelance", Category.CategoryType.Income);
        /// 
        /// foreach(Category category in categories.List())
        ///     Console.WriteLine(category);
        ///     
        /// Console.ReadKey();
        /// 
        /// categories.Delete(1);
        /// 
        /// foreach (Category category in categories.List())
        ///     Console.WriteLine(category);
        ///     
        /// Console.ReadKey();
        /// ]]>
        /// </code>
        /// </example>
        public void Delete(int Id)
        {
            int i = _Cats.FindIndex(x => x.Id == Id);
            _Cats.RemoveAt(i);
        }

        // ====================================================================
        // Return list of categories
        // Note:  make new copy of list, so user cannot modify what is part of
        //        this instance
        // ====================================================================

        /// <summary>
        /// Method makes a copy of list of category.
        /// </summary>
        /// <returns> List of categories. </returns>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// 
        /// Categories categories = new Categories();
        /// categories.Add("Leisure", Category.CategoryType.Expense);
        /// List<Category> categoriesList = categories.List();
        ///
        /// foreach(Category category in categoriesList)    
        ///     Console.WriteLine(category.Description);
        ///
        /// ]]> 
        /// </code>
        /// </example>
        public List<Category> List()
        {
            List<Category> newList = new List<Category>();
            foreach (Category category in _Cats)
            {
                newList.Add(new Category(category));
            }
            return newList;
        }

        /// <summary>
        /// Method reads from XML file and adds categories to the list of categories.
        /// </summary>
        /// <param name="filepath"> The file path to read from. </param>
        private void _ReadXMLFile(String filepath)
        {

            // ---------------------------------------------------------------
            // read the categories from the xml file, and add to this instance
            // ---------------------------------------------------------------
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filepath);

                foreach (XmlNode category in doc.DocumentElement.ChildNodes)
                {
                    String id = (((XmlElement)category).GetAttributeNode("ID")).InnerText;
                    String typestring = (((XmlElement)category).GetAttributeNode("type")).InnerText;
                    String desc = ((XmlElement)category).InnerText;

                    Category.CategoryType type;
                    switch (typestring.ToLower())
                    {
                        case "income":
                            type = Category.CategoryType.Income;
                            break;
                        case "expense":
                            type = Category.CategoryType.Expense;
                            break;
                        case "credit":
                            type = Category.CategoryType.Credit;
                            break;
                        default:
                            type = Category.CategoryType.Expense;
                            break;
                    }
                    this.Add(new Category(int.Parse(id), desc, type));
                }

            }
            catch (Exception e)
            {
                throw new Exception("ReadXMLFile: Reading XML " + e.Message);
            }

        }

        /// <summary>
        /// Method that write the list of categories to a XML file.
        /// </summary>
        /// <param name="filepath"> File path to write to. </param>
        private void _WriteXMLFile(String filepath)
        {
            try
            {
                // create top level element of categories
                XmlDocument doc = new XmlDocument();
                doc.LoadXml("<Categories></Categories>");

                // foreach Category, create an new xml element
                foreach (Category cat in _Cats)
                {
                    XmlElement ele = doc.CreateElement("Category");
                    XmlAttribute attr = doc.CreateAttribute("ID");
                    attr.Value = cat.Id.ToString();
                    ele.SetAttributeNode(attr);
                    XmlAttribute type = doc.CreateAttribute("type");
                    type.Value = cat.Type.ToString();
                    ele.SetAttributeNode(type);

                    XmlText text = doc.CreateTextNode(cat.Description);
                    doc.DocumentElement.AppendChild(ele);
                    doc.DocumentElement.LastChild.AppendChild(text);

                }

                // write the xml to FilePath
                doc.Save(filepath);

            }
            catch (Exception e)
            {
                throw new Exception("_WriteXMLFile: Reading XML " + e.Message);
            }

        }

    }
}


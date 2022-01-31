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
    //                           CLASS: Expenses
    // ====================================================================

    /// <summary>
    /// A class that holds an instance of a list of Expense objects. Also, holds the functionality of 
    /// reading and writing to file.
    /// </summary>
    public class Expenses
    {
        private static String DefaultFileName = "budget.txt";
        private List<Expense> _Expenses = new List<Expense>();
        private string _FileName;
        private string _DirName;

        // ====================================================================
        //                          Properties
        // ====================================================================

        /// <summary>
        /// Property that gets a file name.
        /// </summary>
        public String FileName { get { return _FileName; } }

        /// <summary>
        /// Property that gets the name of directory.
        /// </summary>
        public String DirName { get { return _DirName; } }



        /// <summary>
        /// Method populates categories from file. If the file not specified, the information is 
        /// read and saved to a file in the AppData folder.
        /// Method throws a System.IO.FileNotFoundException if file does not exist.
        /// Method throws a System.Exception if file cannot be read during the XML parsing.
        /// </summary>
        /// <param name="filepath"> File path to the file that contains the budget information.
        ///  File path is set to null by default </param>
        public void ReadFromFile(String filepath = null)
        {

            // ---------------------------------------------------------------
            // reading from file resets all the current expenses,
            // so clear out any old definitions
            // ---------------------------------------------------------------
            _Expenses.Clear();

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
            // read the expenses from the xml file
            // ---------------------------------------------------------------
            _ReadXMLFile(filepath);

            // ----------------------------------------------------------------
            // save filename info for later use?
            // ----------------------------------------------------------------
            _DirName = Path.GetDirectoryName(filepath);
            _FileName = Path.GetFileName(filepath);


        }


        /// <summary>
        /// Method that saves file.
        /// If the file path not specified, the information is read and saved to a file in the AppData folder.
        /// If the file path does not exist, the path information is reset.
        /// </summary>
        /// <param name="filepath"> File path specified by user to location.
        /// File path is set to null by default. </param>
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


        /// <summary>
        /// Method adds an instance expense to the list of expenses. 
        /// </summary>
        /// <param name="exp"> Expense that needs to be added. </param>
        private void Add(Expense exp)
        {
            _Expenses.Add(exp);
        }

        /// <summary>
        /// Method receives specified date, category, amount and description of an
        /// expense sets the id of the expense and adds it to the list of expenses. 
        /// </summary>
        /// <param name="date"> Date and time of the expense. </param>
        /// <param name="category"> Numerical representation of the category of the expense. </param>
        /// <param name="amount"> The monetary value of the expense. </param>
        /// <param name="description"> The description of the expense. </param>
        public void Add(DateTime date, int category, Double amount, String description)
        {
            int new_id = 1;

            // if we already have expenses, set ID to max
            if (_Expenses.Count > 0)
            {
                new_id = (from e in _Expenses select e.Id).Max();
                new_id++;
            }

            _Expenses.Add(new Expense(new_id, date, category, amount, description));

        }

        /// <summary>
        /// Methods receives specified id of an expense retrieves the index of the
        /// expense from the list and removes the expense at that index. 
        /// </summary>
        /// <param name="Id"> Numerical representation of the expense. </param>
        public void Delete(int Id)
        {
            int i = _Expenses.FindIndex(x => x.Id == Id);
            _Expenses.RemoveAt(i);

        }

        /// <summary>
        /// Method instantiates a list of expenses to allow to make a
        /// copy of the list of the current instance of expenses. Using a
        /// for-each loop the current expense items are added to the new
        /// expense list.
        /// </summary>
        /// <returns> Returns a copied list of expenses. </returns>
        public List<Expense> List()
        {
            //creating a instance of a list of expense
            List<Expense> newList = new List<Expense>();
            //looping through the expense from the field and creating a new copy of list
            foreach (Expense expense in _Expenses)
            {
                newList.Add(new Expense(expense));
            }
            return newList;
        }


        /// <summary>
        /// Method that reads from a XML file and adds the categories of expenses
        /// to a list of categories.
        /// If the file cannot create expense from file, throws a ReadFromFileException.
        /// </summary>
        /// <param name="filepath"> File path of the XML file. </param>
        private void _ReadXMLFile(String filepath)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filepath);

                // Loop over each Expense
                foreach (XmlNode expense in doc.DocumentElement.ChildNodes)
                {
                    // set default expense parameters
                    int id = int.Parse((((XmlElement)expense).GetAttributeNode("ID")).InnerText);
                    String description = "";
                    DateTime date = DateTime.Parse("2000-01-01");
                    int category = 0;
                    Double amount = 0.0;

                    // get expense parameters
                    foreach (XmlNode info in expense.ChildNodes)
                    {
                        switch (info.Name)
                        {
                            case "Date":
                                date = DateTime.Parse(info.InnerText);
                                break;
                            case "Amount":
                                amount = Double.Parse(info.InnerText);
                                break;
                            case "Description":
                                description = info.InnerText;
                                break;
                            case "Category":
                                category = int.Parse(info.InnerText);
                                break;
                        }
                    }

                    // have all info for expense, so create new one
                    this.Add(new Expense(id, date, category, amount, description));

                }

            }
            catch (Exception e)
            {
                throw new Exception("ReadFromFileException: Reading XML " + e.Message);
            }
        }


        /// <summary>
        /// Method writes to XML file. 
        /// If the file path is not specified, the file path by default write to a file stored in the App Data folder.
        /// If the file can not be written to, a SaveToFileException is thrown. 
        /// </summary>
        /// <param name="filepath"> File path of the XML file. </param>
        private void _WriteXMLFile(String filepath)
        {
            // ---------------------------------------------------------------
            // loop over all categories and write them out as XML
            // ---------------------------------------------------------------
            try
            {
                // create top level element of expenses
                XmlDocument doc = new XmlDocument();
                doc.LoadXml("<Expenses></Expenses>");

                // foreach Category, create an new xml element
                foreach (Expense exp in _Expenses)
                {
                    // main element 'Expense' with attribute ID
                    XmlElement ele = doc.CreateElement("Expense");
                    XmlAttribute attr = doc.CreateAttribute("ID");
                    attr.Value = exp.Id.ToString();
                    ele.SetAttributeNode(attr);
                    doc.DocumentElement.AppendChild(ele);

                    // child attributes (date, description, amount, category)
                    XmlElement d = doc.CreateElement("Date");
                    XmlText dText = doc.CreateTextNode(exp.Date.ToString());
                    ele.AppendChild(d);
                    d.AppendChild(dText);

                    XmlElement de = doc.CreateElement("Description");
                    XmlText deText = doc.CreateTextNode(exp.Description);
                    ele.AppendChild(de);
                    de.AppendChild(deText);

                    XmlElement a = doc.CreateElement("Amount");
                    XmlText aText = doc.CreateTextNode(exp.Amount.ToString());
                    ele.AppendChild(a);
                    a.AppendChild(aText);

                    XmlElement c = doc.CreateElement("Category");
                    XmlText cText = doc.CreateTextNode(exp.Category.ToString());
                    ele.AppendChild(c);
                    c.AppendChild(cText);

                }

                // write the xml to FilePath
                doc.Save(filepath);

            }
            catch (Exception e)
            {
                throw new Exception("SaveToFileException: Reading XML " + e.Message);
            }
        }
    }
}


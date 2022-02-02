using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget
{
    class Program
    {
        static void Main(string[] args)
        {


            //Category category = new Category(12, "Food", Category.CategoryType.Expense);
            //Console.WriteLine(category.ToString());
            //Console.ReadLine();

            //Categories categories = new Categories();
            //Category category = categories.GetCategoryFromId(11);


            //Expenses expenses = new Expenses();
            //expenses.Add(DateTime.Now, (int)Category.CategoryType.Expense,
            //            23.45, "textbook");
            //List<Expense> list = expenses.List();
            //foreach (Expense expense in list)
            //    Console.WriteLine(expense.Description);

            //Categories categories = new Categories();

            //categories.Add("Leisure", Category.CategoryType.Expense);

            //List<Category> categoriesList = categories.List();

            //foreach(Category category in categoriesList)
            //    Console.WriteLine(category.Description);

            //===============================================
            //Categories categories = new Categories();
            //categories.Add("Leisure", Category.CategoryType.Expense);
            //categories.Add("Freelance", Category.CategoryType.Income);


            //foreach(Category category in categories.List())
            //    Console.WriteLine(category);

            //Console.ReadKey();

            //categories.Delete(1);

            //foreach (Category category in categories.List())
            //    Console.WriteLine(category);

            //Console.ReadKey();



            Expenses expenses = new Expenses();
            expenses.Add(DateTime.Now, (int)Category.CategoryType.Expense,
                        22.22, "transportation");
            expenses.Add(DateTime.Now, (int)Category.CategoryType.Expense,
            33.33, "Tarot");


            foreach (Expense expense in expenses.List())
                Console.WriteLine(expense.Description);

            Console.ReadLine();

            expenses.Delete(1);

            foreach (Expense expense in expenses.List())
                Console.WriteLine(expense.Description);

            Console.ReadLine();



        }
    }
}

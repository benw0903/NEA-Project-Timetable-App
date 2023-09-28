using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TimeTableApp_NEA
{
    class MainTimeTable
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"
███╗   ███╗██╗   ██╗████████╗██╗███╗   ███╗███████╗
████╗ ████║╚██╗ ██╔╝╚══██╔══╝██║████╗ ████║██╔════╝
██╔████╔██║ ╚████╔╝    ██║   ██║██╔████╔██║█████╗  
██║╚██╔╝██║  ╚██╔╝     ██║   ██║██║╚██╔╝██║██╔══╝  
██║ ╚═╝ ██║   ██║      ██║   ██║██║ ╚═╝ ██║███████╗
╚═╝     ╚═╝   ╚═╝      ╚═╝   ╚═╝╚═╝     ╚═╝╚══════╝
                                                   


Press any key to enter.");

            Console.WriteLine("");

            Console.ReadKey();
            Console.Clear();
            ViewOrCreate();
        }
        static void ViewOrCreate()
        {
            Console.WriteLine("Would you like to view or create a table today(View/Create)");

            string option = Console.ReadLine();
            option = option.ToLower();

            if(option == "view")
            {
                ViewTable();
            }
            if (option == "create")
            {
                TableInfo();

            }
        }
        static void TableInfo()
        {
            Console.WriteLine("Hello user. How many slots for activities will you want?");
            int numRows = int.Parse(Console.ReadLine());
            int numColumns = 7;
            
            CreateTable table = new CreateTable(numRows, numColumns);
            
        }



        static void ViewTable()
        {
            Console.WriteLine("Enter the name of the file you would like to view.");
            string fileName = Console.ReadLine();
        }


        

    }
}

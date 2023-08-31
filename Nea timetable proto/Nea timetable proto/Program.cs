using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Nea_timetable_proto
{
    class Program
    {
        static void Main(string[] args)
        {
            StartingMenu();
        }

        static void StartingMenu()
        {
            
            Console.WriteLine(@"
███╗   ███╗██╗   ██╗████████╗██╗███╗   ███╗███████╗
████╗ ████║╚██╗ ██╔╝╚══██╔══╝██║████╗ ████║██╔════╝
██╔████╔██║ ╚████╔╝    ██║   ██║██╔████╔██║█████╗  
██║╚██╔╝██║  ╚██╔╝     ██║   ██║██║╚██╔╝██║██╔══╝  
██║ ╚═╝ ██║   ██║      ██║   ██║██║ ╚═╝ ██║███████╗
╚═╝     ╚═╝   ╚═╝      ╚═╝   ╚═╝╚═╝     ╚═╝╚══════╝
                                                   


Press any key to enter");
            Console.ReadKey();

            Console.WriteLine("Do you have login details? yes/no");
            string option = Console.ReadLine();
            option = option.ToLower();
            Console.WriteLine("");

            while (option != "yes" && option != "no")
            {
                Console.WriteLine("Do you have login details? yes/no");
                option = Console.ReadLine();
            }

            if (option == "yes")
            {

                Login();
                //login for already made account
            }

            if (option == "no")
            {
                CreateAccount();
                //new account
            }

            Console.ReadKey();
        }

        static void CreateAccount()
        {
            string username;
            string password;


            Console.WriteLine("Would you like to make an account? yes/no");
            string option = Console.ReadLine();
            option = option.ToLower();
            Console.WriteLine("");

            while (option != "yes" && option != "no")
            {
                Console.WriteLine("Would you like to make an account? yes/no");
                option = Console.ReadLine();
            }

            if (option == "no")
            {
                Exit();
            }
            //Option for new account or exit TimeTable
            if (option == "yes")
            {

                Console.WriteLine("Please create a username.");
                username = Console.ReadLine();

                Console.WriteLine("");

                Console.WriteLine("Please create a password.");
                password = Console.ReadLine();

                Console.WriteLine("Are you happy with your username and password? yes/no");
                string option2 = Console.ReadLine();
                option2 = option2.ToLower();
                Console.WriteLine("");

                while (option2 != "yes" && option2 == "no")
                {
                    Console.WriteLine("Please create a username.");
                    username = Console.ReadLine();
                    Console.WriteLine("");

                    Console.WriteLine("Please create a password.");
                    password = Console.ReadLine();
                    Console.WriteLine("");

                    Console.WriteLine("Are you happy with your username and password? yes/no");
                    option2 = Console.ReadLine();
                    option2 = option2.ToLower();
                    Console.WriteLine("");
                }

                if (option2 == "yes")
                {
                    Console.WriteLine("What would you like the name of your file to be?");
                    string fileName = Console.ReadLine();
                    string file = fileName + ".txt";
                    Console.WriteLine("");

                    using (StreamWriter sw = new StreamWriter(file))
                    {
                        sw.WriteLine(username + " " + password);
                    }
                    //inputting the new username and password for new file


                    Login();
                }
            }
        }


        static void Login()
        {

            Console.WriteLine("Please enter your username.");
            string username = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Please enter your password. ");
            string password = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("What file would you like to open");
            string fileName = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("");
            string file = fileName + ".txt";


            if (CheckUsernameAndPassword(username, password, file) == true)
            {
                Console.WriteLine("Your username and password were valid hello " + username + ".");
                CreatTable(file);
            }
            if (CheckUsernameAndPassword(username, password, file) == false)
            {
                Console.WriteLine(@"The username or password that was enter was invalid.
Would you like to:
Try again /again
Create an account /create
Exit /exit
");
                string option = Console.ReadLine();
                option = option.ToLower();

                if (option == "again")
                {
                    Login();
                }
                if (option == "create")
                {
                    CreateAccount();
                }
                if (option == "exit")
                {
                    Exit();
                }

            }


        }


        static bool CheckUsernameAndPassword(string username, string password, string file)
        {
            string line;
            using (StreamReader sr = new StreamReader(file))
            {
                line = sr.ReadLine();
            }
            // checking if your username and password matches the one in the file
            if (line == username + " " + password)
            {
                return true;
            }

            if (line != username + " " + password)
            {
                return false;
            }
            return false;
        }

        static void CreatTable(string file)
        {
            string[,] timetable = new string[7, 7];

            // Initialize the timetable
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    timetable[i, j] = "-";
                }
            }

            
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"Enter activities for day {i + 1}:");

                for (int j = 0; j < 7; j++)
                {
                    Console.Write($"Enter activity for {GetTime(j)}: ");
                    timetable[i, j] = $"{GetTime(j)} {Console.ReadLine()}";
                }
            }

           


            Console.WriteLine("============================================================================================================================");
            Console.WriteLine("| Day |");
            Console.WriteLine("|-------|------------------|------------------|-------------------|------------------|------------------|------------------|");

            for (int i = 0; i < 7; i++)
            {
                Console.Write($"| Day {i + 1} ");
                
                for (int j = 0; j < 7; j++)
                {
                   
                    Console.Write($"| {timetable[i, j],-7} ");

                }

                Console.WriteLine("|");
                Console.WriteLine("|-------|------------------|------------------|-------------------|------------------|------------------|------------------|");
                
            }
        }

        static string GetTime(int index)
        {
            if (index == 0) return "6:00 AM";
            if (index == 1) return "9:00 AM";
            if (index == 2) return "12:00 PM";
            if (index == 3) return "3:00 PM";
            if (index == 4) return "6:00 PM";
            if (index == 5) return "8:00 PM";
            if (index == 6) return "10:00 PM";
            return "Invalid Time";
        }
        
        static void Exit()
        {
            Console.ReadKey();
        }
    }
}


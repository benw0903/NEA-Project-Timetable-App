using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Services;

namespace NEA_TIMETABLE_PROTOTYPE
{
    internal class Program
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
            //option for new account or exit
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
                TableBlock(file);
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




        static void CreateTable(string file,string[,] table,int timeOfDay,int day)
        {
            if(day == 6)
            {
                if(timeOfDay == 6)
                {
                    for (int i = 0; i < 35; i++)
                    {
                        Console.Write(table[timeOfDay, day]);
                    }
                }
            }
            

        }

        static void TableBlock(string file)
        {
            string block;
            string[,] table = new string[6, 6];
            int timeOfDay = 0;
            int day = 0;

            for (int i = 0; i < 35; i++)
            {
                if (i < 35)
                {
                    block = "";
                    timeOfDay = timeOfDay + 1;


                    Console.WriteLine("Enter a starting time that is is on a 12 hour clock.");
                    int sTime = int.Parse(Console.ReadLine());
                    while (sTime <= 0 || sTime >= 13)
                    {
                        sTime = int.Parse(Console.ReadLine());
                    }

                    Console.WriteLine("Is this am or pm?");
                    string sAmOrPm = Console.ReadLine();
                    while (sAmOrPm != "am" & sAmOrPm != "pm")
                    {
                        sAmOrPm = Console.ReadLine();
                    }

                    Console.WriteLine("Enter a ending time that is is on a 12 hour clock.");
                    int eTime = int.Parse(Console.ReadLine());
                    while (eTime <= 0 || eTime >= 13)
                    {
                        eTime = int.Parse(Console.ReadLine());
                    }

                    Console.WriteLine("Is this am or pm?");
                    string eAmOrPm = Console.ReadLine();
                    while (eAmOrPm != "am" & eAmOrPm != "pm")
                    {
                        eAmOrPm = Console.ReadLine();
                    }

                    Console.WriteLine("What are you doing in this time period.");
                    string activity = Console.ReadLine();
                    Console.WriteLine("");




                    block = @"  ________________
 /                \
|   " + sTime + sAmOrPm + " - " + eTime + eAmOrPm + @"     |  
|                  | 
| " + activity + @"             |     
|                  | 
|                  |
 \                /
  ________________
";

                    table[timeOfDay, day] = block;
                    if (timeOfDay == 6)
                    {
                        day = day + 1;
                        timeOfDay = 0;
                    }
                    table[timeOfDay, day] = block;

                    CreateTable(file, table ,timeOfDay,day);
                }
            }

            
        }

        static void Exit()
        {

        }
    }
}
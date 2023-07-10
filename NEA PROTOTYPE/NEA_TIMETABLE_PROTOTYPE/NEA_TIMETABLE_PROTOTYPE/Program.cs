using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

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

            while(option != "yes" && option != "no")
            {
                Console.WriteLine("Do you have login details? yes/no");
                option = Console.ReadLine();
            }

            if(option == "yes")
            {

                Login();
                //login for already made account
            }
                     
            if(option == "no")
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
            if(option == "yes")
            {

                Console.WriteLine("Please create a username.");
                username = Console.ReadLine();

                Console.WriteLine("");

                Console.WriteLine("Please create a password.");
                password = Console.ReadLine();

                Console.WriteLine("Are you happy with your username and password? yes/no");
                string option2= Console.ReadLine();
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

            
            if(CheckUsernameAndPassword(username,password,file) == true)
            {
                Console.WriteLine("Your username and password were valid hello " +username+".");
                StartingDay(file);
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

                if(option == "again")
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

        static bool CheckUsernameAndPassword(string username,string password,string file)
        {
            string line;
            using (StreamReader sr = new StreamReader(file))
            {
                line = sr.ReadLine();
            }
            // checking if your username and password matches the one in the file
            if(line == username + " " + password)
            {
                return true;
            }
            
            if(line != username + " " + password)
            { 
                return false;
            }
            return false;
        }

        
        static void StartingDay(string file)
        {

            string[] daysOfTheWeek = new string[7] { "monday", "tuesday", "wednesday", "thursday", "friday", "saturday", "sunday" };
            Console.WriteLine("Please enter the starting day of the week for you MyTime Timetable.");
            string startingDay = Console.ReadLine();
            Console.WriteLine("");
            startingDay = startingDay.ToLower();
            int count = 1;
            //assigning numbers for the starting days of your mytime timtable

            for (int i = 0; i < 7; i++)
            {
                if (i == 7)
                {
                    Console.WriteLine("Please enter the ending day of the week for your MyTime Timetable.");
                    startingDay = Console.ReadLine();
                    startingDay = startingDay.ToLower();
                    i = 0;
                }
                if (startingDay != daysOfTheWeek[i])
                {
                    Console.WriteLine(startingDay + " != to " + daysOfTheWeek[i] + ".(" + count + "/7)");
                    count = count + 1;
                }
                if (startingDay == daysOfTheWeek[i])
                {
                    Console.WriteLine(startingDay + " == to " + daysOfTheWeek[i] + ".(" + (i + 1) + "/7)");
                    count = count + 1;
                    EndingDay(daysOfTheWeek[i],i+1,file);
                }
            }
        }
        static void EndingDay(string startingDay ,int startingDayNum,string file)
        {
            string[] daysOfTheWeek = new string[7] { "monday", "tuesday", "wednesday", "thursday", "friday", "saturday", "sunday" };
            int count = 1;
            Console.WriteLine("Please enter the ending day of the week for your MyTime Timetable.");
            string endingDay = Console.ReadLine();
            endingDay = endingDay.ToLower();
            //assigning numbers for the ending days of your mytime timtable

            for (int i = 0; i < 7; i++)
            {
                if (i == 7)
                {
                    Console.WriteLine("Please enter the ending day of the week for your MyTime Timetable.");
                    endingDay = Console.ReadLine();
                    endingDay = endingDay.ToLower();
                    i = 0;
                }
                if (endingDay != daysOfTheWeek[i])
                {
                    Console.WriteLine(endingDay + " != to " + daysOfTheWeek[i] + ".(" + count + "/7)");
                    count = count + 1;
                }
                if (endingDay == daysOfTheWeek[i])
                {
                    Console.WriteLine(endingDay + " == to " + daysOfTheWeek[i] + ".(" + (i + 1) + "/7)");
                    count = count + 1;
                    CreateTable(startingDay, startingDayNum, daysOfTheWeek[i], i + 1,file);
                    
                }

            }
        }

        static void CreateTable(string startingDay, int startingDayNum,string endingDay,int endingDayNum,string file)
        {


            int[,] table = new int[6, 6];
            using (StreamWriter sw = new StreamWriter(file))
            {
                string text = Console.ReadLine();
                sw.WriteLine(text);
                sw.WriteLine("ben");
            }

        }
        static void TableInfo(string startingDay, int startingDayNum, string endingDay, int endingDayNum)
        {

        }

        static void TableDisplay()
        {

        }

        static void Exit()
        {

        }
    }
}

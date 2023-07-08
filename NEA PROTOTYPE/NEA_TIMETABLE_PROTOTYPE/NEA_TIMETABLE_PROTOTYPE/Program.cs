using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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


            Console.WriteLine("Would you like to make an account?");
            string option = Console.ReadLine();
            option = option.ToLower();

            while (option != "yes" && option != "no")
            {
                Console.WriteLine("Would you like to make an account?");
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

                Console.WriteLine("Are you happy with your username and password?");
                string option2= Console.ReadLine();
                option2 = option2.ToLower();

                while (option2 != "yes" && option2 == "no")
                {
                    Console.WriteLine("Please create a username.");
                    username = Console.ReadLine();

                    Console.WriteLine("");

                    Console.WriteLine("Please create a password.");
                    password = Console.ReadLine();

                    Console.WriteLine("Are you happy with your username and password?");
                    option2 = Console.ReadLine();
                    option2 = option2.ToLower();
                }

                if (option2 == "yes")
                {
                    Console.WriteLine("What would you like the name of your file to be?");
                    string fileName = Console.ReadLine();
                    string file = fileName + ".txt";
                     
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

            Console.WriteLine("Please enter your password. ");
            string password = Console.ReadLine();

            string fileName = Console.ReadLine();
            string file = fileName + ".txt";

            Console.WriteLine("What file would you like to open");
            if(CheckUsernameAndPassword(username,password,file) == true)
            {
                Console.WriteLine("Your username and password were valid");
                CreateTable();
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

        static void CreateTable()
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

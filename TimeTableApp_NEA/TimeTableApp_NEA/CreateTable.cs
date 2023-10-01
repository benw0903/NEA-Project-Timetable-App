using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TimeTableApp_NEA
{
    class CreateTable
    {
        public string[,] TableRowAndColumns { get; }

        public CreateTable(int rows ,int columns)
        {
            TableRowAndColumns = new string[columns,rows];
        }

        
    }

    class CreateFile
    {
        public string fileName;
        CreateFile()
        {
            string file = fileName;
        }
    }

    class block
    {
        block()
        {

        }
    }

    class ActivitiesAndTimes
    {
        public string[] Days { get; }
        public string[,] Activities{ get; }

        ActivitiesAndTimes(int rows, int columns)
        {
            Activities = new string[columns, rows];
        }

        public void DayOfWeek(string[] days)
        {
            days = new string[7] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        }
    }

    class activities
    {
        activities()
        {

        }
    }
}

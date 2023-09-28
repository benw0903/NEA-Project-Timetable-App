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
            TableRowAndColumns = new string[rows, columns];
        }
        

        
    }
}

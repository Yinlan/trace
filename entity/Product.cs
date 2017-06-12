using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trace.entity
{
    public class Product
    {
        public int id;
        public string name;
        public int sort;
        public int pid; //网络平台上的id

        public Product()
        {
            id = 0;
            name = "";
            sort = 0;
        }
    }
}

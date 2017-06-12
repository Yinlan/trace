using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trace.util
{
    public class StringUtil
    {
        public static bool isEmpty(string str){
            if (str == null || str.Trim().Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

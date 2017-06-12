using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trace.entity
{
    class Qrcode
    {
        public string name;
        public string pickTime;
        public string source;
        public string address;
        public string pic;
        public string detectTime;
        public string nc;
        public string printTime;
        public string no; //编号，批号，any~
        public string netId;
        public string productId;
        public string upload;

        public Qrcode()
        {
            pickTime = "";
            source = "";
            address = "";
            pic = "";
            detectTime = "";
            nc = "";
            printTime = "";
            no = "";
            netId = "";
            productId = "";
            upload = "";
        }
    }
}

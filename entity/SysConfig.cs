using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trace.entity
{
    public class SysConfig
    {
        public string companyName;
        public string companyCode;
        public string workstationNo;
        public string mainBg;
        public string traceUrl;
        public string uploadUrl;
        public string downloadProductsUrl;
        public string checkPermissionUrl;

        public SysConfig()
        {
            companyName = "";
            companyCode = "";
            workstationNo = "";
            mainBg = "";
            traceUrl = "";
            uploadUrl = "";
            downloadProductsUrl = "";
            checkPermissionUrl = "";
        }
    }
}

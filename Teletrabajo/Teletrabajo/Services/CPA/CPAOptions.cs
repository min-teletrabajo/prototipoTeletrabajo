using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace Teletrabajo.Services.CPA
{
    public class CPAOptions
    {
        public string WSUrl { get; set; }
        public NetworkCredential Credential { get; set; }
    }
}

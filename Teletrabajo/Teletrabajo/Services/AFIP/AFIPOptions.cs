using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace Teletrabajo.Services.AFIP
{
    public class AFIPOptions
    {
        public string WSUrl { get; set; }
        public NetworkCredential Credential { get; set; }
    }
}

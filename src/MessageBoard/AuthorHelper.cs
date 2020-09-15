using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBoard
{
    public class AuthorHelper
    {
        public string RequesterIp { get; set; }

        public AuthorHelper()
        {
            RequesterIp = string.Empty;
        }
    }
}

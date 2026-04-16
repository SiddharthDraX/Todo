using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoLibrary.Models
{
        public class TodoException : Exception
    {
        public TodoException(string errmsg) : base(errmsg) { }

    }
}



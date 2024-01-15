using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business.CustomExceptions
{
    public class FileLengthException : Exception
    {
        public string Prop { get; set; }
        public FileLengthException()
        {
        }

        public FileLengthException(string ex, string? message) : base(message)
        {
            Prop = ex;

        }
    }
}

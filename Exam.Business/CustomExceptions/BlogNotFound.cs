using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business.CustomExceptions
{
    public class BlogNotFound : Exception
    {
        public string Prop { get; set; }
        public BlogNotFound()
        {
        }

        public BlogNotFound(string ex, string? message) : base(message)
        {
            Prop = ex;

        }
    }
}

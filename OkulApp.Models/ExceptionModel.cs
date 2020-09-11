using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulApp.Models
{
   public class ExceptionModel
    {
        public int ExceptionId { get; set; }
        public string Message { get; set; }
        public DateTime Tarih { get; set; }
        public string StackTrace { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsekTechnicalTest.Models
{

    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Error { get; set; }
    }

    public class ApiResponse<T> : ApiResponse
    {
        public T Value { get; set; }
    }
}

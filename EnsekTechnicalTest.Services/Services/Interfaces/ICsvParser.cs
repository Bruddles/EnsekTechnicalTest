using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsekTechnicalTest.Services.Services.Interfaces
{
    public interface ICsvParser<T>
    {
        public List<T> Parse(StreamReader streamReader);
    }
}

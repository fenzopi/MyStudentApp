using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStudentApp
{
    public interface IStatistics
    {
        double CalculateClassAverage();
        Student GetStudentWithHighestAverage();
        Student GetStudentWithLowestAverage();
    }
}

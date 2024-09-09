using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentConsoleApplication.Strategies
{
    public interface ITollFeeStrategy
    {
        decimal CalcukateTollFee(decimal distance);
    }
}

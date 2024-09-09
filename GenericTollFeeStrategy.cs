using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentConsoleApplication.Strategies
{
    public class GenericTollFeeStrategy : ITollFeeStrategy
    {
        private readonly decimal _ratePerKm;

        public GenericTollFeeStrategy(decimal ratePerKm)
        {
            _ratePerKm = ratePerKm;
        }
        public decimal CalcukateTollFee(decimal distance)
        {
            return distance * _ratePerKm;
        }
    }
}

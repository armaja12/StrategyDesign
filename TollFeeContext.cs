using AssessmentConsoleApplication.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentConsoleApplication.Context
{
    public class TollFeeContext
    {
        private readonly ITollFeeStrategy _tollFeeStrategy;
        private readonly bool _isETCPayment;

        public TollFeeContext(ITollFeeStrategy tollFeeStrategy, bool isETCPayment)
        {
            _tollFeeStrategy = tollFeeStrategy;
            _isETCPayment = isETCPayment;
        }

        public decimal CalculateTollFee(decimal distance)
        {
            decimal baseTollFee = _tollFeeStrategy.CalcukateTollFee(distance);
            if (_isETCPayment)
            {
              baseTollFee = ApplyETCDiscount(baseTollFee);
            }

            return baseTollFee;
        }

        private decimal ApplyETCDiscount(decimal tollFee)
        {
            decimal discount = tollFee * 0.01m;
            discount = discount > 20 ? 20 : discount;
            return tollFee - discount;
        }
    }
}

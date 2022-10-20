using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doughnut.Domain.Util
{
    public enum SelectionSteps : byte
    {
        DoIWantADoughnut = 0,
        WantADoughnut = 1,
        DoNotWantADoughnut = 2,
        DeserveIt = 3,
        DoNotDeserveIt = 4,
        AmSure = 5,
        AmNotSure = 6,
        ItIsAGoodDoughnut = 7,
        ItIsNotAGoodDoughnut = 8
    }
}

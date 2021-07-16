using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Lesson1
{
    class SortByDepartureTime : IComparer<Train>
    {
        public int Compare(Train x, Train y)
        {
            return x.departureTime.CompareTo(y.departureTime);
        }
    }
}

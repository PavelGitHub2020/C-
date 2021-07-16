using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Lesson1
{
    class SortByDestinationName : IComparer<Train>
    {
        public int Compare( Train x,  Train y)
        {
            if (x.destinationName.Equals(y.destinationName))
                return x.departureTime.CompareTo(y.departureTime);

            return x.destinationName.CompareTo(y.destinationName);
        }
    }
}

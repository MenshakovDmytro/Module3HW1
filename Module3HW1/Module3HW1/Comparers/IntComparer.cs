using System;
using System.Collections;

namespace Module3HW1.Comparers
{
    public class IntComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            var firstItem = (int)x;
            var secondItem = (int)y;
            return firstItem.CompareTo(secondItem);
        }
    }
}
using System.Collections;

namespace Module3HW1.Comparers
{
    public class StringComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            var firstItem = x as string;
            var secondItem = y as string;
            return firstItem.CompareTo(secondItem);
        }
    }
}
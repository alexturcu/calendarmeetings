namespace calendar
{
    public static class StringExtensions
    {
        public static bool IsGreaterThan(this string first, string second)
        {
            return first.CompareTo(second) > 0;
        }

        public static string GetGreater(this string first, string second)
        {
            return first.IsGreaterThan(second) ? first : second;
        }

        public static bool IsLessThan(this string first, string second)
        {
            return first.CompareTo(second) < 0;
        }

        public static string GetLesser(this string first, string second)
        {
            return first.IsLessThan(second) ? first : second;
        }
    }
}
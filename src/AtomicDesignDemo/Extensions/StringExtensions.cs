namespace AtomicDesignDemo.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNotNullOrEmpty(this string source)
        {
            return !string.IsNullOrEmpty(source);
        }
    }
}

namespace LA3
{
    public class Functions
    {
        internal static bool IsPosDbl(string txt)
        {
            double d;
            if (!double.TryParse(txt, out d)) return false;

            return (d >= 0);
        }
        internal static bool IsDbl(string txt)
        {
            double d;
            return double.TryParse(txt, out d);
        }
    }
}

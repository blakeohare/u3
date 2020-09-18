namespace U3
{
    internal class Util
    {
        internal static string TextToBase64(string value)
        {
            return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(value));
        }
    }
}

using System.Windows.Media;

namespace NxShort.Helpers
{
    public static class ColorFactory
    {
        public static Color FromHex(string hexCode)
        {
            return (Color)ColorConverter.ConvertFromString(hexCode);
        }
    }
}

using System.IO;

namespace FormsApp.PascalCase
{
    public static class CharExtensions
    {
        public static char ReadChar(this StringReader reader) => (char) reader.Read();
        public static bool IsUpperOrDigit(this char ch) => char.IsUpper(ch) || char.IsDigit(ch);
    }
}
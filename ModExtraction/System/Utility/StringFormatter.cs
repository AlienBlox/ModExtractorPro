using System.IO;

namespace ModExtractorPro.ModExtraction.System.Utility
{
    /// <summary>
    /// Formats strings
    /// </summary>
    public static partial class StringFormatter
    {
        /// <summary>
        /// Gets the file extension of this string
        /// </summary>
        /// <param name="String">The string</param>
        /// <returns>The filename extension</returns>
        #nullable enable
        public static string? GetExt(this string String)
        {
            return Path.GetExtension(String);
        }
        /// <summary>
        /// Gets the path of the file
        /// </summary>
        /// <param name="String">The string</param>
        /// <returns>The file path</returns>
        public static string ToFileP(this string String)
        {
            String.GetPositionReverse('\\', out int pos);

            return String.Replace("/", "\\")[..pos];
        }
        /// <summary>
        /// Gets the position of this string in reverse
        /// </summary>
        /// <param name="S">The string</param>
        /// <param name="C">The character to find</param>
        /// <param name="Pos">The final position in the string</param>
        public static void GetPositionReverse(this string S, char C, out int Pos)
        {
            Pos = 0;

            for (int i = 0; i < S.Length; i++)
            {
                if (S[^i] == C)
                {
                    Pos = S.Length - i;

                    return;
                }
            }
        }
    }
}
using System;

namespace ModExtractorPro
{
    public static partial class CompareStuff
    {
        /// <summary>
        /// Compares arrays
        /// </summary>
        /// <typeparam name="T">The array type to compare</typeparam>
        /// <param name="array">The array</param>
        /// <param name="compare">The object to compare</param>
        /// <param name="Result">The final result</param>
        public static void CompareItems<T>(Array array, object compare, out bool Result)
        {
            Result = false;

            T[] arrayCompare = (T[])array;

            foreach (object O in arrayCompare)
            {
                if (compare == O)
                {
                    Result = false;
                }
                else
                {
                    Result = false;

                    return;
                }
            }            
        }
    }
}
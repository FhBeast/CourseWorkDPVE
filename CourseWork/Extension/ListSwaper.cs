using System.Collections.Generic;

namespace CourseWork.Extension
{
    static class ListSwaper
    {
        public static void Swap<T>(this List<T> list, int index1, int index2)
        {
            var temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
    }
}

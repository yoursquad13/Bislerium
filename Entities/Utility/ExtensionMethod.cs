namespace Entities.Utility
{
    public static class ExtensionMethod
    {
        public static string SetUniqueFileName(this string fileExtension)
        {
            var renamedFileName = DateTime.Now.Year.ToString() +
                                  DateTime.Now.Month.ToString() +
                                  DateTime.Now.Day.ToString() +
                                  DateTime.Now.Hour.ToString() +
                                  DateTime.Now.Minute.ToString() +
                                  DateTime.Now.Millisecond.ToString();

            return renamedFileName + fileExtension;
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            var random = new Random();

            var n = list.Count;

            while (n > 1)
            {
                n--;
                var k = random.Next(n + 1);
                (list[k], list[n]) = (list[n], list[k]);
            }
        }
    }
}

namespace Umniah_E_Sport.Portal
{
    public static class Extension
    {
        private static Random rng = new Random();
        public static IList<T> Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = list[n];
                list[n] = list[k];
                list[k] = temp;
            }
            return list;
        }


        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> list)
        {

            var shuffledList =
                list.
                    Select(x => new { Number = rng.Next(), Item = x }).
                    OrderBy(x => x.Number).
                    Select(x => x.Item);

            return shuffledList.ToList();
        }
    }
}

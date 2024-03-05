#pragma warning disable S2583 // Conditionally executed code should be reachable
#pragma warning disable S6608 // Prefer indexing instead of "Enumerable" methods on types implementing "IList"
namespace task_BaD24
{
    internal class TestBaD24
    {
        private readonly List<int> listInt;
        public List<int> GetList { get => listInt; }
        public int ListMax { get; private set; }
        public int ListMin { get; private set; }
        public double ListAvg { get; private set; }
        public double Mediana { get => GetMediana(); }

        public TestBaD24(List<int> _listInt)
        {
            listInt = new List<int>(_listInt);
            if (listInt.Count > 0)
            {
                ListMin = listInt.Min();
                ListMax = listInt.Max();
                ListAvg = listInt.Average();
            }
        }

        private double GetMediana()
        {
            var _listInt = new List<int>(listInt);
            _listInt.Sort();

            if ((_listInt.Count % 2) == 0)
            {
                int index2 = _listInt.Count / 2;
                int index1 = index2 - 1;
                return (double)(_listInt[index1] + _listInt[index2]) / 2;
            }
            else
            {
                int index = _listInt.Count / 2;
                return (double)(_listInt[index]);
            }
        }

        public List<int> GetIncrSeq()
        {
            var incrSeq = new List<int>();
            var tmpSeq = new List<int>();

            foreach (int itemList in listInt)
            {
                if (tmpSeq.Count == 0 || tmpSeq.Last() <= itemList)
                {
                    tmpSeq.Add(itemList);
                }
                else if (tmpSeq.Count >= incrSeq.Count)
                {
                    incrSeq = tmpSeq;
                    tmpSeq = new List<int> { itemList };
                }
                else
                {
                    tmpSeq = new List<int> { itemList };
                }
            }

            return incrSeq;
        }

        public List<int> GetDecrSeq()
        {
            var decrSeq = new List<int>();
            var tmpSeq = new List<int>();

            foreach (int itemList in listInt)
            {
                if (tmpSeq.Count == 0 || tmpSeq.Last() >= itemList)
                {
                    tmpSeq.Add(itemList);
                }
                else if (tmpSeq.Count >= decrSeq.Count)
                {
                    decrSeq = tmpSeq;
                    tmpSeq = new List<int> { itemList };
                }
                else
                {
                    tmpSeq = new List<int> { itemList };
                }
            }

            return decrSeq;
        }
    }
}

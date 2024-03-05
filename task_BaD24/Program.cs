#pragma warning disable S2583 // Conditionally executed code should be reachable
#pragma warning disable S6561 // Avoid using "DateTime.Now" for benchmarking or timing operations
namespace task_BaD24
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(
                "------------------------------------------- \n" +
                "  Test task for PortaOne BaD_2024 program.\n" +
                "  Write by Vitalii Udod. \n" +
                "-------------------------------------------");

            DateTime start = DateTime.Now;
            var testList = new TestBaD24(new List<int>());
            
            /// Reading data_file
            if (args.Length > 0)
            {
                Console.Write($"Reading file: {args[0]}\t");
                var listInt = new List<int>(GetListInt(args[0]));
                if (listInt.Count > 0)
                {
                    testList = new TestBaD24(listInt);
                    Console.WriteLine($"\nElements: {testList.GetList.Count:N0}");
                }
            }
            else
            {
                Console.WriteLine(" No datafile! \n    USAGE: \n\ttask_BaD24 <int_list_file.txt> \n\nFor example: \n\ttask_BaD24 10m.txt \n");
            }
            
            /// if listInt != 0 :
            if (testList.GetList.Count > 0)
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine(
                    $"1. Int Max: {testList.ListMax} \n" +
                    $"2. Int Min: {testList.ListMin} \n" +
                    $"3. Mediana: {testList.Mediana} \n" +
                    $"4. Avarage: {testList.ListAvg:F2} \n" +
                    $"5. INCREASES_sequence: {GetListString(testList.GetIncrSeq())} \n" +
                    $"6. DECREASING_sequence: {GetListString(testList.GetDecrSeq())}"
                    );
                Console.WriteLine("-------------------------------------------");

                TimeSpan stop = DateTime.Now - start;
                Console.WriteLine($"Total time, sec: {stop.TotalSeconds:f4}");
            }
        }

        static List<int> GetListInt(string fileName)
        {
            var intList = new List<int>();
            var dataFile = new FileInfo(fileName);
            try
            {
                using (StreamReader sr = dataFile.OpenText())
                {
                    string dataStr = sr.ReadToEnd();
                    List<string> strList = dataStr.Trim().Split("\n").ToList();
                    foreach (string str in strList)
                        if (str != "" || str != " ")
                            intList.Add(int.Parse(str));
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"ERROR! \n{ex.Message}");
                ///throw new FileNotFoundException(ex.Message);
                return new List<int>();
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"ERROR! \nBad data in file: {fileName} \n{ex.Message}");
                ///throw new FormatException(ex.Message);
                return new List<int>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR! \n" + ex.Message);
                return new List<int>();
            }

            return intList;
        }

        static string GetListString(List<int> intList)
        {
            return string.Join(" ", intList.Select(x => x.ToString()).ToList());
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace LazyEvaluation.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var lazyEvaluationEfficiencyTest = new LazyEvaluationEfficiencyTest();

            foreach (var item in lazyEvaluationEfficiencyTest.WithYieldReturn())
            {
                if (item == 10) break;
            }

            foreach (var item in lazyEvaluationEfficiencyTest.WithoutYieldReturn())
            {
                if (item == 10) break;
            }

        }
    }

    internal class LazyEvaluationEfficiencyTest
    {
        private int ThisWillTakeForever(int input)
        {
            Thread.Sleep(1000);

            return input;
        }

        public IEnumerable<int> WithoutYieldReturn()
        {
            List<int> list = new List<int>();

            for (int i = 0; i < 1000000; i++)
            {
                list.Add(ThisWillTakeForever(i));
            }
            return list;
        }

        public IEnumerable<int> WithYieldReturn()
        {
            for (int i = 0; i < 1000000; i++)
            {
                yield return ThisWillTakeForever(i);
            }
           
        }
    }
}

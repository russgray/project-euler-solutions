﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    /// <summary>
    /// Each new term in the Fibonacci sequence is generated by adding the 
    /// previous two terms. By starting with 1 and 2, the first 10 terms 
    /// will be:
    /// 
    /// 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
    /// 
    /// Find the sum of all the even-valued terms in the sequence which do 
    /// not exceed four million.
    /// </summary>
    public class Euler02 : IEulerProblem
    {
        private IEnumerable<ulong> Fibs()
        {
            ulong a = 0, b = 1;

            while (true)
            {
                yield return b;

                b = a + b;
                a = b - a;
            }
        }

        #region IEulerProblem Members

        public void Solve()
        {
            Console.WriteLine(GetType() + ": " + LinqSolver());
            //Console.WriteLine(GetType() + ": " + LinqSolver2());
        }

        #endregion

        private ulong LinqSolver()
        {
            return (from f in Fibs().TakeWhile(f => f < 4000000)
                    where f%2 == 0
                    select f).Sum();
        }

        private ulong LinqSolver2()
        {
            return Fibs().TakeWhile(f => f < 4000000).Where(f => f%2 == 0).Sum();
        }

        private ulong LoopSolver()
        {
            return 0L;
        }
    }
}
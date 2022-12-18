using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] m = new double[3] { 20, 40, 60 };
            double[] q = new double[3] { 10, 18, 30 };
            double p12 = 1, p13 = -1, p23 = -1;

            double[] pcp = new double[3];

            pcp[0] = (Math.Pow(q[1],2) - p12 * q[0] * q[1] - p13 * q[0] * q[2]) /
                (Math.Pow(q[0],2) + Math.Pow(q[1],2) - 2 * p13 * q[0] * q[1] 
                + Math.Pow(q[0],2) + Math.Pow(q[2],2) - 2 * p13 * q[0] * q[2]);

            pcp[1] = (Math.Pow(q[0], 2) - p12 * q[0] * q[1] - p23 * q[1] * q[2]) /
               (2*Math.Pow(q[1], 2) + Math.Pow(q[0], 2) - 2 * p12 * q[0] * q[1] +
                Math.Pow(q[1],2) + Math.Pow(q[2],2) - 2 * p23 * q[2] * q[1]);

            pcp[2] = 1 - (pcp[0] + pcp[1]);

            Console.WriteLine("Структура ПЦП:");

            for (int i = 0; i < pcp.Length; i++)
            Console.WriteLine(pcp[i]);


            Console.WriteLine();
            double mp = pcp[0] * m[0] + pcp[1] * m[1] + pcp[2] * m[2];
            Console.WriteLine($"mp = {mp}%");
            
            double qp = Math.Pow(pcp[0], 2) * Math.Pow(q[0], 2) + Math.Pow(pcp[1], 2) * Math.Pow(q[1], 2)
                        + Math.Pow(pcp[2], 2) * Math.Pow(q[2], 2) + 2 * pcp[0] * pcp[1] * q[0] * q[1] * p12
                        + 2 * pcp[0] * pcp[2] * q[0] * q[2] * p13 + 2 * pcp[1] * pcp[2] * q[1] * q[2] * p23;
            qp = Math.Sqrt(qp);
            Console.WriteLine($"qp = {qp}%");
            
            Console.ReadKey();
        }
    }
}

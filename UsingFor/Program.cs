using System;
using System.Diagnostics;
// Debug.Assert() 偵測邊界值錯誤
namespace UsingFor
{
    class Program
    {
        static void Main(string[] args)
        {

            // // 01_計算1加到100
            // int sum = 0;
            // for (int i = 1; i <= 100; i++)
            // {
            //     sum += i;
            // }

            // Console.WriteLine("1~100的加總=" + sum);
            // // 1~100的加總=4950 XX
            // // 1~100的加總=5050

            // // 02_計算1到100的偶數和
            // int sumEven = 0;
            // for (int i = 0; i <= 100; i += 2)
            // {
            //     sumEven += i;
            // }

            // Console.WriteLine("1~100的偶數和=" + sumEven);
            // // 1~100的偶數和=2450
            // // 1~100的偶數和=2550
            // // i必須是從0開始，初始i若是1會被納入計算，1無法被2整除


            // // 03_Debug.Assert() 偵測邊界值錯誤
            // int i;
            // int sumTest = 0;

            // Debug.Assert(sumTest == 0);
            // for (i = 1; i < 100; ++i)
            // {
            //     sumTest += i;
            // }
            // Debug.Assert(i == 101);
            // // i==101就會跳出來

            // 04_九九乘法表_Mtable
            int i;
            int j;

            // Array MTable = [i, j];
            // XX no need for Array

            int MVaule = 0;

            for (i = 1; i <= 9; i++)
            {
                for (j = 1; j <= 9; j++)
                {
                    MVaule = i * j;
                    // MVaule += i*j; -> XX MVaule will change
                    // Console.WriteLine(MVaule);
                    Console.WriteLine($"{i}x{j}={MVaule}");
                    // forget ${} -> search
                }
                // Console.WriteLine(MVaule); -> start from 9
            }

            // // 05_1加到100的while寫法
            // int sum = 0;
            // int i = 1;
            // while (i <= 100)
            // {
            //     sum + -i;
            //     ++i;
            // }
            // Console.WriteLine("1~100的加總等於" + sum);

            // // 06_1加到100的do-while寫法
            // int sum = 0;
            // int i = 1;

            // do
            // {
            //     sum += i;
            //     ++i;
            // } while (i <= 100);

            // Console.WriteLine("1~100的加總等於" + sum);


            // // 07_前10組畢氏數
            // int x;
            // int y;
            // int z;
            // int n = 0;

            // for (x = 1; x <= 100; ++x)
            // {
            //     for (y = x; y <= 100; ++y)
            //     {
            //         for (z = 1; z <= 150; ++z)
            //         {
            //             if (x * x + y * y == z * z)
            //             {
            //                 ++n;
            //                 if (n <= 10)
            //                 {
            //                     Console.WriteLine(
            //                     "{0}: {1}*{1} + {2}*{2} = {3}*{3}",
            //                     n, x, y, z);
            //                 }
            //             }
            //         }
            //     }
            // }


        }
    }
}

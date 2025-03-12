namespace Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //задание 1

            //int[] fibonacci = new int[8];
            //fibonacci[0] = 0;
            //fibonacci[1] = 1;
            //for (int i = 2; i < fibonacci.Length; i++)
            //{
            //    fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
            //}
            //Console.WriteLine(string.Join(", ", fibonacci));


            //задание 2

            //string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };



            //задание 3 

            //int[,] matrix = new int[3, 3];
            //for (int i = 0; i < 3; i++)
            //{
            //    for (int j = 0; j < 3; j++)
            //    {
            //        matrix[i, j] = (int)Math.Pow(j + 2, i + 1);
            //    }
            //}
            //for (int i = 0; i < 3; i++)
            //{
            //    for (int j = 0; j < 3; j++)
            //    {
            //        Console.Write(matrix[i, j] + "\t");
            //    }
            //    Console.WriteLine();



            //задание 4

            //double[][] jaggedArray = new double[3][];
            //jaggedArray[0] = new double[] { 1, 2, 3, 4, 5 };
            //jaggedArray[1] = new double[] { Math.E, Math.PI };
            //jaggedArray[2] = new double[] { Math.Log10(1), Math.Log10(10), Math.Log10(100), Math.Log10(1000) };
            //for (int i = 0; i < jaggedArray.Length; i++)
            //{
            //    Console.Write("Массив " + (i + 1) + ": ");
            //    foreach (double num in jaggedArray[i])
            //    {
            //        Console.Write(num + "\t");
            //    }
            //    Console.WriteLine();

            //задание 4 Б

            //int[] array = { 1, 2, 3, 4, 5 };
            //int[] array2 = { 7, 8, 9, 10, 11, 12, 13 };
            //double[][] jaggedArray = new double[3][];
            //jaggedArray[0] = Array.ConvertAll(array, x => (double)x);
            //jaggedArray[1] = new double[] { Math.E, Math.PI };
            //jaggedArray[2] = new double[4];
            //for (int i = 0; i < 4; i++)
            //{
            //    jaggedArray[2][i] = Math.Log10(array2[i]);
            //}
            //for (int i = 0; i < jaggedArray.Length; i++)
            //{
            //    Console.Write("Массив " + (i + 1) + ": ");
            //    foreach (double num in jaggedArray[i])
            //    {
            //        Console.Write(num + "\t");
            //    }
            //    Console.WriteLine();



            //задание 5

            //int[] fibonacci = new int[8];
            //fibonacci[0] = 0;
            //fibonacci[1] = 1;
            //for (int i = 2; i < fibonacci.Length; i++)
            //{
            //    fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
            //}
            //Console.WriteLine("Fibonacci: " + string.Join(", ", fibonacci));
            //string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            //string[] fibonacciAsString = fibonacci.Take(3).Select(num => num.ToString()).ToArray();
            //Array.Copy(fibonacciAsString, 0, months, 0, 3);
            //Console.WriteLine("Updated months array: " + string.Join(", ", months));


            //задание 6

            //int[] fibonacci = new int[8];
            //fibonacci[0] = 0;
            //fibonacci[1] = 1;
            //for (int i = 2; i < fibonacci.Length; i++)
            //{
            //    fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
            //}
            //Console.WriteLine("Original fibonacci array:");
            //Console.WriteLine(string.Join(", ", fibonacci));
            //Array.Resize(ref fibonacci, fibonacci.Length * 2);
            //for (int i = 8; i < fibonacci.Length; i++)
            //{
            //    fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
            //}
            //Console.WriteLine("\nResized fibonacci array:");
            //Console.WriteLine(string.Join(", ", fibonacci));

        }
        }
    }



 

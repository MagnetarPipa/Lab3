using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    //Варіант 18: 
    //993 1000 902 939 1000 
    internal class Program
    {
        static void Task902()
        {
            /*Такого задания не существует в файле*/
         
        }

        static void Task939()
        {
            /*939.Известен номер столбца, на котором расположен элемент побочной диагонали массива.
            * Вывести на экран значение этого элемента.*/
            Console.WriteLine("Задание 939");

            Random rnd = new Random();

            int size = 5;
            int number_of_column = rnd.Next(0, size);
            int[,] newArr = new int[size, size];

            Console.WriteLine("Массив:");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    newArr[i, j] = rnd.Next(0, 10);
                    Console.Write(newArr[i, j] + "\t");

                }
                Console.WriteLine();
            }
            Console.WriteLine("Номер столбца " + number_of_column);
            if (number_of_column >= 0 && number_of_column < size)
            {
                int value = newArr[size - number_of_column - 1, number_of_column];
                Console.WriteLine($"Значение элемента в столбце {number_of_column} побочной диагонали: {value}");
            }
            else
            {
                Console.WriteLine($"Столбец {number_of_column} находится за пределами массива.");
            }

            Console.WriteLine("Побочная диагональ массива:");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i + j == size - 1)
                    {
                        Console.Write(newArr[i, j] + "");
                    }
                    else
                    {
                        Console.Write("* ");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("Конец 939");
        }
        static void Task993()
        {
            /*Дана целочисленная квадратная матрица.
            * Найти в каждой строке наибольший элемент и поменять его местами с элементом главной диагонали.*/
            Console.WriteLine("\nНачало задания 993");
            Random rnd = new Random();

            int size = 5;
            int[,] array = new int[size, size];
            Console.WriteLine("Массив:");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    array[i, j] = rnd.Next(0, 10);
                    Console.Write(array[i, j] + "\t");

                }
                Console.WriteLine();
            }

            for (int y = 0; y < size; y++)
            {
                int max = int.MinValue;
                int maxInRowIndex = -1;
                for (int x = 0; x < size; x++)
                {
                   

                    if (array[y, x] > max)
                    {
                        max = array[y, x];
                        maxInRowIndex = x;
                    }

                }
                int temp = array[y, y];
                array[y, y] = max;
                array[y, maxInRowIndex] = temp;
            }

            Console.WriteLine("Измененный Массив:");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Конец задания 933");
        }

        static void Task1000()
        {
            /*1000.Дана вещественная квадратная матрица порядка n(n — нечетное), все элементы которой различны.
             * Найти наибольший элемент среди стоящих на главной и побочной диагоналях и поменять его местами с элементом,
             * стоящим на пересечении этих диагоналей.*/
            Console.WriteLine("\nНачало задания 1000");
            Random rnd = new Random();
            int size = 9;
            double num = 0;
            double[,] array = new double[size, size];
            
            Console.WriteLine("Массив:");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                   
                    num=Math.Round(rnd.NextDouble() * 20 - 10, 2);
                    for(int r = -1; r < i; r++)
                    {
                        for(int c = -1; c < j; c++)
                        {
                            if (num == array[r+1, c+1])
                            {
                                r = -1;
                                c = -1;
                           
                                num = Math.Round(rnd.NextDouble() * 20 - 10, 2);
                            }
                        }
                    }
                    array[i, j] = num;
                    Console.Write(array[i, j] + "\t");
                
                }
                Console.WriteLine();
            }

            
            double maxElement = array[0,0];
            int rows=0;
            int colums=0;

            for (int i = 0; i < size; i++)
            {
                if (array[i, i] > maxElement)
                {
                    maxElement = array[i, i];
                    rows = i;
                    colums = i;
                }

                if (array[i, size - 1 - i] > maxElement)
                {
                    maxElement = array[i, size - 1 - i];
                    rows = i;
                    colums = size-1-i;
                }
            }

            Console.WriteLine("Максимальный элемент=" + maxElement);

            int diagonalIntersectionRow = size / 2;
            int diagonalIntersectionColumn = size / 2;

            Console.WriteLine("Место где пересекается диагонали в строке="+diagonalIntersectionRow+" Место где пересекается диагонали в столбце="+diagonalIntersectionColumn);


            double temp = array[diagonalIntersectionRow, diagonalIntersectionColumn];
            array[rows, colums] = temp;
            array[diagonalIntersectionRow, diagonalIntersectionColumn] = maxElement;


       
            Console.WriteLine("Измененный Массив:");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {

                    Console.Write(array[i, j] + "\t");

                }
                Console.WriteLine();
            }
            Console.WriteLine("Конец задания 1000");
        }



        static void Main(string[] args)
        {

              //Task902();//В файле такого задания не существует
              Task939();
              Task993();
              Task1000();//Задание дублируется 
            
            Console.ReadLine();
        }
    }
}

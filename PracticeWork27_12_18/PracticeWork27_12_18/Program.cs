using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeWork27_12_18
{
    class Program
    {
        static void Main(string[] args)
        {
            const int EVEN_NUMBER = 2;
            const int NULL = 0;
            const int NULL_FOR_MULTIPLY = 1;
            const int FIRST_ELEMENT_IN_MASS = 0;
            const int MAX_RANDOM_NUMBER = 100;
            const int FIRST_MAS_MAX_SIZE = 5;
            const int SECOND_MAS_MAX_ROW_SIZE = 3;
            const int SECOND_MAS_MAX_COLUMN_SIZE = 4;

            int[] integerNumbers = new int[FIRST_MAS_MAX_SIZE];
            double[,] doubleNumbers = new double[SECOND_MAS_MAX_ROW_SIZE, SECOND_MAS_MAX_COLUMN_SIZE];

            for(int i = 0; i < FIRST_MAS_MAX_SIZE; i++)
            {
                Console.Write($"Set {i} number: ");
                integerNumbers[i] = int.Parse(Console.ReadLine());
            }

            Random randomNumber = new Random();
            for(int i = 0; i < SECOND_MAS_MAX_ROW_SIZE; i++)
            {
                for(int j = 0; j < SECOND_MAS_MAX_COLUMN_SIZE; j++)
                {
                    doubleNumbers[i, j] = randomNumber.Next(MAX_RANDOM_NUMBER);
                }
            }
            Console.WriteLine("-----------------------------");


            Console.WriteLine("1 Demension massive");
            for(int i = 0; i < FIRST_MAS_MAX_SIZE; i++)
            {
                Console.Write(integerNumbers[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("-----------------------------");


            Console.WriteLine("2 Demension massive");
            for(int i = 0; i < SECOND_MAS_MAX_ROW_SIZE; i++)
            {
                for(int j = 0; j < SECOND_MAS_MAX_COLUMN_SIZE; j++)
                {
                    Console.Write(doubleNumbers[i, j] + " ");
                }
                Console.WriteLine();
            }

            int minimalNumberInIntegerArray = integerNumbers[FIRST_ELEMENT_IN_MASS], maximalNumberInIntegerArray = integerNumbers[FIRST_ELEMENT_IN_MASS];
            double minimalNumberInDoubleArray = doubleNumbers[FIRST_ELEMENT_IN_MASS, FIRST_ELEMENT_IN_MASS], maximalNumberInDoubleArray = doubleNumbers[FIRST_ELEMENT_IN_MASS, FIRST_ELEMENT_IN_MASS];
            int sumNumberInIntegerArray = NULL, multiplyNumberInIntegerArray = NULL_FOR_MULTIPLY, sumOfEvenElementsInIntegerArray = NULL;
            double sumNumberInDoubleArray = NULL, multiplyNumberInDoubleArray = NULL_FOR_MULTIPLY, sumOfEvenColumnInDoubleArray = NULL;

            for (int i = 0; i < integerNumbers.Length; i++)
            {
                if(i % EVEN_NUMBER == NULL)
                {
                    sumOfEvenElementsInIntegerArray += integerNumbers[i];
                }
                if(integerNumbers[i] < minimalNumberInIntegerArray)
                {
                    minimalNumberInIntegerArray = integerNumbers[i];
                }
                if(integerNumbers[i] > maximalNumberInIntegerArray)
                {
                    maximalNumberInIntegerArray = integerNumbers[i];
                }
                sumNumberInIntegerArray += integerNumbers[i];
                multiplyNumberInIntegerArray *= integerNumbers[i];
            }

            for(int i = 0; i < SECOND_MAS_MAX_ROW_SIZE; i++)
            {
                for(int j = 0; j < SECOND_MAS_MAX_COLUMN_SIZE; j++)
                { 
                    if(j % EVEN_NUMBER == NULL)
                    {
                        sumOfEvenColumnInDoubleArray += doubleNumbers[i, j];
                    }
                    if(doubleNumbers[i, j] < minimalNumberInDoubleArray)
                    {
                        minimalNumberInDoubleArray = doubleNumbers[i, j];
                    }
                    if(doubleNumbers[i, j] > maximalNumberInDoubleArray)
                    {
                        maximalNumberInDoubleArray = doubleNumbers[i, j];
                    }
                    sumNumberInDoubleArray += doubleNumbers[i, j];
                    multiplyNumberInDoubleArray *= doubleNumbers[i, j];
                }
            }

            Console.WriteLine($"Minimal number in integer array: {minimalNumberInIntegerArray}");
            Console.WriteLine($"Maximal number in integer array: {maximalNumberInIntegerArray}");
            Console.WriteLine($"Sum of all elements in integer array: {sumNumberInIntegerArray}");
            Console.WriteLine($"Multiply of all elements in integer array: {multiplyNumberInIntegerArray}");
            Console.WriteLine($"Sum of even elements in integer array: ");
            Console.WriteLine("-----------------------------");
            Console.WriteLine($"Minimal number in double array: {minimalNumberInDoubleArray}");
            Console.WriteLine($"Maximal number in double array: {maximalNumberInDoubleArray}");
            Console.WriteLine($"Sum of all elements in double array: {sumNumberInDoubleArray}");
            Console.WriteLine($"Multiply of all elements in double array: {multiplyNumberInDoubleArray}");
            Console.WriteLine($"Sum of even column elements in integer array: ");
            Console.WriteLine("-----------------------------");

            Console.ReadLine();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace FactorialAndFibonacciLINQ
{
    class Program
    {
        static void Main()
        {
            string userInput;
            bool run = true;
            while (run)
            {
                Console.Clear();
                Console.Write(@"1. Find Factorial
2. Find Fibonacci
3. Models with enum
4. Arrays with numbers
5. Exit
Select action: ");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        {
                            Console.Clear();
                            Console.Write(@"Find Factorial
Input number: ");
                            userInput = Console.ReadLine();
                            if (Int32.TryParse(userInput, out int result))
                            {
                                Console.WriteLine($@"{result}! = {Factorial(result)}");
                            }
                            else
                            {
                                Console.WriteLine("Your number is invalid");
                            }
                            WaitUser();
                            continue;
                        }
                    case "2":
                        {
                            Console.Clear();
                            Console.Write(@"Number Fibonacci
Input number: ");
                            userInput = Console.ReadLine();
                            if (Int32.TryParse(userInput, out int result2))
                            {
                                var numbers = Fibonacci(result2);
                                foreach (var item in numbers)
                                {
                                    Console.WriteLine(item);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Your number is invalid");
                            }
                            WaitUser();
                            continue;
                        }
                    case "3":
                        {
                            Console.Clear();
                            var phones = GetModelCollection();
                            Console.WriteLine("All phones:");
                            foreach (var item in phones)
                            {
                                Console.WriteLine(item.ToString());
                            }
                            WaitUser("Press any key to sort phones... ");
                            Console.WriteLine("\nPhones where color is black");
                            var query = phones.Where(x => x.Color == Color.Black);
                            foreach (var item in query)
                            {
                                Console.WriteLine(item.ToString());
                            }
                            WaitUser();
                            continue;
                        }
                    case "4":
                        {
                            Console.Clear();
                            Console.Write("Grouping with LINQ \nInput array size: ");
                            userInput = Console.ReadLine();
                            if (Int32.TryParse(userInput, out int arraySize))
                            {
                                int[] array = GetArray(arraySize);
                                ShowArray(array, "Array:");
                                WaitUser("Press any key to grouping array");
                                var sortedArray = array.Where(x => x % 2 == 0); // Even numbers
                                ShowArray(sortedArray, "Even numbers");
                                sortedArray = array.Where(x => x % 2 == 1); // Not even numbers
                                ShowArray(sortedArray, "Not even numbers");
                            }
                            else
                            {
                                Console.WriteLine("Your input is invalid");
                            }
                            WaitUser();
                            continue;
                        }
                    case "5":
                        {
                            run = false;
                            break;
                        }
                    default:
                        continue;
                }
            }
        }
        public static int Factorial(int number)
        {
            if (number == 0)
            {
                return 1;
            }
            int[] numbers = new int[number];
            for (int i = 0; i < number; i++)
            {
                numbers[i] = i + 1;
            }
            var result = numbers.Aggregate((x, y) => x * y);
            return result;
        }
        public static IEnumerable<int> Fibonacci(int n)
        {
            int current = 0;
            int next = 1;
            for (int i = 0; i < n; i++)
            {
                yield return current;
                int temp = next;
                next = current + next;
                current = temp;
            }
        }
        public static List<Phone> GetModelCollection()
        {
            List<Phone> phones = new List<Phone> {
                new Phone{CompanyName = "Apple",Model="SE", Memory = 32,TouchScreen = true, Color = Color.Gray},
                new Phone{CompanyName = "Apple",Model="7", Memory = 64,TouchScreen = true, Color = Color.Black},
                new Phone{CompanyName = "Nokia",Model="X20092", Memory = 1,TouchScreen = false, Color = Color.Yellow},
                new Phone{CompanyName = "Huawei",Model="Nova 2", Memory = 128,TouchScreen = true, Color = Color.Pink},
                new Phone{CompanyName = "HTC",Model="U11", Memory = 128,TouchScreen = true, Color = Color.White},
                new Phone{CompanyName = "Samsung",Model="Galaxy S10", Memory = 256,TouchScreen = true, Color = Color.White},
                new Phone{CompanyName = "Samsung",Model="Galaxy Note 9", Memory = 256,TouchScreen = true, Color = Color.White},
                new Phone{CompanyName = "Apple",Model="X", Memory = 512,TouchScreen = true, Color = Color.Black},
                new Phone{CompanyName = "Xiaomi",Model="Mate X", Memory = 128,TouchScreen = true, Color = Color.Pink},
                new Phone{CompanyName = "ASUS ",Model="ZenFone 5", Memory = 64,TouchScreen = true, Color = Color.Black}
            };
            return phones;
        }
        public static int[] GetArray(int arraySize)
        {
            int[] array = new int[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                array[i] = i;
            }
            return array;
        }
        public static void ShowArray (IEnumerable<int> array, string topLineName)
        {
            Console.WriteLine(topLineName);
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
        public static void WaitUser(string information = "Press any key to continue... ")
        {
            Console.WriteLine(information);
            Console.ReadKey();
        }
    }
}

using System;

namespace Practice
{
    public class Program
    {
        /// <summary>
        /// gfgfdg.
        /// </summary>
        /// <param name="args">aegfsfb.</param>
        public static void Main(string[] args)
        {
                Console.Write("Input N: ");
                int num = Convert.ToInt32(Console.ReadLine());
                Random random = new Random();
                int[] arr1 = new int[num];
                char[] alphabet = "AbcDEfgHIJklmnopqrstuvwxyz".ToCharArray();
                int[] arrOfEven;
                int even = 0;
                int odd = 0;
                int evenCounter = 0;
                for (int i = 0; i < arr1.Length; i++)
                {
                    arr1[i] = random.Next(1, 27);
                    Console.Write(arr1[i] + " ");
                    if (arr1[i] % 2 == 0)
                     {
                        even++;
                     }

                    if (arr1[i] % 2 == 1)
                    {
                    odd++;
                    }
                }

                Console.WriteLine("\n");
                Console.Write("Array of Even numbers: ");
                Console.Write("Array letter of even: ");
                if (even > 0)
                {
                    arrOfEven = new int[even];
                    char[] resultOfEven = new char[arrOfEven.Length];
                    for (int i = 0, k = 0; i < arr1.Length; i++)
                    {
                        if (arr1[i] % 2 == 0)
                        {
                            arrOfEven[k] = arr1[i];
                            Console.Write(arrOfEven[k] + " ");
                            for (int j = 0; j < arrOfEven.Length; j++)
                            {
                                for (int c = 0; c < alphabet.Length; c++)
                                {
                                    if (arrOfEven[j] - 1 == c)
                                    {
                                        resultOfEven[j] = alphabet[c];
                                        if (arrOfEven[j] == 4 || arrOfEven[j] == 8 || arrOfEven[j] == 10)
                                        {
                                            evenCounter++;
                                        }

                                        Console.Write(resultOfEven[j] + " ");
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\n");
                Console.Write("Array of Odd numbers: ");
                Console.Write("Array letter of odd: ");
                if (odd > 0)
                {
                    int[] arrOfOdd = new int[odd];
                    char[] resultOfOdd = new char[arrOfOdd.Length];
                    int oddCounter = 0;
                    for (int i = 0, k = 0; i < arr1.Length; i++)
                    {
                        if (arr1[i] % 2 == 1)
                        {
                            arrOfOdd[k] = arr1[i];
                            Console.Write(arrOfOdd[k] + " ");
                            for (int j = 0; j < arrOfOdd.Length; j++)
                            {
                                for (int c = 0; c < alphabet.Length; c++)
                                {
                                    if (arrOfOdd[j] - 1 == c)
                                    {
                                        resultOfOdd[j] = alphabet[c];
                                        if (arrOfOdd[j] == 1 || arrOfOdd[j] == 5 || arrOfOdd[j] == 9)
                                        {
                                            oddCounter++;
                                        }

                                        Console.Write(resultOfOdd[j] + " ");
                                    }
                                }
                            }
                        }
                    }

                    Console.WriteLine("\n");
                    if (evenCounter > oddCounter)
                    {
                        Console.WriteLine($"More even numbers: {evenCounter}");
                    }
                    else if (oddCounter > evenCounter)
                    {
                        Console.WriteLine($"More odd numbers: {oddCounter}");
                    }
                    else
                    {
                        Console.WriteLine("The same number");
                    }
                }
            }
        }
    }
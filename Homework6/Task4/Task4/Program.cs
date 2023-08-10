using System;
using System.Collections.Generic;
using System.IO;

namespace Task4
{
    class Task4
    {
        static void Main()
        {
            MergeSorting sort = new MergeSorting();

            string path = "C:\\numbers.txt";
            string[] txtFile = File.ReadAllLines(path);

            string choice;

            do
            {
                Console.WriteLine("Выберите способ сортировки:");
                Console.WriteLine("0 - по номеру");
                Console.WriteLine("1 - по имени");

                choice = Console.ReadLine();

                if (choice == "0")
                {
                    Console.Clear();
                    Console.WriteLine("Записи отсортированы по номеру:");

                    List<int> sortByNumber = new List<int>();

                    foreach (string nameAndNumber in txtFile)
                    {
                        for (int i = 0; i < nameAndNumber.Length; i++)
                        {
                            if (char.IsDigit(nameAndNumber[i]))
                            {
                                int digit = int.Parse(nameAndNumber[i].ToString());
                                sortByNumber.Add(digit);
                                break;
                            }
                        }
                    }

                    int left = 0;
                    int right = sortByNumber.Count - 1;
                    sort.MergeSort(sortByNumber, left, right);

                    HashSet<string> newTxtFile = new HashSet<string>();

                    int j = 0;

                    do
                    {
                        if (j >= sortByNumber.Count)
                        {
                            break;
                        }
                        foreach (string nameAndNumber in txtFile)
                        {
                            for (int k = 0; k < nameAndNumber.Length; k++)
                            {
                                if (char.IsDigit(nameAndNumber[k]))
                                {
                                    int number = int.Parse(nameAndNumber[k].ToString());
                                    if (number == sortByNumber[j])
                                    {
                                        newTxtFile.Add(nameAndNumber);
                                        break;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        j++;
                    } while (newTxtFile.Count != txtFile.Length);


                    Console.WriteLine();

                    foreach (string sortedLine in newTxtFile)
                    {
                        Console.WriteLine(sortedLine);
                    }
                }



                if (choice == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Записи отсортированы по имени:");

                    List<int> sortByName = new List<int>();

                    foreach (string nameAndNumber in txtFile)
                    {
                        for (int i = 0; i < nameAndNumber.Length; i++)
                        {
                            if (char.IsLetter(nameAndNumber[i]))
                            {
                                nameAndNumber[i].ToString();
                                sortByName.Add(nameAndNumber[i]);
                                break;
                            }
                        }
                    }

                    int left = 0;
                    int right = sortByName.Count - 1;
                    sort.MergeSort(sortByName, left, right);

                    List<char> sortedLetters = new List<char>();
                    foreach (int letterInUnicode in sortByName)
                    {
                        char character = Convert.ToChar(letterInUnicode);
                        sortedLetters.Add(character);
                    }

                    HashSet<string> newTxtFile = new HashSet<string>();

                    int j = 0;
                    
                    do
                    {
                        if (j >= sortByName.Count)
                        {
                            break;
                        }
                        foreach (string nameAndNumber in txtFile)
                        {
                            for (int k = 0; k < nameAndNumber.Length; k++)
                            {
                                if (char.IsLetter(nameAndNumber[k]))
                                {
                                    if (nameAndNumber[k] == sortedLetters[j])
                                    {
                                        newTxtFile.Add(nameAndNumber);
                                        break;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        j++;

                    } while (newTxtFile.Count != txtFile.Length);

                    Console.WriteLine();

                    foreach (string sortedLine in newTxtFile)
                    {
                        Console.WriteLine(sortedLine);
                    }
                }

            } while (choice != "0" && choice != "1") ;
        }
    }
}

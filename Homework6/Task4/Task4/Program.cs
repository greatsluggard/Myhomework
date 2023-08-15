using System;
using System.Collections.Generic;
using System.IO;

namespace Task4
{
    class Task4
    {
        static void Main()
        {
            MergeSorting <long> sortNumber = new MergeSorting <long> ();
            MergeSorting <string> sortName = new MergeSorting<string> ();

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

                    List<long> numbersList = new List<long>();

                    string phoneFromLine1;
                    int indexForWrite1;

                    long digitForNumbersList;

                    foreach (string line in txtFile)
                    {
                        phoneFromLine1 = "";
                        indexForWrite1 = 0;

                        digitForNumbersList = 0;

                        for (int i = 0; i < line.Length; i++)
                        {
                            if (char.IsDigit(line[i]))
                            {
                                phoneFromLine1 = phoneFromLine1.Insert(indexForWrite1, line[i].ToString());
                                indexForWrite1++;
                            }
                        }

                        long.TryParse(phoneFromLine1, out digitForNumbersList);
                        numbersList.Add(digitForNumbersList);
                    }

                    sortNumber.Sort(numbersList);

                    HashSet<string> newTxtFile = new HashSet<string>();

                    int j = 0;

                    string phoneFromLine2;
                    int indexForWrite2;
                    long digitForCompare;

                    do
                    {
                        foreach (string line in txtFile)
                        {
                            phoneFromLine2 = "";
                            indexForWrite2 = 0;
                            digitForCompare = 0;

                            for (int k = 0; k < line.Length; k++) 
                            {
                                if (char.IsDigit(line[k]))
                                {
                                    phoneFromLine2 = phoneFromLine2.Insert(indexForWrite2, line[k].ToString());
                                    indexForWrite2++;
                                }
                            }

                            long.TryParse(phoneFromLine2, out digitForCompare);

                            if (digitForCompare == numbersList[j])
                            {
                                newTxtFile.Add(line);
                                j++;
                            }
                            if (j >= numbersList.Count)
                            {
                                break;
                            }
                        }
                    } while (newTxtFile.Count != txtFile.Length);

                    Console.WriteLine();

                    foreach (string line in newTxtFile)
                    {
                        Console.WriteLine(line);
                    }
                }


                if (choice == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Записи отсортированы по имени:");

                    List<string> namesList = new List<string>();

                    string nameForNamesList;
                    int indexForWrite1;

                    foreach (string line in txtFile)
                    {
                        nameForNamesList = "";
                        indexForWrite1 = 0;

                        for (int i = 0; i < line.Length; i++)
                        {
                            if (char.IsLetter(line[i]))
                            {
                                nameForNamesList = nameForNamesList.Insert(indexForWrite1, line[i].ToString());
                                indexForWrite1++;
                            }
                        }

                        namesList.Add(nameForNamesList);
                    }

                    sortName.Sort(namesList);

                    HashSet<string> newTxtFile = new HashSet<string>();

                    int j = 0;
                    string nameForCompare;
                    int indexForWrite2;

                    do
                    {
                        foreach (string line in txtFile)
                        {
                            nameForCompare = "";
                            indexForWrite2 = 0;

                            for (int k = 0; k < line.Length; k++)
                            {
                                if (char.IsLetter(line[k]))
                                {
                                    nameForCompare = nameForCompare.Insert(indexForWrite2, line[k].ToString());
                                    indexForWrite2++;
                                }
                            }

                            if (nameForCompare == namesList[j])
                            {
                                newTxtFile.Add(line);
                                j++;
                            }

                            if (j >= namesList.Count)
                            {
                                break;
                            }
                        }

                    } while (newTxtFile.Count != txtFile.Length);

                    Console.WriteLine();

                    foreach (string line in newTxtFile)
                    {
                        Console.WriteLine(line);
                    }
                }

            } while (choice != "0" && choice != "1") ;
        }
    }
}

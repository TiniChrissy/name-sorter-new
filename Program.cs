using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace name_sorter
{
    // This is a simple console application that takes the name of a local text file and sorts each line's name. 
    // It assumes that the last word in each line is the last name. The names are sorted first by last name, then from the name left to right. 
    class Program
    {
        static void Main(string[] args)
        {
            //If number of arguments is not 1, stop execution. 
            if (args.Length != 1)
            {
                Console.WriteLine("Please enter one argument");
                return;
            }

            // If the passed in argument is not the path to a text file, stop execution. 
            if (CheckIfTxtFile(args[0]) == false)
            {
                return;
            }

            var path = args[0];
            string[] lines = File.ReadAllLines(path, Encoding.UTF8); //unit test ,if empty return empty, if sorted, return sroted?? probably don't need that

            // Get names as List of arrays. Each name is an array: ["Beau", "Tristan", "Bentley"]
            List<string[]> lastNameFirst = new List<string[]>();
            var maxNameLength = 0;
            foreach (string line in lines)
            {
                //Console.WriteLine(line);
                var fullName = line.Split(' ');
                var lastName = fullName[fullName.Length - 1];


                var givenames = fullName.Take(fullName.Length - 1);
                string givenNamesOneString = String.Join(" ", givenames);
                //Console.WriteLine(givenNamesOneString);
                var endName = fullName.Skip(fullName.Length - 1);
                var backwards = endName.Concat(givenames);

                //var forwards = givenNamesOneString.Concat(backwards);
                //var forwards = lastName.Concat(new[] { givenNamesOneString }).ToArray();
                //var forwards = [lastName, givenNamesOneString];
                string[] forwards = new string[] { lastName, givenNamesOneString };

                //Console.WriteLine(forwards);
                Console.WriteLine(String.Join("+", forwards));

                lastNameFirst.Add(forwards);
                //lastNameFirst.Add(backwards);

                // Get maximum name length
                if (fullName.Length > maxNameLength)
                {
                    maxNameLength = fullName.Length;
                }

            }
            // Sort by last name
            List<string[]> aaa = lastNameFirst
                .OrderBy(name => name[0])
                .ThenBy(name => name[1])
                .ToList();


            //aaa.Sort((a, b) => a[0].CompareTo(b[0]))/*;*/

            //for (int i = 0; i < 4; i++)
            //{
            //    for (int j = 0;  j < aaa.Count(); j ++)
            //    {

            //    }

            //    foreach (string[] name in aaa)
            //    {

            //    }
            //    Console.WriteLine(CompareStrings(strFirst, strSecond));
            //}
            Console.WriteLine("After sort");

            foreach (string[] name in aaa)
            {
                Console.WriteLine(String.Join(" ", name)); //Print array out as string
            }

            for (int i = 0; i < maxNameLength; i++)
            {
                //Console.WriteLine(i);
                List<string[]> ddd = lastNameFirst.OrderBy(name => name[name.Length - 1]).ToList();
            }

            Boolean CheckIfTxtFile(string fileName)
            {
                //Do error checking, that it ends with .txt test
                if (fileName.Length >= 4)
                {
                    var lastFourChar = fileName.Substring(fileName.Length - 4);

                    if (lastFourChar == ".txt")
                    {
                        Console.WriteLine("This is a .txt file");
                        return true;
                    }
                }
                Console.WriteLine("This is not a .txt file");
                return false;
            }

            //set last name to last word of array
            // sort entire thing by that index? 
            object sortArrayOfNames(string[] bbb)
            {
                return aaa;
            }

        }
    }

}

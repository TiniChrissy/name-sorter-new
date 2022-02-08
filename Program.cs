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

            var namesTextFilePath = args[0];
            string[] lines = File.ReadAllLines(namesTextFilePath, Encoding.UTF8); //unit test ,if empty return empty, if sorted, return sroted?? probably don't need that

            // Get the names as a reversed array where the last name comes first and the given names are one string. 
            // Each full name is one array: ["lastName","firstName middleName secondMiddleName"]
            List<string[]> names = new List<string[]>();
            foreach (string line in lines)
            {
                var fullName = line.Split(' ');
                var lastName = fullName[fullName.Length - 1];
                var givenNames = fullName.Take(fullName.Length - 1);
                string givenNamesOneString = String.Join(" ", givenNames);

                string[] reversedName = new string[] { lastName, givenNamesOneString };

                names.Add(reversedName);
            }

            // Sort by last name, then by given name/s
            List<string[]> sortedNames = names
                .OrderBy(name => name[0])   //name[0]: Last name
                .ThenBy(name => name[1])    //name[1]: Given name/s
                .ToList();

            // Print to console
            foreach (string[] name in sortedNames)
            {
                // Swap given name/s and last name back
                string temp = "";            
                temp = name[0];
                name[0] = name[1];
                name[1] = temp;

                Console.WriteLine(String.Join(" ", name)); //Print array out as string
            }

            // Set a variable to the local path
            string docPath = Environment.CurrentDirectory;

            // Write the string array to a new file named "sorted-names-list.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "sorted-names-list.txt")))
            {
                foreach (string[] name in sortedNames)
                    outputFile.WriteLine(String.Join(" ", name));
            }

        }

        static Boolean CheckIfTxtFile(string fileName)
        {
            //Do error checking, that it ends with .txt test
            if (fileName.Length >= 4)
            {
                var lastFourChar = fileName.Substring(fileName.Length - 4);

                if (lastFourChar == ".txt")
                {
                    return true;
                }
            }
            Console.WriteLine("The passed in argument is not a .txt file");
            return false;
        }
    }
}

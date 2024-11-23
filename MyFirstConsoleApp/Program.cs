using System;
using System.IO;
//OperatorExamples();

        // Specify the file path
        string filePath = "output.dat";

        // Create a StreamWriter to write to the file
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            int counter = 1;

            // Use a while loop to write multiple lines
            while (counter <= 10)
            {
                writer.WriteLine("This is line number " + counter);
                counter++;
            }
        }

        Console.WriteLine("Lines have been written to the file.");

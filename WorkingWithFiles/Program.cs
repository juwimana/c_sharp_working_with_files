using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WorkingWithFiles
{
    /*Name: Jean Marie Uwimana
     * Date: April 1st, 2018
     * Program: Working with files-reading, editing,computing different variables.
     */
    class Program
    {
        static void Main(string[] args)
        {
            List<string> students = new List<string>();
            string[] brokenStudents = new string[100000];
            string currentStudents= "";
            double total = 0;
            int number=0, email =0;
            string newStudent = "(LIST (LIST 'Malachi 'Constant 'NONE ) '8129270605 'cmalachi@mail.usi.edu 4.0 )"; //new student information

            StreamReader inFile;
            string inLine = "";


            if (File.Exists("Students.txt"))
            {
                try
                {
                    inFile = new StreamReader("Students.txt");
                    while ((inLine = inFile.ReadLine()) != null)
                    {
                        students.Add(inLine);
                    }
                    students.RemoveAt(0); //removing first element in file
                    students.RemoveAt(students.Count -1); //removing lst string element in file
                    students.Insert(5733, newStudent); //inserting new student Constant in the right position

                    //creating a new file Student.txt
                    StreamWriter writer = new StreamWriter("Output.txt");
                    for (int i = 0; i < students.Count; i++)
                        writer.WriteLine(students[i]);
                    writer.Close();
                }
                catch (System.IO.IOException exc)
                {
                    Console.WriteLine("Error: {0}", exc.Message);
                }
            }
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine(students[i]); //printing out all students
            }
            for (int i = 0; i < students.Count; i++)
            {
                currentStudents = students[i];
                brokenStudents = currentStudents.Split(' ');//spliting student details
                total += double.Parse(brokenStudents[8]);//calculating total GPA
                if (double.Parse(brokenStudents[8]) > 3.0)
                {
                    number++;//counting number of students with a GPA of 3.0 or higher
                }
                if (brokenStudents[7] == "'NONE")
                {
                    email++; //counting number of students with no email account
                }
                if (brokenStudents[2] == "'Anderson")
                {
                    Console.WriteLine("\nName: " + brokenStudents[2] + brokenStudents[3] + brokenStudents[4] +
                        "\tGPA: " + brokenStudents[8]);
                }
            }  
            double gpa = total/students.Count;//Calculating average GPA
            Console.WriteLine("\nAverage GPA:  "+ gpa +"\nNumber of students with GPA of 3.0 or higher: "+ number 
                +"\nStudents with no email account: "+email + "\nTotal number of students: "+students.Count); 
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace prjTextFilesGenericClasses
{
    class StudentA<T>
    {
        private string path = System.IO.Path.GetFullPath(@"..\..\..\") + "studentResults.txt";
        private static object[] StudentID;
        private static object[] Test;
        private static object[] Assignment;
        private static object[] ICE;
        private static object[] Exam;
        private int stackPointer = 0;
        private string Display;

        public StudentA(int size)
        {
            StudentID =new object[size];
            Test = new object[size];
            Assignment = new object[size];
            ICE = new object[size];
            Exam = new object[size];
        }
        public void push(object ID, object test, object assignment,
            object ice, object exam)
        {
            StudentID[stackPointer] = ID;
            Test[stackPointer] = test;
            Assignment[stackPointer] = assignment;
            ICE[stackPointer] = ice;
            Exam[stackPointer] = exam;
            save();
            stackPointer++;//incrementing stackpointer
        }

        private void save()
        {
            try
            {
                if(! File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine("18017262");//adding values 
                        sw.WriteLine(99);
                        sw.WriteLine(70);
                        sw.WriteLine(98);
                        sw.WriteLine(100);

                        sw.WriteLine("18000612");//adding values 
                        sw.WriteLine(99);
                        sw.WriteLine(70);
                        sw.WriteLine(98);
                        sw.WriteLine(100);
                        sw.Close();//closeing the text file
                    }
                }
                else
                {
                    using (StreamWriter sw = new StreamWriter(path, true))
                    {
                        sw.WriteLine(StudentID[stackPointer]);//writig to the file 
                        sw.WriteLine(Test[stackPointer]);
                        sw.WriteLine(Assignment[stackPointer]);
                        sw.WriteLine(ICE[stackPointer]);
                        sw.WriteLine(Exam[stackPointer]);
                        sw.Close();//closeing the text file
                    }
                }
            }
            catch ( Exception ex)
            {
                MessageBox.Show("An error ocured " + ex.ToString());
            }
        }
        public string read()
        {
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("18017262");//adding values 
                    sw.WriteLine(99);
                    sw.WriteLine(70);
                    sw.WriteLine(98);
                    sw.WriteLine(100);

                    sw.WriteLine("18000612");//adding values 
                    sw.WriteLine(99);
                    sw.WriteLine(70);
                    sw.WriteLine(98);
                    sw.WriteLine(100);
                    sw.Close();//closeing the text file
                }
            }
            Display = "";

            try
            {
                StreamReader sr = new StreamReader(path, true);
                for (int x =0;x!= File.ReadLines(path).Count()/5;x++)
                {
                    StudentID[x] = sr.ReadLine();//reading from the text file 
                    Test[x] = sr.ReadLine();
                    Assignment[x] = sr.ReadLine();
                    ICE[x] = sr.ReadLine();
                    Exam[x] = sr.ReadLine();

                    Display += "ID - " + StudentID[x] + "\n";
                    //printing with the generic class 
                    Display += "Test - " + Test[x] + "\n";
                    Display += "Assignment - " + Assignment[x] + "\n";
                    Display += "ICE - " + ICE[x] + "\n";
                    Display += "Exam - " + Exam[x] + "\n";
                    Display += "Final - " + ((Convert.ToDouble(Test[x]) * 0.25) +
                        (Convert.ToDouble(Assignment[x]) * 0.35) +
                        (Convert.ToDouble(ICE[x]) * 0.10) +
                        (Convert.ToDouble(Exam[x]) * 0.30)) + "\n\n";
                    //work out the final mark
                }
                sr.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error ocured " + ex.ToString());
            }
            return Display;




        }
    }
}

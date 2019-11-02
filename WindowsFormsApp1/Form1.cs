using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.XPath;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<Char> Temp = new List<char>(),
            character = new List<char>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if the file exists do the following
            if (File.Exists(textBox1.Text))
            {
                //to count how many times the letter/number repeats
                int count = 0;
                string Final, text;
                text = File.ReadAllText(textBox1.Text);
                char currentChar = text[1];
                //creates a new txt file 
                using (StreamWriter file = new StreamWriter("temp1.txt"))
                {
                    //gets each char in the txt file and adds it to a string
                    foreach (char c in text)
                    {
                        //if the prev char = the current char being added to the string 
                        // the counter adds 1 
                        if (currentChar == c)
                        {
                            count++;
                        }
                        else
                        {
                           if ( count == 1)
                            {
                                Final = "" + currentChar + ",";
                                //makes the prev char = the new char that was added
                                currentChar = c;
                                //resets the counter 
                                count = 1;
                                //writes to the file 
                                file.Write(Final);
                            }
                            else
                            {
                                //what is being written to the txt file
                                Final = "" + currentChar + count.ToString() + ",";
                                //makes the prev char = the new char that was added
                                currentChar = c;
                                //resets the counter 
                                count = 1;
                                //writes to the file 
                                file.Write(Final);
                            }
                        }
                        character.Add(c);
                    }
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //if file exhists 
            if (File.Exists(textBox1.Text))
            {
                //writes to a new file
                using (StreamWriter file = new StreamWriter("temp2.txt"))
                {
                    //reads all the text from the given text file and converts it to a string
                    string text = File.ReadAllText(textBox1.Text);
                    //splits everything between the ,
                    string[] Textray = text.Split(',');
                    //loops through everything in the Textray[]
                    foreach (string s in Textray)
                    {
                        //checks if the length is bigger then 0
                        if (s.Length > 0)
                        {
                            int num = 0;
                            char character = s[0];
                            string stringedNum = s.Substring(1, s.Length - 1);
                            if (stringedNum.Length != 0)
                            {
                                //parses the ints in the string 
                                 num = int.Parse(stringedNum);
                            }
                            else
                            {
                                num = 1;
                            }
                            //writes to the file 
                            for (int i = 0; i < num; i++)
                            {
                                file.Write(character);
                            }
                        }
                    }
                    
                }
            }
        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse .txt Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "xml",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }
    }
}

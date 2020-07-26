using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           //creates a string with the date and time
            string formattedTime = DateTime.UtcNow.ToString("dd/MM/yyyy hh:mm:ss");
            


            // creates a text file with the href links
            if (File.Exists("labels.txt")){
                File.Copy("labels.txt", "labels2.txt");
                textBox7.Text = File.ReadAllText("labels2.txt");
            };
           
            StreamWriter labels = new StreamWriter("labels.txt");
            labels.Write($"<a href=\"#{textBox2.Text} {formattedTime}\">{textBox2.Text}</a> \n");
            labels.Write(textBox7.Text);
            labels.Close();
            File.Delete("labels2.txt");
           
            
            // creates a text file with the notes and span id's
            if (File.Exists("notes.txt"))
            {
                File.Copy("notes.txt", "notes2.txt");
                textBox6.Text = File.ReadAllText("notes2.txt");
            };
            
            StreamWriter notes = new StreamWriter("notes.txt");
            notes.Write($"<span id=\"{textBox2.Text} {formattedTime}\"> \n");
            notes.Write($"<h2>{textBox2.Text}</h2> \n");

            notes.Write($"{textBox3.Text} \n");
            notes.Write("</span> \n");
            notes.Write(textBox6.Text);
            notes.Close();
           File.Delete("notes2.txt");


            // reads the label and notes files and creates a html file with links
                 textBox4.Text = File.ReadAllText("labels.txt");
            textBox5.Text = File.ReadAllText("notes.txt");
            StreamWriter merge = new StreamWriter("Notes.html");
            merge.Write("<html> \n");
            merge.Write("<head> \n");
            merge.Write("<title> Hello Notes </title> \n");
                merge.Write("</head> \n");
            merge.Write("<body bgcolor=\"#e2e2e2\"> \n");
            merge.Write("<h1>Hello Notes<h1> \n");

            merge.Write($"{textBox4.Text} \n");
            merge.Write($"{textBox5.Text} \n");
            merge.Write("</body>");
            merge.Close();

            // textBox4.Text = File.ReadAllText("Test.txt");
            //  textBox4.Text = textBox4.Text + textBox5.Text + textBox3.Text;

            //   StreamWriter localfile = new StreamWriter("Test.txt");
            //       localfile.Write(textBox4.Text);
            //        localfile.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Notes.html");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    }


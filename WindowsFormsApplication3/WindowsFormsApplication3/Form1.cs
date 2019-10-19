using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Nhóm 1")
            {
                Process.Start("https://www.cube.tv/29983426");
                Process.Start("https://www.cube.tv/30020593");
                Process.Start("https://www.cube.tv/29988566");
                Process.Start("https://www.cube.tv/29988574");
            }
            else if (comboBox1.SelectedItem == "Nhóm 2")
            {
                Process.Start("https://www.cube.tv/29988579");
                Process.Start("https://www.cube.tv/29988580");
                Process.Start("https://www.cube.tv/29988567");
                Process.Start("https://www.cube.tv/29956662");
            }
            else if (comboBox1.SelectedItem == "Nhóm 3")
            {
                Process.Start("https://www.cube.tv/29956663");
                Process.Start("https://www.cube.tv/29988616");
                Process.Start("https://www.cube.tv/29956660");
                Process.Start("https://www.cube.tv/29956661");
            }
            else if (comboBox1.SelectedItem == "Nhóm 4")
            {
                Process.Start("https://www.cube.tv/29956674");
                Process.Start("https://www.cube.tv/29956673");
                Process.Start("https://www.cube.tv/29956675");
                Process.Start("https://www.cube.tv/29956677");
            }
            else if (comboBox1.SelectedItem == "Nhóm 5")
            {
                Process.Start("https://www.cube.tv/29956672");
                Process.Start("https://www.cube.tv/29988678");
                Process.Start("https://www.cube.tv/29956722");
                Process.Start("https://www.cube.tv/29956725");
            }
            else MessageBox.Show("Chọn Nhóm trước đã");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem=="Nhóm 1")
            {
                richTextBox1.Text = "https://www.cube.tv/29983426\nhttps://www.cube.tv/30020593\nhttps://www.cube.tv/29988566\nhttps://www.cube.tv/29988574";
            }
            if (comboBox1.SelectedItem == "Nhóm 2")
            {
                richTextBox1.Text = "https://www.cube.tv/29988579\nhttps://www.cube.tv/29988580\nhttps://www.cube.tv/29988567\nhttps://www.cube.tv/29956662";
            }
            if (comboBox1.SelectedItem == "Nhóm 3")
            {
                richTextBox1.Text = "https://www.cube.tv/29956663\nhttps://www.cube.tv/29988616\nhttps://www.cube.tv/29956660\nhttps://www.cube.tv/29956661";
            }
            if (comboBox1.SelectedItem == "Nhóm 4")
            {
                richTextBox1.Text = "https://www.cube.tv/29956674\nhttps://www.cube.tv/29956673\nhttps://www.cube.tv/29956675\nhttps://www.cube.tv/29956677";
            }
            if (comboBox1.SelectedItem == "Nhóm 5")
            {
                richTextBox1.Text = "https://www.cube.tv/29956672\nhttps://www.cube.tv/29988678\nhttps://www.cube.tv/29956722\nhttps://www.cube.tv/29956725";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var lines = File.ReadAllLines("abc.txt");
            var rnd = new Random();
            lines = lines.OrderBy(line => rnd.Next()).ToArray();
            File.WriteAllLines("abc.txt", lines);
            MessageBox.Show("Đã trộn xong");
        }

        public void ExecuteAsAdmin(string fileName)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = fileName;
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.Verb = "runas";
            proc.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ExecuteAsAdmin("Serene.exe");
        }
    }
}

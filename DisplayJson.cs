using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace LoadJsonFile
{
    public partial class DisplayJson : Form
    {
        private List<Person> itemList = new List<Person>();

        public DisplayJson()
        {
            InitializeComponent();
            lblJsonFile.Text = "Please specify a file";
        }


        private void btnLoadJsonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                openFileDialog1.Filter = "json files (*.json)|*.json)";
                try
                {
                    lblJsonFile.Text = file;
                    string jsonText = File.ReadAllText(file);
                    parseJson(jsonText);
                }
                catch (IOException ex)
                {
                    lblJsonFile.Text = ex.Message;
                }
            }
        }

        private void parseJson(string jsonText)
        {
            itemList = JsonConvert.DeserializeObject<List<Person>>(jsonText);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lblJsonFile.Text == "Please specify a file")
            {
                MessageBox.Show("You must load a file first");
                return;
            }
            StringBuilder sb = new StringBuilder();
            var query = from t in itemList
                        orderby t.age descending, t.lastName, t.firstName
                        select t;

            foreach (Person person in query)
            {
                sb.Append(person.age + " | ");
                sb.Append(person.lastName + ", " + person.firstName + " | ");
                sb.Append(person.eyeColor + " | ");
                sb.Append(person.gender + Environment.NewLine);
            }
            txtResult.Text = sb.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lblJsonFile.Text == "Please specify a file")
            {
                MessageBox.Show("You must load a file first");
                return;
            }
            StringBuilder sb = new StringBuilder();
            var query = from t in itemList
                        select t;

            txtResult.Text = query.Count().ToString();

        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lblJsonFile.Text == "Please specify a file")
            {
                MessageBox.Show("You must load a file first");
                return;
            }
            StringBuilder sb = new StringBuilder();
            var query = from t in itemList
                        where t.age > 30
                        where t.isactive == true
                        orderby t.age descending, t.lastName, t.firstName
                        select t;

            foreach (Person person in query)
            {
                sb.Append(person.age + " | ");
                sb.Append(person.lastName + ", " + person.firstName + " | ");
                sb.Append(person.eyeColor + " | ");
                sb.Append(person.gender + Environment.NewLine);
            }
            txtResult.Text = sb.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (lblJsonFile.Text == "Please specify a file")
            {
                MessageBox.Show("You must load a file first");
                return;
            }
            StringBuilder sb = new StringBuilder();
            var query = from t in itemList
                        where t.age > 30
                        where t.isactive == true
                        select t;

            txtResult.Text = query.Count().ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (lblJsonFile.Text == "Please specify a file")
            {
                MessageBox.Show("You must load a file first");
                return;
            }
            StringBuilder sb = new StringBuilder();
            var query = from t in itemList
                        where t.friends.Count() < 3
                        select t;

            txtResult.Text = query.Count().ToString();

        }
    }
}

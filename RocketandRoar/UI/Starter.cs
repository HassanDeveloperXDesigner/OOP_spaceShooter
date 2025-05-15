using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ProgressBar = System.Windows.Forms.ProgressBar;
using EZInput;
using System.Media;

namespace RocketandRoar
{
    public partial class Starter : Form
    {
        private SoundPlayer SoundPlayer = new SoundPlayer("intro.wav");
        public Starter()
        {
            InitializeComponent();
           

        }

        private void Starter_Load(object sender, EventArgs e)
        {
            progressBar2.Visible = true;
            LoadDataFromDatabase();
            timer1.Start();
            SoundPlayer.Play();


        }

        private void progressBar2_Click(object sender, EventArgs e)
        {

        }
        private void LoadDataFromDatabase()
        {
            int totalItems = 100; // Total number of items to load
            for (int i = 0; i < totalItems; i++)
            {
                // Load an item from the database
                // Replace this with your actual database loading code

                // Update ProgressBar
                progressBar2.Value = (i + 1) * 100 / totalItems;
            }

        }
        private void go_next()
        {
           
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                this.Hide();
                Form1 form1 = new Form1();
                form1.Show();
                timer1.Stop();
                
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            

            go_next();
        }
    }
}

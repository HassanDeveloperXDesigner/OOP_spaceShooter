using Rocket.Enum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rocket.A
{
    public class GameObject
    {
        PictureBox Pb;
        bool isFaLLUnderGravity = false;
        Imovement Controller;
        private GameObjectType Type;
        private int Health;
        public ProgressBar HealthBar;
       
        public GameObject() 
        {

        } 
        public GameObject(Image img,int left, int top)
        {
            Pb = new PictureBox();
            Pb.SizeMode = PictureBoxSizeMode.Zoom;
            Pb.Image = img;
            Pb.Left = left;
            Pb.Top = top;
            Pb.BackColor = Color.Transparent;
        }
        public GameObject(Image img, int left, int top,Imovement Controller ) 
        {
            Pb = new PictureBox();
            Pb.SizeMode = PictureBoxSizeMode.Zoom;
            Pb.Image = img;
            Pb.Left = left;
            Pb.Top = top;
            //Pb.Width = img.Width-100;
            //Pb.Height = img.Height-100;
            Pb.BackColor = Color.Transparent;
            this.Controller = Controller;
            
        }
        //public GameObject( Form formreference,Image img, GameObjectType type, int left, int top, Imovement Controller)
        //{
        //    Pb = new PictureBox();
        //    Pb.SizeMode = PictureBoxSizeMode.Zoom;
        //    Pb.Image = img;
        //    Pb.Left = left;
        //    Pb.Top = top;
        //    //Pb.Width = img.Width-100;
        //    //Pb.Height = img.Height-100;
        //    Pb.BackColor = Color.Transparent;
        //    this.Controller = Controller;

        //}
        public GameObject(Form formreference, Image img, GameObjectType type, int left, int top, Imovement controller)
        {
            //Pb = new PictureBox();
            //this.Type = type;
            //Pb.SizeMode = PictureBoxSizeMode.Zoom;
            //Pb.BackColor = Color.Transparent;
            //Pb.Image = img;
            //Pb.Width = img.Width;
            //Pb.Height = img.Height;
            //Pb.Left = left;
            //Pb.Top = top;
            //this.Controller = controller;
            //this.Health = 100;
            //if (type == GameObjectType.Player)
            //{
            //    HealthBar = new ProgressBar();
            //    HealthBar.Top = top + 2;
            //    HealthBar.Left = left;
            //    HealthBar.TabIndex = 0;
            //    HealthBar.Size = new System.Drawing.Size(80, 13);
            //    HealthBar.Value = Health;
            //    formreference.Controls.Add(HealthBar);
            //}
            Pb = new PictureBox();
            this.Type = type;
            Pb.SizeMode = PictureBoxSizeMode.Zoom;
            Pb.BackColor = Color.Transparent;
            Pb.Image = img;

            // Adjust the size of the PictureBox
            int newWidth = 100; // New width (adjust as needed)
            int newHeight = 100; // New height (adjust as needed)
            Pb.Width = newWidth;
            Pb.Height = newHeight;

            Pb.Left = left;
            Pb.Top = top;
            this.Controller = controller;
            this.Health = 100;
            if (type == GameObjectType.Player)
            {
                HealthBar = new ProgressBar();
                HealthBar.Top = top + 2;
                HealthBar.Left = left;
                HealthBar.TabIndex = 0;
                HealthBar.Size = new System.Drawing.Size(80, 13);
                HealthBar.Value = Health;
                formreference.Controls.Add(HealthBar);
            }
        }
    

        public void update (int gravity) 
        {
            this.Pb.Location = Controller.move(this.Pb.Location);
        }
        public PictureBox GetPb()
        { return Pb; }
        public GameObjectType GetGameObjectType()
        {
            return this.Type;
        }
        public void SetHealth(int health)
        {
            if (health >= 0)
            {
                Health = health;
            }
            else if (health < 0)
            {
                Health = 0;
            }
            if (HealthBar != null)
                this.HealthBar.Value = this.Health;
        }
        public int GetHealth()
        {
            return Health;
        }
        public void Update()
        {
            // Update the main object's position
            this.Pb.Location = Controller.move(this.Pb.Location);

            // Check if the health bar exists
            if (HealthBar != null)
            {
                // Move the health bar to the top of the screen
                this.HealthBar.Location = new Point(this.HealthBar.Location.X, 0);
            }
        }
    }
}

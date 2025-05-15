using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rocket.A;
using Rocket.Enum;
using RocketandRoar.Properties;
using EZInput;
using Point = System.Drawing.Point;
using System.Media;



namespace RocketandRoar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }
        public static Game game;
        private SoundPlayer firingSoundPlayer = new SoundPlayer("shipLaser.wav");
        private void Form1_Load(object sender, EventArgs e)
        {
            game = Game.GetGameInstance(this);
            Point Boundary = new Point(this.Width,this.Height);
            game.addGameObject(Resources.player,GameObjectType.Player, 250, 500,new PlayerMove(10,Boundary));
            game.addGameObject(Resources.enemy1, GameObjectType.Enemy,40, 10, new Verticle(3, Boundary, Direction.Down));
            game.addGameObject(Resources.enemy1, GameObjectType.Enemy,250, 10, new Horizontal(3, Boundary,Direction.Left));
            game.addGameObject(Resources.enemy1, GameObjectType.Enemy,350, 10, new Verticle(5, Boundary, Direction.Down));
            
            CollisionD collisionDetection1 = new CollisionD(GameObjectType.Player, GameObjectType.Enemy, Collisiondetection.DecreaseHealth);
            CollisionD collisionDetection2 = new CollisionD(GameObjectType.PlayerFire, GameObjectType.Enemy, Collisiondetection.Kill);
            CollisionD collisionDetection3 = new CollisionD(GameObjectType.EnemyFire, GameObjectType.Player, Collisiondetection.DecreasePlayerHealthByBullet);

            game.AddCollisionDetection(collisionDetection1);
            game.AddCollisionDetection(collisionDetection2);
            game.AddCollisionDetection(collisionDetection3);
        }
       
        private void gameloop_Tick(object sender, EventArgs e)
        {
           
            Point Boundary = new Point(this.Width, this.Height);
            if(Keyboard.IsKeyPressed(Key.Space))
            {
                firingSoundPlayer.Play();
                game.FirePlayer(Resources.laserRed01);
                //game.addBullet(Resources.laserRed01, 250, 510, new Playerbullet(20, Boundary));
            }
            game.RemoveGameObject();
            game.update();
        }
    }
}  

using Rocket.Enum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rocket.A
{
    public class Game
    {
      
        int Gravity = 5 ;
        List<GameObject> GameObjectList;
        private List<CollisionD> CollisionDet;
        Form Container;
        PictureBox Pb;
        private static Game GameInstance;
        private Form FormReference;
        int PlayerCount;
        int EnemyCount;
        int FireTurn;
        private Game(Form form)
        {
            this.FormReference = form;
            GameObjectList = new List<GameObject>();
            CollisionDet= new List<CollisionD>();
            PlayerCount = 0;
            EnemyCount = 0;
            FireTurn = 0;
        }

        //public Game( Form Container) 
        //{

        //    GameObjectList = new List<GameObject>();
        //    this.Container = Container ;


        //}
        public static Game GetGameInstance(Form form)
        {
            if (GameInstance == null)
            {
                GameInstance = new Game(form);
            }
            return GameInstance;
        }

        public void addGameObject (Image img,GameObjectType type, int left, int top, Imovement Controller)
        {
            if (!(type == GameObjectType.Player && PlayerCount > 0) || (type == GameObjectType.Enemy && EnemyCount > 5))
            {
                if (type == GameObjectType.Player)
                {
                    PlayerCount++;
                }
                else if (type == GameObjectType.Enemy)
                {
                    EnemyCount++;
                }
                GameObject gameobject = new GameObject(FormReference, img, type, left, top, Controller);
                FormReference.Controls.Add(gameobject.GetPb());
                GameObjectList.Add(gameobject);
            }

           
        }
       
        public void FirePlayer(Image img)
        {
            
            
          
           int left = 0;
            int top = 0;
            foreach (GameObject gameObject in GameObjectList)
            {
                if (gameObject.GetGameObjectType() == GameObjectType.Player)
                {
                    left = gameObject.GetPb().Left + 3;
                    top = gameObject.GetPb().Top - 30;
                    break;
                }
            }

            addGameObject(img, GameObjectType.PlayerFire, left, top, new FireMovement(20, new Point(FormReference.Width, FormReference.Height), Direction.Up));
        }
        
        public void AddCollisionDetection(CollisionD collision)
        {
            CollisionDet.Add(collision);
        }
        public void update()
        {

            foreach (GameObject gameobject in GameObjectList)
            {
                gameobject.Update();
                foreach (CollisionD collision in CollisionDet)
                {
                    collision.checkCollision(GameObjectList);
                }
            }

        }
        public void RemoveGameObject()
        {
            for (int i = 0; i < GameObjectList.Count; i++)
            {
                GameObject gameobject = GameObjectList[i];
                if (gameobject.GetHealth() == 0 || gameobject.GetPb().Location.X > FormReference.Width || gameobject.GetPb().Location.Y > FormReference.Height)
                {
                    if (gameobject.HealthBar != null)
                    {
                        FormReference.Controls.Remove(gameobject.HealthBar);
                    }
                    GameObjectList.Remove(gameobject);
                    FormReference.Controls.Remove(gameobject.GetPb());


                }
            }
        }

    }
}

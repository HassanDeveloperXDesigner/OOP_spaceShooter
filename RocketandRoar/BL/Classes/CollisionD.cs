
using Rocket.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocket.A
{
    public class CollisionD
    {
        private GameObjectType Type1;
        private GameObjectType Type2;
        private Collisiondetection Action;

        public CollisionD(GameObjectType type1, GameObjectType type2, Collisiondetection action)
        {
            this.Type1 = type1;
            this.Type2 = type2;
            this.Action = action;
        }
        public bool checkCollision(List<GameObject> gameobjects)
        {
            
            
                foreach (GameObject g1 in gameobjects)
                {
                    if (g1.GetGameObjectType() == this.Type1)
                    {
                        foreach (GameObject g2 in gameobjects)
                        {
                            if (g2.GetGameObjectType() == this.Type2)
                            {
                                if (g1.GetPb().Bounds.IntersectsWith(g2.GetPb().Bounds))
                                {
                                    if (Action == Collisiondetection.DecreaseHealth)
                                    {
                                        g1.SetHealth(g1.GetHealth() - 1);
                                    }
                                    else if (Action == Collisiondetection.DecreasePlayerHealthByBullet)
                                    {
                                        g1.SetHealth(0);
                                        g2.SetHealth(g2.GetHealth() - 25);
                                    }
                                    else if (Action == Collisiondetection.Kill)
                                    {
                                        g1.SetHealth(0);
                                        g2.SetHealth(0);
                                    }
                                    return true;
                                }
                            }
                        }
                    }
                }
            return false;
            
        }
    }
}

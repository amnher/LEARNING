using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintBallArena
{
    class PaintballGun
    {
        public const int MAGAZINE_SIZE = 16;
        
        
        
        public bool IsEmpty() { return BallsLoaded == 0; }

        public int balls
        { 
            get { return balls; } 
            set 
            {
               if(value >0)
                    balls = value;
               Reload();
            } 
        }

        public int BallsLoaded { get; private set; }


        public int GetBalls() { return balls; }
        
        public void SetBalls(int numberOfBalls)
        {
            if (numberOfBalls > 0)
                balls = numberOfBalls;
            Reload();
        }
        public void Reload()
        {
            if (balls > MAGAZINE_SIZE)
                BallsLoaded = MAGAZINE_SIZE;
            else
                BallsLoaded = balls;
        }
        public bool Shoot()
        {
            if (BallsLoaded == 0) return false;
            BallsLoaded--;
            balls--;
            return true;
        }
    }
}

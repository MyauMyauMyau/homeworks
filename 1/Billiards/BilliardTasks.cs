using System;

namespace Billiards
{
	public class BilliardTasks
	{

		public double BounceHorizontalWall(double directionRadians)
		{
            return BounceWall(directionRadians, 0);
        }
        public double BounceVerticalWall(double directionRadians)
        {
            return BounceWall(directionRadians, Math.PI / 2);
        }
        public double BounceWall(double directionRadians, double wallInclanationRadians)
		{
            //coordinates shift
            return 2*wallInclanationRadians - directionRadians;
		}

    }
}
using System;

namespace Billiards
{
	public class BilliardTasks
	{

		public double BounceHorizontalWall(double directionRadians)
		{
			return (-1*directionRadians);
        }

		public double BounceWall(double directionRadians, double wallInclanationRadians)
		{
            //coordinates shift
            return BounceHorizontalWall(directionRadians- wallInclanationRadians) + wallInclanationRadians;
		}
        public double BounceVerticalWall(double directionRadians)
        {
            return BounceWall(directionRadians, Math.PI / 2);
        }
    }
}
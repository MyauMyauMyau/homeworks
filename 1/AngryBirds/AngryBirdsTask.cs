using System;

namespace AngryBirds
{
	public class AngryBirdsTask
	{
        const double g = 9.8;
		/// <returns>Угол прицеливания в радианах от 0 до Pi/2</returns>
		public double FindSightAngle(double v, double distance)
		{

            return Math.Asin(distance*g/(v*v))/2;
		}
	}
}

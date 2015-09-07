using System;

namespace AngryBirds
{
	public class AngryBirdsTask
	{
        const double g = 9.8;
		/// <returns>Угол прицеливания в радианах от 0 до Pi/2</returns>
		public double FindSightAngle(double v, double distance)
		{
            if (v <= 0 || distance <= 0)
                throw new ArgumentException();
            return Math.Asin(distance*g/(v*v))/2;
		}
	}
}

using System;
using System.Drawing;

namespace Rectangles
{
	public class RectangleTasks
	{
		// Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
        public Rectangle Intersect (Rectangle r1, Rectangle r2)
        {
            int x1 = Math.Max(r1.X, r2.X);
            int x2 = Math.Min(r1.X + r1.Width, r2.X + r2.Width);
            int y1 = Math.Max(r1.Y, r2.Y);
            int y2 = Math.Min(r1.Y + r1.Height, r2.Y + r2.Height);
            if (x2 >= x1 && y2 >= y1)
            {
                return new Rectangle(x1, y1, x2 - x1, y2 - y1);
            }
            return Rectangle.Empty;

        }
        public bool AreIntersected(Rectangle r1, Rectangle r2)
		{
            return  (r1.X <= r2.X + r2.Width) &&
            (r1.Y <= r2.Y + r2.Height) &&
            (r2.X <= r1.X + r1.Width) &&
            (r2.Y <= r1.Y + r1.Height);
        }

		// Площадь пересечения прямоугольников
		public int IntersectionSquare(Rectangle r1, Rectangle r2)
		{
            var intersection = Intersect(r1, r2);   
            return intersection.Width * intersection.Height;
        }

		// Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
		// Иначе вернуть -1
		public int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
		{
			var intersection = Intersect(r1, r2);
            if (intersection == r1) return 0;
            if (intersection == r2) return 1;
            return -1;
        }
	}
}
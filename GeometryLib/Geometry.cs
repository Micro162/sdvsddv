using System;

namespace GeometryLib
{

    public static class Geometry
    {
    
        public static double SquareArea(double side)
        {
            if (side <= 0)
                throw new ArgumentException("Сторона квадрата має бути додатним числом.");

            return side * side;
        }

     
        public static double RectangleArea(double width, double height)
        {
            if (width <= 0 || height <= 0)
                throw new ArgumentException("Сторони прямокутника мають бути додатними числами.");

            return width * height;
        }

 
        public static double TriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentException("Сторони трикутника мають бути додатними числами.");

         
            if (a + b <= c || a + c <= b || b + c <= a)
                throw new ArgumentException("З таких сторін неможливо побудувати трикутник.");

            double p = (a + b + c) / 2.0; 
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public static double TriangleArea(double baseLength, double height)
        {
            if (baseLength <= 0 || height <= 0)
                throw new ArgumentException("Основа та висота мають бути додатними числами.");

            return 0.5 * baseLength * height;
        }
    }
}

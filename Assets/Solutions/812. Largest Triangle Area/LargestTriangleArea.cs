using System;

namespace LargestTriangleArea
{
    public class Solution
    {
        private const int X_INDEX = 0;
        private const int Y_INDEX = 1;
        private const int ONE = 1;
        private const int TWO = 2;
        private const double HALF = 0.5;

        public double LargestTriangleArea(int[][] points)
        {
            double _largestArea = 0;
            int pointsLength = points.Length;
            for (int i = 0; i < pointsLength - TWO; i++)
            {
                for (int j = i + ONE; j < pointsLength - ONE; j++)
                {
                    for (int k = j + ONE; k < pointsLength; k++)
                    {
                        _largestArea = Math.Max(_largestArea, CalculateTriangleArea(points[i], points[j], points[k]));
                    }
                }
            }

            return _largestArea;
        }

        // Triangle Area Formula
        // 1/2 * |Ax(By − Cy) + Bx(Cy − Ay) + Cx(Ay − By)|
        // https://www.mathopenref.com/coordtrianglearea.html
        // And this is explained by three trapeziums.
        // https://www.cuemath.com/geometry/area-of-triangle-in-coordinate-geometry
        private double CalculateTriangleArea(int[] pointA, int[] pointB, int[] pointC)
        {
            return HALF * Math.Abs(pointA[X_INDEX] * (pointB[Y_INDEX] - pointC[Y_INDEX])
                + pointB[X_INDEX] * (pointC[Y_INDEX] - pointA[Y_INDEX])
                + pointC[X_INDEX] * (pointA[Y_INDEX] - pointB[Y_INDEX]));
        }
    }
}
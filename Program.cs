using System.Security.AccessControl;

namespace Assignment_6_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Assignment 6.4
             * 
             * You are given an n x n 2D matrix representing an image, rotate the image 
             * by 90 degrees (clockwise).
             * 
             * You have to rotate the image in-place, which means you have to modify the 
             * input 2D matrix directly. DO NOT allocate another 2D matrix and do the rotation.
            */

            int[,] matrix3x3 =
            {
                { 1,2,3 },
                { 4,5,6 },
                { 7,8,9 }
            };

            int[,] matrix4x4 =
            {
                { 1,2,3,4 },
                { 4,5,6,7 },
                { 5,6,7,8 },
                { 9,10,11,12}
            };


            // Print the first matrix to the screen
            Console.WriteLine("Press enter to see the matrix below get rotated by 90 degrees");
            PrintMatrix(matrix3x3);
            Console.ReadLine();
            
            // Rotate the matrix
            Console.WriteLine("\nHere is the rotated matrix. Press enter to see another matrix");
            RotateMatrix(matrix3x3);
            PrintMatrix(matrix3x3);
            Console.ReadLine();

            // Print the second matrix to the screen
            Console.WriteLine("Press enter to see the matrix below get rotated by 90 degrees");
            PrintMatrix(matrix4x4);
            Console.ReadLine();

            // Rotate the matrix
            Console.WriteLine("\nHere is the rotated matrix.");
            RotateMatrix(matrix4x4);
            PrintMatrix(matrix4x4);
            Console.ReadLine();
        }

        static void RotateMatrix(int[,] RotatingMatrix_)
        {
            int length = RotatingMatrix_.GetLength(0) - 1;
            int left = 0, right = length;

            for (int i = 0; i < (length + 1) / 2; i++)
            {
                
                for (int j = i; j < length - i; j++)
                {
                    // Top begins on the top-left, and the bottom is the same length as the right
                    int top = left, bottom = right;

                    // Save the value for top-left corner in a temp var
                    int topLeftTemp = RotatingMatrix_[top + i, left + j];

                    // Move left side starting at the bottom left corner to the top side
                    RotatingMatrix_[top + i, left + j] = RotatingMatrix_[bottom - j, left + i];

                    // Move bottom side starting at the bottomn-right corner to the left side
                    RotatingMatrix_[bottom - j, left + i] = RotatingMatrix_[bottom - i, right - j];

                    // Move right side starting at the top right corner to the bottom side
                    RotatingMatrix_[bottom - i, right - j] = RotatingMatrix_[top + j, right - i];

                    // Move top side starting at the top left corner to the right side
                    RotatingMatrix_[top + j, right - i] = topLeftTemp;
                }
            }
        }
        
        static void PrintMatrix(int[,] Matrix_)
        {
            int row = 0;
            for (int col = 0; row < Matrix_.GetLength(0); col++)
            {
                
                Console.Write($"| {Matrix_[row, col]} ");

                if (col == Matrix_.GetLength(0) - 1)
                {
                    Console.Write('|');
                    Console.WriteLine();
                    col = -1;
                    row++;
                }
            }
        }
    }
}

namespace BlockMatrixClass;

using System;
using System.Collections.Generic;
// TODO: take out space from beginning and end of the input from user
class Program
{
    static void Main(string[] args)
    {
        BlockMatrix matrix1 = null;
        BlockMatrix matrix2 = null;

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Create Empty BlockMatrix");
            Console.WriteLine("2. Create Custom Filled BlockMatrix");
            Console.WriteLine("3. Multiply BlockMatrices");
            Console.WriteLine("4. Add BlockMatrices");
            Console.WriteLine("5. Print BlockMatrices");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter b1 size: ");
                    int b1Empty = int.Parse(Console.ReadLine());
                    Console.Write("Enter b2 size: ");
                    int b2Empty = int.Parse(Console.ReadLine());

                    try
                    {
                        if (matrix1 == null) matrix1 = new BlockMatrix(b1Empty, b2Empty);
                        else matrix2 = new BlockMatrix(b1Empty, b2Empty);

                        Console.WriteLine("Empty BlockMatrix created.");
                    }
                    catch (BlockMatrix.NotValidBlockSizeException e)
                    {
                        Console.WriteLine("The Block Size is not valid");
                    }

                    break;

                case "2":
                    Console.Write("Enter b1 size: ");
                    int b1Filled = int.Parse(Console.ReadLine());
                    Console.Write("Enter b2 size: ");
                    int b2Filled = int.Parse(Console.ReadLine());
                    Console.Write("Enter space-separated integers for custom filled matrix: ");
                    List<int> customList = ParseIntegerList(Console.ReadLine());

                    try
                    {
                        if (matrix1 == null) matrix1 = new BlockMatrix(b1Filled, b2Filled, customList);
                        else matrix2 = new BlockMatrix(b1Filled, b2Filled, customList);

                        Console.WriteLine("Custom Filled BlockMatrix created.");
                    }
                    catch (BlockMatrix.NotValidBlockSizeException e)
                    {
                        Console.WriteLine("The Block Size is not valid");
                    }

                    break;

                case "3":
                    if (matrix1 == null || matrix2 == null)
                    {
                        Console.WriteLine("Error: Matrices not created yet.");
                    }
                    else
                    {
                        try
                        {
                            BlockMatrix result = BlockMatrix.Multiply(matrix1, matrix2);
                            Console.WriteLine("Matrices multiplied.");
                            Console.WriteLine("Result:");
                            Console.WriteLine(result.ToString());

                        }
                        catch (BlockMatrix.NotEqualBlockMatrixDimensionsException e)
                        {
                            Console.WriteLine("The Matrices dimensions are not equal");
                        }
                        catch (BlockMatrix.NotEqualBlockDistributionException e)
                        {
                            Console.WriteLine("The Block Distribution is not equal");
                        }
                    }
                    break;

                case "4":
                    if (matrix1 == null || matrix2 == null)
                    {
                        Console.WriteLine("Error: Matrices not created yet.");
                    }
                    else
                    {
                        try
                        {
                            BlockMatrix result = BlockMatrix.Add(matrix1, matrix2);
                            Console.WriteLine("Matrices added.");
                            Console.WriteLine("Result:");
                            Console.WriteLine(result.ToString());
                        }
                        catch (BlockMatrix.NotEqualBlockMatrixDimensionsException e)
                        {
                            Console.WriteLine("The Matrices dimensions are not equal");
                        }
                        catch (BlockMatrix.NotEqualBlockDistributionException e)
                        {
                            Console.WriteLine("The Block Distribution is not equal");
                        }
                    }
                    break;

                case "5":
                    if (matrix1 == null && matrix2 == null)
                    {
                        Console.WriteLine("Error: Matrices not created yet.");
                    }
                    else
                    {
                        Console.WriteLine("BlockMatrix 1:");
                        Console.WriteLine(matrix1 != null ? matrix1.ToString() : "Not created yet.");

                        Console.WriteLine("BlockMatrix 2:");
                        Console.WriteLine(matrix2 != null ? matrix2.ToString() : "Not created yet.");
                    }
                    break;

                case "6":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static List<int> ParseIntegerList(string input)
    {
        string[] parts = input.Split(' ');
        List<int> result = new List<int>();
        foreach (string part in parts)
        {
            if (int.TryParse(part, out int number))
            {
                result.Add(number);
            }
        }
        return result;
    }
}

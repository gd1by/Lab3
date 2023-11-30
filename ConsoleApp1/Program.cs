using System;
using System.Linq;

class Program
{

    static void Main()
    {
        // Вызов метода из Lab1
        Pr1.PR1();

        // Вызов метода из Lab2
        Pr2.PR2();

        // Вызов метода из Lab3
        Pr3.PR3();

        // Вызов метода из Lab4
        Pr4.PR4();

        // Вызов метода из Lab5
        Pr5.PR5();
    }
}

class Pr1
{
    public static void PR1()
    {
        // Исходная матрица
        int[][] matrix = [
            [1, -2, 3, -4],
            [5, -6, 7, -8],
            [9, -10, 11, -12]
        ];

        // Получение и вывод отсортированной матрицы по характеристике
        var sortedMatrix = SortMatrixByCharacteristic(matrix);

        Console.WriteLine("Sorted Matrix:");
        foreach (var row in sortedMatrix)
        {
            Console.WriteLine(string.Join(" ", row));
        }
    }


    static int SumNegOdd(int[] arr)
    {
        int sum = 0;

        foreach (var num in arr)
        {
            if (num < 0 && num % 2 != 0)
            {
                sum += Math.Abs(num);
            }
        }

        return sum;
    }

    static int[][] SortMatrixByCharacteristic(int[][] matrix)
    {
        var characteristicMatrix = new int[matrix[0].Length][];

        for (int i = 0; i < matrix[0].Length; i++)
        {
            characteristicMatrix[i] = new int[2];
            characteristicMatrix[i][0] = i;
            characteristicMatrix[i][1] = SumNegOdd(matrix.Select(row => row[i]).ToArray());
        }

        Array.Sort(characteristicMatrix, (x, y) => x[1].CompareTo(y[1]));

        var sortedMatrix = new int[matrix.Length][];

        for (int i = 0; i < sortedMatrix.Length; i++)
        {
            sortedMatrix[i] = new int[matrix[0].Length];

            for (int j = 0; j < sortedMatrix[i].Length; j++)
            {
                sortedMatrix[i][j] = matrix[i][characteristicMatrix[j][0]];
            }
        }

        return sortedMatrix;
    }
}

 class Pr2
{
    public static void PR2()
    {
        // Инициализация матрицы
        int[][] matrix =
        [
            [1, 2, 3],
            [4, 5, 6],
            [7, 8, 9]
        ];

        // Получение количества максимальных и минимальных элементов в матрице
        var (maxCount, minCount) = GetCountOfMaxAndMinElements(matrix);

        // Вывод результатов
        Console.WriteLine($"Количество максимальных элементов: {maxCount}");
        Console.WriteLine($"Количество минимальных элементов: {minCount}");
    }

    static (int, int) GetCountOfMaxAndMinElements(int[][] matrix)
    {
        int maxCount = 0;
        int minCount = 0;

        foreach (var row in matrix)
        {
            maxCount += row.Max();
            minCount += row.Min();
        }

        return (maxCount, minCount);
    }
}

class Pr3
{
    public static void PR3()
    {
        // Инициализация матрицы с вещественными числами
        double[][] matrix =
        [
            [1, 2, 3],
            [4, 5, 6],
            [7, 8, 9]
        ];

        // Вывод исходной матрицы
        Console.WriteLine("Исходная матрица:");
        PrintMatrix(matrix);

        // Вызов метода для обмена элементов матрицы
        SwapElements(matrix);

        // Вывод матрицы после обмена элементов
        Console.WriteLine("Матрица после обмена элементов:");
        PrintMatrix(matrix);
    }

    static void SwapElements(double[][] matrix)
    {
        int n = matrix.Length;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i < j)
                {
                    (matrix[j][i], matrix[i][j]) = (matrix[i][j], matrix[j][i]);
                }
            }
        }
    }

    static void PrintMatrix(double[][] matrix)
    {
        foreach (var row in matrix)
        {
            Console.WriteLine(string.Join(" ", row));
        }
    }
}

class Pr4
{
    public static void PR4()
    {
        // Инициализация матрицы с вещественными числами
        double[][] matrix =
        [
            [1, 2, 3],
            [4, 5, 6],
            [7, 8, 9]
        ];

        // Вывод исходной матрицы
        Console.WriteLine("Исходная матрица:");
        PrintMatrix(matrix);

        // Вызов метода для сложения элементов матрицы в указанных столбцах
        AddElements(matrix, 1, 2);

        // Вывод матрицы после сложения элементов
        Console.WriteLine("Матрица после сложения элементов:");
        PrintMatrix(matrix);
    }

    static void AddElements(double[][] matrix, int q, int s)
    {
        int n = matrix.Length;

        for (int i = 0; i < n; i++)
        {
            matrix[i][s] += matrix[i][q];
        }
    }

    static void PrintMatrix(double[][] matrix)
    {
        foreach (var row in matrix)
        {
            Console.WriteLine(string.Join(" ", row));
        }
    }
}

class Pr5
{
    public static void PR5()
    {
        // Инициализация матрицы с вещественными числами
        double[][] matrix =
        [
            [1, 2, 3],
            [4, 5, 6],
            [7, 8, 9]
        ];

        // Вывод исходной матрицы
        Console.WriteLine("Исходная матрица:");
        PrintMatrix(matrix);

        // Вызов метода для поиска строки, которая совпадает с соответствующим столбцом
        int k = FindRow(matrix);

        // Вывод результата
        if (k != -1)
        {
            Console.WriteLine($"k-я строка совпадает с k-м столбцом, k = {k}");
        }
        else
        {
            Console.WriteLine("Такого k не существует");
        }
    }

    static int FindRow(double[][] matrix)
    {
        int n = matrix.Length;

        for (int k = 0; k < n; k++)
        {
            bool equal = true;

            for (int i = 0; i < n; i++)
            {
                if (matrix[k][i] != matrix[i][k])
                {
                    equal = false;
                    break;
                }
            }

            if (equal)
            {
                return k;
            }
        }

        return -1;
    }

    static void PrintMatrix(double[][] matrix)
    {
        foreach (var row in matrix)
        {
            Console.WriteLine(string.Join(" ", row));
        }
    }
}

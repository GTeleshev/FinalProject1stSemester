/* Задача 52: Задайте двумерный массив из целых чисел.
Найдите среднее арифметическое элементов в каждом
столбце.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
Среднее арифметическое каждого
столбца: 4,6; 5,6; 3,6; 3. */

Console.Clear();

int[] paramArray = InputCheck();
int rows = paramArray[0];
int columns = paramArray[1];
int min = paramArray[2];
int max = paramArray[3];
int decimals = paramArray[4];

int[,] array = GetArray(rows, columns, min, max);
Console.WriteLine();
Console.WriteLine("Массив:");
PrintArray(array);
Console.WriteLine("Среднее по столбцам:");

Console.WriteLine(String.Join(" ", ColumnAverages(array, decimals)));

int[] InputCheck()
{
    Console.Clear();
    int[] parametersArray = new int[5];
    Console.WriteLine("Введите параметры двумерного массива:");
    
    bool res1 = false;
    int M = parametersArray.Length;
    string errorMessage = "Число введено неверно.";
    string secondMessage = "-";
    string[] prefixes = new string [5];
    prefixes[0] = "количество строк массива";
    prefixes[1] = "количество столбцов массива";
    prefixes[2] = "минимум";
    prefixes[3] = "максимум";
    prefixes[4] = "количество знаков для расчёта среднего";
    
    int count = 0;
    while (!res1 || count < M)
    {
        Console.Write($"{secondMessage} {prefixes[count]}: ");
        res1 = int.TryParse(Console.ReadLine(), out parametersArray[count]);
        if (!res1 == true)
        {
            Console.WriteLine(errorMessage);
        }
        else
        {
            count++;
        }
    }
    return parametersArray;
}

int[,] GetArray(int m, int n, int minValue, int maxValue)
{
    int interimVar = 0;
    if(minValue > maxValue)
    {
        interimVar = maxValue;
        maxValue = minValue;
        minValue = interimVar;
    }
    
    int[,] result = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return result;
}
double[] ColumnAverages(int[,] intArray, int numberOfDecimals)
{
    int m = intArray.GetLength(0);
    int n = intArray.GetLength(1);
    double[] averagesArray = new double[n];
    double sum = 0;
    for (int j = 0; j < n; j++)
    {
        sum = 0;
        for (int i = 0; i < m; i++)
        {
            sum = sum + intArray[i, j];
            
            if (i == m - 1) 
            {
                averagesArray[j] = Math.Round(sum / m, numberOfDecimals);
            }
        }
    }
    return averagesArray;
}

void PrintArray(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Console.Write($"{inArray[i, j]} ");
        }
        Console.WriteLine();
    }
}

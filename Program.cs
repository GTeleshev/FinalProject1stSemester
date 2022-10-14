/* Задача: Написать программу, которая из имеющегося массива строк формирует массив из строк, длина которых меньше либо равна 3 символа. Первоначальный массив можно ввести с клавиатуры, либо задать на старте выполнения алгоритма. При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.
Примеры:
["hello", "2", "world", -> ["2", ":-)"]
["1234", "1567", "-2", "computer science"] -> ["-2"]
["Russia", "Denmark", "Kazan"] -> [] */

Console.Clear();

string[] stringArrayToProcess = InputCheck();

PrintArray(stringArrayToProcess);
string[] outStringArray = OutPutArray(stringArrayToProcess);
Console.WriteLine();
PrintArray(outStringArray);

string[] InputCheck()
{
    Console.Clear();
    int count = 0;
    string firstMessage = "Введите количество строк массива: ";
    string errorMessage = "Число введено неверно.";
    bool res = false;
    int M = 1;
    while (!res)
    {
        Console.Write($"{firstMessage}: ");
        res = int.TryParse(Console.ReadLine(), out M);
        if (!res == true)
        {
            Console.WriteLine(errorMessage);
        }
        else
        {
            count++;
        }
    }

    string[] stringArray = new string[M];

    string secondMessage = "элемент ";

    int count1 = 0;
    bool res1 = false;
    while (count1 < M)
    {
        Console.Write($"{secondMessage} {count1}: ");
        stringArray[count1] = Console.ReadLine();
        count1++;
    }
    return stringArray;
}

string[] OutPutArray(string[] stringArray)
{
    int m = stringArray.Length;
    int outputSize = 0;
    string[] outputArray = new string[outputSize];
    for (int i = 0; i < m; i++)
    {
        if (stringArray[i].Length <= 3)
        {
            outputSize++;
            Array.Resize(ref outputArray, outputSize);
            outputArray[outputSize - 1] = stringArray[i];
        }
    }
    return outputArray;
}

void PrintArray(string[] inArray)
{
    for (int i = 0; i < inArray.Length; i++)
    {
        Console.Write($"{inArray[i]} ");
    }
}

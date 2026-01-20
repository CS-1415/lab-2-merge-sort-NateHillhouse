using System.Diagnostics;
using System.IO.Pipelines;


/*
Nathan Hillhouse
1/20/2026
Lab 2: Merge Sort
*/

Console.Clear();
int[] array = GenerateArray();

System.Diagnostics.Debug.Assert(Enumerable.SequenceEqual( CombineSortedArrays(new int[]{1, 3, 5}, new int[]{-5, 3, 6, 7}), new int[]{-5, 1, 3, 3, 5, 6, 7}));
System.Diagnostics.Debug.Assert(Enumerable.SequenceEqual( CombineSortedArrays(new int[]{-5, 2, 5, 8, 10}, new int[]{1, 2, 5}), new int[]{-5, 1, 2, 2, 5, 5, 8, 10}));

Console.Write("Initial array: ");
WriteArray(array);
Console.WriteLine();
array = MergeSort(array);
Console.Write("Sorted Array: ");
WriteArray(array);

static void WriteArray(int[] array)
{
    for (int item = 0; item < array.Length; item++) 
    {
        Console.Write(array[item]);
        if (!(item >= array.Length-1)) Console.Write(", ");
    }
}
static int[] MergeSort(int[] array)
{
    int size = array.Length;
    int[] array1 = new int[size/2];
    int[] array2 = new int[size-(size/2)];
    int x = 0;
    for (int i = 0; i < size; i++)
    {
        if (i < size/2) array1[i] = array[i];
        else 
        {
            array2[x] = array[i];
            x++;
        }
    }

    if (array1.Length > 1) array1 = MergeSort(array1);
    if (array2.Length > 1) array2 = MergeSort(array2);

    
    return CombineSortedArrays(array1, array2);

}

static int[] CombineSortedArrays(int[] array1, int[] array2)
{
    int array1item = 0;
    int array2item = 0;
    int[] newarray = new int [array1.Length + array2.Length];

    for (int i = 0; i < newarray.Length; i++)
    {
        if (array1item >= array1.Length) 
        {
            newarray[i] = array2[array2item];
            array2item++;
        }
        else if (array2item >= array2.Length)
        {
            newarray[i] = array1[array1item];
            array1item++;
        }
        else if (array1[array1item] <= array2[array2item]) 
        {
            newarray[i] = array1[array1item];
            array1item++;
        }
        else if (array1[array1item] >= array2[array2item])
        {
            newarray[i] = array2[array2item];
            array2item++;
        }
    }
    return newarray;
}

static int[] GenerateArray()
{
    Random rand = new Random();
    //Console.WriteLine("How large would you like your array to be? ");
    int size = rand.Next(4,10);
    int[] array = new int[size];
    for (int i = 0; i < size; i++)
    {
        array[i] = rand.Next(-9,9);
    }

    return array;
}
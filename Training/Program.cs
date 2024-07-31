public class Program
{
    public static void Main()
    {
        var ints = new int[] { 1, 2 };
        var strings = new[] { "A", "B" };

        Print(Combine(ints, ints));
        Print(Combine(ints, ints, ints));
        Print(Combine(ints));
        Print(Combine());
        Print(Combine(strings, strings));
        Print(Combine(ints, strings));
    }

    public static Array Combine(params Array[] arrays)
    {
        if (arrays.Length == 0) return null;

        Type elementType = GetElementType(arrays);
        if (elementType == null || !AllArraysHaveSameType(arrays, elementType)) return null;

        int totalLength = GetTotalLength(arrays);
        Array result = CreateResultArray(elementType, totalLength);


        CopyArraysToResult(arrays, result);

        return result;
    }
    public static Type GetElementType(Array[] arrays)
    {
        return arrays[0].GetType().GetElementType();
    }

    public static bool AllArraysHaveSameType(Array[] arrays, Type elementType)
    {
        foreach (var array in arrays)
        {
            if (array.GetType().GetElementType() != elementType)
            {
                return false;
            }
        }
        return true;
    }
    public static int GetTotalLength(Array[] arrays)
    {
        int totalLength = 0;
        foreach (var array in arrays)
        {
            totalLength += array.Length;
        }
        return totalLength;
    }

    public static Array CreateResultArray(Type elementType, int totalLength)
    {
        return Array.CreateInstance(elementType, totalLength);
    }

    public static void CopyArraysToResult(Array[] arrays, Array result)
    {
        int currentPosition = 0;
        foreach (var array in arrays)
        {
            Array.Copy(array, 0, result, currentPosition, array.Length);
            currentPosition += array.Length;
        }
    }

    static void Print(Array array)
    {
        if (array == null)
        {
            Console.WriteLine("null");
            return;
        }
        for (int i = 0; i < array.Length; i++)
            Console.Write("{0} ", array.GetValue(i));
        Console.WriteLine();
    }
}
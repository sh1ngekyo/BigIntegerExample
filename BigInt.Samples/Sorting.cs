using BigInteger = BigInt.Core.BigInt;
internal class Sorting
{
    private static void Main(string[] args)
    {
        var data = new BigInteger[] { -12, 4, 356, 0, 123, -28 };
        Array.Sort(data);
        Console.WriteLine(string.Join(", ", data.ToList()));
    }
}
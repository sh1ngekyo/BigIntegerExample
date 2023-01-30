using BigInteger = BigInt.Core.BigInt;
internal class Factorial
{
    private static BigInteger CalcFactorial(int n)
    {
        if (n < 0)
            throw new ArgumentOutOfRangeException(nameof(n));
        BigInteger result = 1;
        for (long i = 1; i <= n; ++i)
            result *= i;
        return result;
    }

    private static BigInteger CalcFactorialRec(int n) 
        => n < 0 ? throw new ArgumentOutOfRangeException(nameof(n)) : n == 0 ? 1 : n * CalcFactorialRec(n - 1);

    private static void _Main(string[] args)
    {
        Console.WriteLine("Factorials from 0 to 100:");
        for (var i = 0; i <= 100; i++)
            Console.WriteLine(CalcFactorial(i));
        Console.WriteLine("Factorial 500:");
        Console.WriteLine(CalcFactorial(500));
        Console.WriteLine("Factorial 1000:");
        Console.WriteLine(CalcFactorial(1000));
    }
}
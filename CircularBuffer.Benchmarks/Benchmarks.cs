using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using CircularBuffer;

[MemoryDiagnoser]
public class MyBenchmark
{
    CircularBuffer<int> buff;
    [GlobalSetup]
    public void Init()
    {
        buff = new CircularBuffer<int>(100);
    }

    [Benchmark]
    public void TestMethod()
    {
        // Your benchmark code here
        for(int i = 0; i < 100; i++)
        {
            buff.PushBack(i);
        }

        int v = 0;
        foreach(int i in buff)
        {
            v += i;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<MyBenchmark>();
    }
}
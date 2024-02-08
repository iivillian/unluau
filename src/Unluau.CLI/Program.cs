﻿using Unluau.Chunk;
using Unluau.IL.Visitors;

namespace Unluau.CLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var stream = File.OpenRead("./test/Conditions.luau");
            var chunk = LuauChunk.Create(stream);

            Console.WriteLine(chunk.ToString());

            var program = chunk.Lift();

            using var output = Console.OpenStandardOutput();
            program.Visit(new OutputVisitor(output));

            Console.WriteLine('\n');

            program.Visit(new ValueVisitor());
            program.Visit(new OutputVisitor(output));
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _01._02
{
	class Program
	{
		static void Main()
		{
			var input = File.ReadAllLines("input.txt").Select(int.Parse).ToArray();
			var result = Find(input, new List<int>(), 0);

			Console.WriteLine(result);
			Console.ReadKey();
		}

		static int Find(int[] input, List<int> seen, int sum)
		{
			for (int i = 0; i < input.Length; i++)
			{
				sum += input[i];
				if (seen.Contains(sum)) return sum;
				seen.Add(sum);
			}

			return Find(input, seen, sum);
		}
	}
}

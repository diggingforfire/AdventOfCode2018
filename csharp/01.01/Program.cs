using System;
using System.IO;
using System.Linq;

namespace _01._01
{
	class Program
	{
		static void Main()
		{
			var result = File.ReadAllLines("input.txt").Sum(int.Parse);
			Console.WriteLine(result);
			Console.ReadKey();
		}
	}
}

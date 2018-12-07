using System;
using System.IO;
using System.Linq;


namespace _02._02
{
	class Program
	{
		static void Main(string[] args)
		{
			var lines = File.ReadAllLines("input.txt");

			var result = lines
				.SelectMany(line => lines, (a, b) => new
				{
					FirstLine = a,
					SecondLine = b,
					Intersection = a.Where((_, i) => a[i] == b[i])
				})
				.Where(pair => pair.FirstLine != pair.SecondLine)
				.First(pair => pair.Intersection.Count() == pair.FirstLine.Length - 1)
				.Intersection;
 
			Console.WriteLine(new string(result.ToArray()));
			Console.ReadKey();
		}
	}
}

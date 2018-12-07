using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace _02._01
{
	class Program
	{
		static void Main(string[] args)
		{
			var groups = File.ReadAllLines("input.txt").Select(line => line.GroupBy(@char => @char)).ToList();

			var checksum =
				groups.Count(charGroup => charGroup.Any(chars => chars.Count() == 2)) *
				groups.Count(charGroup => charGroup.Any(chars => chars.Count() == 3));

			Console.WriteLine(checksum);
			Console.ReadKey();
		}
	}
}

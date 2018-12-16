using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace _05._02
{
	class Program
	{
		static void Main()
		{
			var input = File.ReadAllLines("input.txt")[0];

			var unitTypes = input.Select(char.ToLowerInvariant).Distinct();

			var sw = Stopwatch.StartNew();

			var shortestLength = 
				unitTypes.AsParallel().Min(unitType => ReactPolymer(
					input.Replace(unitType.ToString(), string.Empty)
						 .Replace(unitType.ToString().ToUpperInvariant(), string.Empty)
					).Length);

			sw.Stop();

			Debug.WriteLine(sw.ElapsedMilliseconds);
			Console.WriteLine(shortestLength);

			Console.ReadKey();
		}

		static string ReactPolymer(string input)
		{
			while (true)
			{
				var firstReactingPair = input
					.Skip(1)
					.Select((c, i) => new
					{
						a = input[i],
						b = input[++i],
						Index = i - 1
					})
					.FirstOrDefault(p => p.a != p.b && char.ToUpperInvariant(p.a) == char.ToUpperInvariant(p.b));

				if (firstReactingPair == null)
				{
					break;
				}

				input = input.Remove(firstReactingPair.Index, 2);
			}

			return input;
		}
	}
}

using System;
using System.IO;
using System.Linq;

namespace _05._01
{
	class Program
	{
		static void Main()
		{
			var result = File.ReadAllLines("input.txt")[0];

			while (true)
			{
				var firstReactingPair = result
					.Skip(1)
					.Select((c, i) => new
					{
						a = result[i],
						b = result[++i],
						Index = i - 1
					})
					.FirstOrDefault(p => p.a != p.b && char.ToUpperInvariant(p.a) == char.ToUpperInvariant(p.b));
					 
				if (firstReactingPair == null)
				{
					break;
				}

				result = result.Remove(firstReactingPair.Index, 2);
			}

			Console.WriteLine(result.Length);
			Console.ReadKey();
		}
	}
}

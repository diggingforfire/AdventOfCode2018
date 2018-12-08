using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace _03._01
{
	class Program
	{
		static void Main()
		{
			var claims =
				File.ReadAllLines("input.txt")
					.Select(line =>
						new
						{
							Parts = line.Split(new[] {' ', ',', ':', 'x', '@', '#'}, StringSplitOptions.RemoveEmptyEntries)
						})
					.Select(claim =>
						new
						{
							Id = claim.Parts[0],
							Bounds = new Rectangle(int.Parse(claim.Parts[1]), int.Parse(claim.Parts[2]),
								int.Parse(claim.Parts[3]), int.Parse(claim.Parts[4]))
						}).ToList();

			var points = new Dictionary<Point, int>();

			foreach (var claim in claims)
			{
				for (int x = claim.Bounds.Left; x < claim.Bounds.Right; x++)
				{
					for (int y = claim.Bounds.Top; y < claim.Bounds.Bottom; y++)
					{
						var point = new Point(x, y);
						points[point] = points.ContainsKey(point) ? points[point] + 1 : 1;
					}
				}
			}

			var result = points.Count(p => p.Value >= 2);

			Console.WriteLine(result);
			Console.ReadKey();
		}
	}
}

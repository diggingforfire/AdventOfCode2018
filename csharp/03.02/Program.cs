using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace _03._02
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
							Parts = line.Split(new[] { ' ', ',', ':', 'x', '@', '#' }, StringSplitOptions.RemoveEmptyEntries)
						})
					.Select(claim =>
						new
						{
							Id = claim.Parts[0],
							Bounds = new Rectangle(int.Parse(claim.Parts[1]), int.Parse(claim.Parts[2]),
								int.Parse(claim.Parts[3]), int.Parse(claim.Parts[4]))
						}).ToList();

			var result = claims.Single(claim => !claims.Any(innerClaim => claim != innerClaim && claim.Bounds.IntersectsWith(innerClaim.Bounds)));

			Console.WriteLine(result);
			Console.ReadKey();
		}
	}
}

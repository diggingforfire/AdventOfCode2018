using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._01
{
	class Program
	{
		static void Main(string[] args)
		{
			var claims =
				File.ReadAllLines("input.txt")
				.Select(line =>
				new
				{
					Parts = line.Split(new[] { ' ', ',', ':', 'x', '@' }, StringSplitOptions.RemoveEmptyEntries)
				})
				.Select(claim =>
				new
				{
					Id = claim.Parts[0],
					Left = int.Parse(claim.Parts[1]),
					Top = int.Parse(claim.Parts[2]),
					Width = int.Parse(claim.Parts[3]),
					Height = int.Parse(claim.Parts[4])
				}).ToList();

 
 
			Console.WriteLine("Hello World!");
		}
	}
}

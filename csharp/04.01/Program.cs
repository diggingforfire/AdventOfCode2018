using System;
using System.IO;
using System.Linq;

namespace _04._01
{
	class Program
	{
		static void Main()
		{
			int groupKey = 0;

			var result = File.ReadAllLines("input.txt")
				.Select(shift => new
				{
					FallsAsleep = shift.EndsWith("asleep"),
					GuardId = shift.Contains("Guard")
							? shift.Substring(shift.IndexOf("#") + 1, shift.IndexOf("begins") - shift.IndexOf("#") - 1)
							: string.Empty,
					Timestamp = DateTime.Parse(shift.Substring(1, shift.IndexOf(']') - 1))
				})
				.OrderBy(shift => shift.Timestamp)
				.GroupBy(grp => grp.GuardId != string.Empty ? ++groupKey : groupKey) // Group in blocks of guard + additional entries
				.GroupBy(grp => grp.First().GuardId) // Merge all guards
				.Select(g => new
				{
					GuardId = g.Key,
					TotalMinutesAsleep = g.Sum(gg => 
						gg.Select((ggg, i) => ggg.FallsAsleep ? (gg.ToList()[i + 1].Timestamp - ggg.Timestamp).TotalMinutes : 0
						).Sum(x => x)
					),
					FavouriteMinuteToSleep = g.SelectMany(gg =>
							gg.ToList().SelectMany((ggg, i) => 
								 ggg.FallsAsleep
									? Enumerable.Range(ggg.Timestamp.Minute,
										gg.ToList()[i + 1].Timestamp.Minute - ggg.Timestamp.Minute)
									: Array.Empty<int>()
							)
						
					).GroupBy(x => x).OrderByDescending(zg => zg.Count()).FirstOrDefault()?.Key
				}).OrderByDescending(z => z.TotalMinutesAsleep).Select(p => int.Parse(p.GuardId) * p.FavouriteMinuteToSleep).First();

			Console.WriteLine(result);

			Console.ReadKey();
		}
	}
}

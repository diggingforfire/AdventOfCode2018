using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _08._02
{
	class Program
	{
		static void Main()
		{
			var headers =
				File.ReadAllLines("input.txt")
				.First()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse).ToArray();

			var root = ParseTree(headers);

			var value = root.GetValue();

			Console.WriteLine(value);

			Console.ReadKey();
		}

		class Node
		{
			public Node()
			{
				Children = new List<Node>();
				Metadata = Array.Empty<int>();
			}

			public List<Node> Children { get; }
			public int[] Metadata { get; set; }

			public int GetOffset()
			{
				return Children.Sum(c => c.GetOffset()) + Metadata.Length + 2;
			}

			public int GetValue()
			{
				if (!Children.Any())
				{
					return Metadata.Sum();
				}

				return Metadata.Sum(i => i - 1 < Children.Count ? Children[i - 1].GetValue() : 0);
			}
		}

		static Node ParseTree(int[] headers, Node parent = null)
		{
			var root = parent ?? new Node();
			int numberOfChildren = headers[0];
			int numberOfMetaDatas = headers[1];

			for (int i = 1; i < numberOfChildren + 1; i++)
			{
				var offset = root.GetOffset();

				var node = new Node();
				root.Children.Add(node);

				ParseTree(headers.Skip(offset).ToArray(), node);
			}

			var metaDataOffset = root.GetOffset() - root.Metadata.Length;

			root.Metadata = headers.Skip(metaDataOffset).Take(numberOfMetaDatas).ToArray();

			return root;
		}
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _08._01
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

			var metaDataSum = root.GetMetaDataSum();

			Console.WriteLine(metaDataSum);

			Console.ReadKey();
		}

		class Node
		{
			public Node()
			{
				Children = new List<Node>();
				Metadata = Array.Empty<int>();
			}

			public List<Node> Children { get; set; }
			public int[] Metadata { get; set; }

			public int GetMetaDataSum()
			{
				return Children.Sum(c => c.GetMetaDataSum()) + Metadata.Sum();
			}

			public int GetOffset()
			{
				return Children.Sum(c => c.GetOffset()) + Metadata.Length + 2;
			}
		}

		static Node ParseTree(int[] headers, Node parent = null)
		{
			var root = parent ?? new Node();
			int numberOfChildren = headers[0];
			int numberOfMetaDatas = headers[1];

			for (int i = 1; i < numberOfChildren + 1; i++)
			{
				var count = root.GetOffset();

				var node = new Node();
				root.Children.Add(node);

				ParseTree(headers.Skip(count).ToArray(), node);
			}

			var metaDataOffset = root.GetOffset() - root.Metadata.Length;

			var metadatas = headers.Skip(metaDataOffset).Take(numberOfMetaDatas);
			root.Metadata = metadatas.ToArray();

			return root;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DSA
{
	public class Node
	{
		public int x, y;
		public List<Node> neighbours;
		public float cost;

		public Node (int x, int y)
		{
			this.x = x;
			this.y = y;
			neighbours = new List<Node> (4);
		}

		public static void SetNeighbours (Node first, Node second)
		{
			first.neighbours.Add (second);
			second.neighbours.Add (first);
		}

		public static int ManhattanDistance (Node first, Node second)
		{
			return Math.Abs (second.x - first.x) + Math.Abs (second.y - first.y);
		}

		public static float EuclideanDistance (Node first, Node second)
		{
			return (float)Math.Sqrt ((second.x - first.x) * (second.x - first.x) + (second.y - first.y) * (second.y - first.y));
		}
	}
}

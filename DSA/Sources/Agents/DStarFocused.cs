using System;
using System.Collections.Generic;

namespace DSA.Agents
{
	class DStarFocused : DStarBase
	{
		Dictionary<Node, float> key;

		public DStarFocused (Map map, int startX, int startY, int goalX, int goalY)
			: base (map, startX, startY, goalX, goalY, false)
		{
			key = new Dictionary<Node, float> (map.size * map.size);
			InitAgent ();
		}

		protected override Node GetNextNodeFromOpenList ()
		{
			Node min = null;
			float key_min = float.MaxValue;

			foreach (Node n in openList)
			{
				float key_n = key[n];
				if (key_n < key_min)
				{
					min = n;
					key_min = key_n;
				}
			}
			return min;
		}

		protected override void Insert (Node X, float h_new)
		{
			switch (t[X])
			{
				case NodeState.New:
					k[X] = h_new;
					key[X] = h_new + Node.ManhattanDistance (start, X);
					openList.Add (X);
					break;
				case NodeState.Open:
					key[X] = (k[X] = Math.Min (k[X], h_new)) + Node.ManhattanDistance (start, X);
					break;
				case NodeState.Closed:
					key[X] = (k[X] = Math.Min (h[X], h_new)) + Node.ManhattanDistance (start, X);
					openList.Add (X);
					break;
			}
			h[X] = h_new;
			t[X] = NodeState.Open;
		}
	}
}

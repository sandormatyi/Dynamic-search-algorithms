using System;
using System.Collections.Generic;

namespace DSA.Agents
{
	class DStarLite : AgentBase
	{
		Dictionary<Node, float> g;
		Dictionary<Node, float> rhs;

		public DStarLite (Map map, int startX, int startY, int goalX, int goalY)
			: base (map, startX, startY, goalX, goalY)
		{
			InitAgent ();
		}

		private void InitAgent ()
		{
			g = new Dictionary<Node, float> (map.size * map.size);
			rhs = new Dictionary<Node, float> (map.size * map.size);

			state = AgentState.Ready;

			foreach (Node X in map.mapNodes)
				rhs[X] = g[X] = float.PositiveInfinity;

			traversedNodes.Add (start);
			rhs[goal] = 0;
			Insert (goal);

			DiscoverNewNodes ();
			ComputeShortestPath ();
		}

		private float CalculateKey (Node X)
		{
			return Math.Min (g[X], rhs[X] + Node.ManhattanDistance (start, X));
		}

		private bool IsXSmallerThanY (Node X, Node Y)
		{
			if (X == null)
				return false;

			if (Y == null)
				return true;

			float key_x = CalculateKey (X);
			float key_y = CalculateKey (Y);

			if (key_x != key_y)
				return key_x < key_y;
			else
				return Math.Min (g[X], rhs[X]) < Math.Min (g[Y], rhs[Y]);
		}

		private void Insert (Node X)
		{
			openList.Add (X);
		}

		private Node GetNextNode ()
		{
			Node min = null;

			foreach (Node X in openList)
				if (IsXSmallerThanY (X, min))
					min = X;

			return min;
		}

		private void ComputeShortestPath ()
		{
			Node u = GetNextNode ();
			while (IsXSmallerThanY (u, start) || rhs[start] != g[start])
			{
				stepNumber++;

				openList.Remove (u);

				if (g[u] > rhs[u])
				{
					g[u] = rhs[u];
					foreach (Node X in u.neighbours)
						UpdateVertex (X);
				}
				else
				{
					g[u] = float.MaxValue;
					foreach (Node X in u.neighbours)
						UpdateVertex (X);
					UpdateVertex (u);
				}
				u = GetNextNode ();
			}
		}

		private void UpdateVertex (Node X)
		{
			if (X != goal)
			{
				float min = float.PositiveInfinity;

				foreach (Node Y in X.neighbours)
					min = Math.Min (min, GetCost (Y) + g[Y]);

				rhs[X] = min;
			}
			if (openList.Contains (X))
				openList.Remove (X);

			if (g[X] != rhs[X])
				openList.Add (X);
		}

		private float GetCost (Node X)
		{
			return discoveredList.Contains (X) ? X.cost : map.maxValue;
		}

		Node GetNextSuccessorOfStart ()
		{
			Node min_node = null;
			foreach (Node succ in start.neighbours)
			{
				if (min_node == null || GetCost (succ) + g[succ] < GetCost (min_node) + g[min_node])
					min_node = succ;
			}
			return min_node;
		}

		protected void DiscoverNewNodes ()
		{
			for (int x = Math.Max (start.x - sightRange, 0); x < Math.Min (start.x + sightRange, map.size); x++)
			{
				for (int y = Math.Max (start.y - sightRange, 0); y < Math.Min (start.y + sightRange, map.size); y++)
				{
					Node X = map.mapNodes[x, y];
					if (Node.EuclideanDistance (X, start) <= sightRange)
					{
						if (!discoveredList.Contains (X))
						{
							discoveredList.Add (X);
							UpdateVertex (X);
						}
					}
				}
			}
		}

		public override List<Node> PlanRouteAndStep ()
		{
			if (start == goal)
			{
				state = AgentState.Finished;
				return new List<Node> ();
			}
			else
				state = AgentState.Ready;

			Node next = GetNextSuccessorOfStart ();
			start = next;
			traversedNodes.Add (start);

			DiscoverNewNodes ();

			ComputeShortestPath ();

			return new List<Node> ();
		}

		public override List<Node> GetPathToNode (Node end)
		{
			return new List<Node> ();
		}
	}
}

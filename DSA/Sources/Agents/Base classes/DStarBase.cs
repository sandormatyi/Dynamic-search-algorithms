using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DSA.Agents
{
	enum NodeState
	{
		New,
		Open,
		Closed
	}

	class DStarBase : AgentBase
	{
		protected Dictionary<Node, NodeState> t;
		protected Dictionary<Node, float> k;
		protected Dictionary<Node, float> h;
		protected Dictionary<Node, Node> backPointer;

		protected DStarBase (Map map, int startX, int startY, int goalX, int goalY, bool initNeeded)
			: base (map, startX, startY, goalX, goalY)
		{
			if (initNeeded)
				InitAgent ();
		}

		protected void InitAgent ()
		{
			t = new Dictionary<Node, NodeState> (map.size * map.size);
			k = new Dictionary<Node, float> (map.size * map.size);
			h = new Dictionary<Node, float> (map.size * map.size);
			backPointer = new Dictionary<Node, Node> (map.size * map.size);

			state = AgentState.Ready;

			foreach (Node X in map.mapNodes)
			{
				t[X] = NodeState.New;
			}

			Insert (goal, 0);

			backPointer[goal] = null;
			traversedNodes.Add (start);

			InitPlan ();
		}

		protected void InitPlan ()
		{
			while (true)
			{
				float k_min = k[ProcessState ()];
				if (t[start] == NodeState.Closed || state != AgentState.Ready)
					break;
			}
		}

		protected void PrepareRepair ()
		{
			HashSet<Node> toBeModified = new HashSet<Node> ();

			for (int x = Math.Max (start.x - sightRange, 0); x < Math.Min (start.x + sightRange, map.size); x++)
			{
				for (int y = Math.Max (start.y - sightRange, 0); y < Math.Min (start.y + sightRange, map.size); y++)
				{
					Node X = map.mapNodes[x, y];
					if (Node.EuclideanDistance (X, start) <= sightRange)
					{
						if (!discoveredList.Contains (X))
						{
							foreach (Node Y in X.neighbours)
								toBeModified.Add (Y);

							toBeModified.Add (X);
							discoveredList.Add (X);
						}
					}
				}
			}

			foreach (Node X in toBeModified)
				if (t[X] == NodeState.Closed)
					Insert (X, h[X]);
		}

		protected List<Node> RepairReplan ()
		{
			while (true)
			{
				float k_min = k[ProcessState ()];
				if (k_min >= h[start] || state != AgentState.Ready)
					break;
			}
			return GetPathToNode (start);
		}

		public override List<Node> PlanRouteAndStep ()
		{
			if (start == goal)
				state = AgentState.Finished;

			PrepareRepair ();
			List<Node> path = RepairReplan ();
			if (path.Count > 1)
			{
				start = path[1];
				traversedNodes.Add (start);
			}

			return path;
		}

		protected virtual Node GetNextNodeFromOpenList ()
		{
			throw new NotImplementedException ();
		}

		protected virtual void Insert (Node X, float h_new)
		{
			switch (t[X])
			{
				case NodeState.New:
					k[X] = h_new;
					openList.Add (X);
					break;
				case NodeState.Open:
					k[X] = Math.Min (k[X], h_new);
					break;
				case NodeState.Closed:
					k[X] = Math.Min (h[X], h_new);
					openList.Add (X);
					break;
			}
			h[X] = h_new;
			t[X] = NodeState.Open;
		}

		protected float GetCost (Node X)
		{
			return discoveredList.Contains (X) ? X.cost : map.maxValue;
		}

		protected Node ProcessState ()
		{
			Node X = GetNextNodeFromOpenList ();

			stepNumber++;

			if (X == null)
			{
				state = AgentState.DeadEndReached;
				return null;
			}

			float k_old = k[X];

			t[X] = NodeState.Closed;
			openList.Remove (X);

			// Raise state
			if (k_old < h[X])
			{
				foreach (Node Y in X.neighbours)
				{
					if (t[Y] != NodeState.New && h[Y] <= k_old && h[X] > h[Y] + GetCost (X))
					{
						backPointer[X] = Y;
						h[X] = h[Y] + GetCost (X);
					}
				}
			}

			// Lower state
			if (k_old == h[X])
			{
				foreach (Node Y in X.neighbours)
				{
					if (t[Y] == NodeState.New ||
						(backPointer[Y] == X && h[Y] != h[X] + GetCost (Y)) ||
						(backPointer[Y] != X && h[Y] > h[X] + GetCost (Y)))
					{
						Insert (Y, h[X] + GetCost (Y));
						backPointer[Y] = X;
					}
				}
			}
			else
			{
				foreach (Node Y in X.neighbours)
				{
					if (t[Y] == NodeState.New || (backPointer[Y] == X && h[Y] != h[X] + GetCost (Y)))
					{
						Insert (Y, h[X] + GetCost (Y));
						backPointer[Y] = X;
					}
					else
					{
						if (backPointer[Y] != X && h[Y] > h[X] + GetCost (Y))
							Insert (X, h[X]);
						else
							if (backPointer[Y] != X && h[X] > h[Y] + GetCost (X) && t[Y] == NodeState.Closed && h[Y] > k_old) { }
						Insert (Y, h[Y]);
					}
				}
			}
			return X;
		}

		public override List<Node> GetPathToNode (Node end)
		{
			List<Node> path = new List<Node> (map.size * 2);
			for (Node prev, it = end; it != null && backPointer.TryGetValue (it, out prev); it = prev)
				path.Add (it);

			return path;
		}
	}
}
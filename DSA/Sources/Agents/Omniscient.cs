using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Agents
{
	class Omniscient : AgentBase
	{
		HashSet<Node> closedList;

		Dictionary<Node, float> f;
		Dictionary<Node, float> g;
		Dictionary<Node, Node> previous;

		public Omniscient (Map map, int startX, int startY, int goalX, int goalY)
			: base (map, startX, startY, goalX, goalY)
		{
			InitAgent ();
		}

		protected void InitAgent ()
		{
			openList = new HashSet<Node> ();
			closedList = new HashSet<Node> ();
			f = new Dictionary<Node, float> (map.size * map.size);
			g = new Dictionary<Node, float> (map.size * map.size);
			previous = new Dictionary<Node, Node> (map.size * map.size);

			openList.Add (start);
			f.Add (start, Node.ManhattanDistance (start, goal));
			g.Add (start, 0);
			previous.Add (start, null);

			state = (start == goal) ? AgentState.Finished : AgentState.Ready;
		}

		protected Node GetNextNodeFromOpenList ()
		{
			Node min = null;

			foreach (Node n in openList)
			{
				if (min == null || f[n] < f[min])
					min = n;
			}
			return min;
		}

		protected virtual float GetCost (Node n)
		{
			return n.cost;
		}

		protected virtual Node PlanRouteStep ()
		{
			if (openList.Count == 0)
			{
				state = AgentState.DeadEndReached;
				return null;
			}

			stepNumber++;

			Node currentNode = GetNextNodeFromOpenList ();

			if (currentNode == goal)
			{
				f[currentNode] = g[currentNode];
				state = AgentState.PathPlanned;
				return currentNode;
			}

			openList.Remove (currentNode);
			closedList.Add (currentNode);

			foreach (Node nextNode in currentNode.neighbours)
			{
				if (closedList.Contains (nextNode))
					continue;

				float tentative_g = g[currentNode] + GetCost (nextNode);

				if (!openList.Contains (nextNode) || tentative_g < g[nextNode])
				{
					g[nextNode] = tentative_g;
					f[nextNode] = tentative_g + Node.ManhattanDistance (nextNode, goal);
					previous[nextNode] = currentNode;
					if (!openList.Contains (nextNode))
						openList.Add (nextNode);

				}
			}
			return currentNode;
		}

		protected List<Node> PlanRoute ()
		{
			Node end = PlanRouteStep (); ;

			traversedNodes = GetPathToNode (end);

			return traversedNodes;
		}

		public override List<Node> PlanRouteAndStep ()
		{
			List<Node> path = PlanRoute ();

			state = AgentState.Finished;

			return path;
		}

		public override List<Node> GetPathToNode (Node end)
		{
			List<Node> path = new List<Node> ();
			for (Node prev, it = end; it != null && previous.TryGetValue (it, out prev); it = prev)
				path.Add (it);

			path.Reverse ();

			return path;
		}
	}
}

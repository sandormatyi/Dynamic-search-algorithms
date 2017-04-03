using System;
using System.Collections.Generic;

namespace DSA.Agents
{
	public enum AgentState
	{
		Ready,
		DeadEndReached,
		PathPlanned,
		Finished
	}

	public abstract class AgentBase
	{
		public Map map;
		public Node start, goal;

		protected HashSet<Node> openList;
		protected HashSet<Node> discoveredList;
		protected List<Node> traversedNodes;

		public AgentState state;
		public uint stepNumber;

		public static ushort maxID = 0;
		public static ushort sightRange;
		public ushort id;

		protected AgentBase () { }

		protected AgentBase (Map map, int startX, int startY, int goalX, int goalY)
		{
			this.map = map;

			goal = map.mapNodes[goalX, goalY];
			start = map.mapNodes[startX, startY];

			id = ++maxID;

			openList = new HashSet<Node> ();
			discoveredList = new HashSet<Node> ();
			traversedNodes = new List<Node> (map.size * 2);
		}

		public abstract List<Node> PlanRouteAndStep ();

		public abstract List<Node> GetPathToNode (Node end);

		public List<Node> GetTraversedNodes ()
		{
			return new List<Node> (traversedNodes);
		}

		public HashSet<Node> GetDiscoveredNodes ()
		{
			return new HashSet<Node> (discoveredList);
		}

		public float GetDistanceTraveled ()
		{
			float dist = 0;

			foreach (Node n in traversedNodes)
				dist += n.cost;

			return dist;
		}
	}
}

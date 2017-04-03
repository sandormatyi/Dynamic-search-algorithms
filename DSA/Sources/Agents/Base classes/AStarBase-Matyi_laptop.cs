using System;
using System.Collections.Generic;
using System.Text;

namespace MI_HF.Agents
{
    abstract class AStarBase : AgentBase
    {
        HashSet<Node> closedList;

        Dictionary<Node, float> f;
        Dictionary<Node, float> g;
        Dictionary<Node, Node> previous;

        protected AStarBase(Map map, int startX, int startY, int goalX, int goalY)
            : base(map, startX, startY, goalX, goalY)
        {
            InitAgent();
        }

        protected void InitAgent() 
        {
            closedList = new HashSet<Node>();
            f = new Dictionary<Node, float>(map.size * map.size);
            g = new Dictionary<Node, float>(map.size * map.size);
            previous = new Dictionary<Node, Node>(map.size * map.size);

            openList.Add(start);
            f.Add(start, Node.ManhattanDistance(start, goal));
            g.Add(start, 0);
            previous.Add(start, null);
            traversedNodes.Add(start);

            if (start == goal)
                state = AgentState.Finished;
            else
                state = AgentState.Ready;
        }

        protected Node GetNextNodeFromOpenList()
        {
            Node min = null;

            foreach (Node n in openList)
            {
                if (min == null || f[n] < f[min])
                    min = n;
            }
            return min;
        }

        protected virtual float GetCost(Node n)
        {
            throw new NotImplementedException("Az AStarBase osztály nem példányosítható!");
        }

        protected virtual Node PlanRouteStep()
        {
            if (openList.Count == 0)
            {
                state = AgentState.DeadEndReached;
                return null;
            }

            stepNumber++;

            Node currentNode = GetNextNodeFromOpenList();

            if (currentNode == goal)
            {
                f[currentNode] = g[currentNode];
                state = AgentState.PathPlanned;
                return currentNode;
            }

            openList.Remove(currentNode);
            closedList.Add(currentNode);

            foreach (Node nextNode in currentNode.neighbours)
            {
                if (closedList.Contains(nextNode))
                    continue;

                float tentative_g = g[currentNode] + GetCost(nextNode);

                if (!openList.Contains(nextNode) || tentative_g < g[nextNode])
                {
                    g[nextNode] = tentative_g;
                    f[nextNode] = tentative_g + Node.ManhattanDistance(nextNode, goal);
                    previous[nextNode] = currentNode;
                    if (!openList.Contains(nextNode))
                        openList.Add(nextNode);
                }
            }
            return currentNode;
        }

        protected void DiscoverNewNodes()
        {
            for (int x = Math.Max(start.x - sightRange, 0); x < Math.Min(start.x + sightRange, map.size); x++)
                for (int y = Math.Max(start.y - sightRange, 0); y < Math.Min(start.y + sightRange, map.size); y++)
                {
                    Node n = map.mapNodes[x, y];
                    if (Node.EuclideanDistance(n, start) <= sightRange)
                        discoveredList.Add(n);
                }
        }

        protected List<Node> PlanRoute()
        {
            Node end = null;
            while (state == AgentState.Ready)
            {
                end = PlanRouteStep();
            }
            return GetPathToNode(end);
        }

        protected void Step(Node next)
        {
            if (start == next)
                return;

            start = next;
            traversedNodes.Add(start);
            
            openList.Clear();
            closedList.Clear();
            f.Clear();
            g.Clear();
            previous.Clear();

            openList.Add(start);
            f.Add(start, Node.ManhattanDistance(start, goal));
            g.Add(start, 0);
            previous.Add(start, null);

            if (start == goal) 
            {
                state = AgentState.Finished;
            }
            else
                state = AgentState.Ready;
        }

        public override List<Node> PlanRouteAndStep()
        {
            DiscoverNewNodes();
            List<Node> path = PlanRoute();
            if (path.Count > 1)
                Step(path[1]);

            return path;
        }

        public override List<Node> GetPathToNode(Node end)
        {
            List<Node> path = new List<Node>();
            for (Node prev, it = end; it != null && previous.TryGetValue(it, out prev); it = prev)
                path.Add(it);

            path.Reverse();

            return path;
        }
    }
}

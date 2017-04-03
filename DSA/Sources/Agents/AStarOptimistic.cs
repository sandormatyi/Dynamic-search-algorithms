namespace DSA.Agents
{
	class AStarOptimistic : AStarBase
	{
		public AStarOptimistic (Map map, int startX, int startY, int goalX, int goalY)
			: base (map, startX, startY, goalX, goalY) { }

		protected override float GetCost (Node n)
		{
			return (discoveredList.Contains (n)) ? n.cost : 1;
		}
	}
}

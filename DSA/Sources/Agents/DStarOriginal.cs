namespace DSA.Agents
{
	class DStarOriginal : DStarBase
	{
		public DStarOriginal (Map map, int startX, int startY, int goalX, int goalY)
			: base (map, startX, startY, goalX, goalY, true) { }

		protected override Node GetNextNodeFromOpenList ()
		{
			Node min = null;
			float key_min = float.MaxValue;

			foreach (Node n in openList)
			{
				float key = k[n];
				if (key < key_min)
				{
					min = n;
					key_min = key;
				}
			}
			return min;
		}
	}
}



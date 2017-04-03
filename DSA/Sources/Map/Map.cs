using System;
using System.Collections.Generic;

namespace DSA
{
	public class Map
	{
		public int size;
		public float maxValue;
		public Node[,] mapNodes;

		static Random rand = new Random ();

		public Map (int size, float maxValue, int octaves, float persistence, MapTextureType textureType)
		{
			this.size = size;
			this.maxValue = (maxValue < 1) ? 1 : maxValue;

			GenerateMap (octaves, persistence, textureType);
		}

		public void GenerateMap (int octaves, float persistence, MapTextureType textureType)
		{
			mapNodes = new Node[size, size];

			MapGenerator gen = new MapGenerator (size, maxValue, octaves, persistence, textureType);
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					mapNodes[i, j] = new Node (i, j);
					mapNodes[i, j].cost = gen.GetValues ()[i, j];
				}
			}
			SetupNeighbours ();
		}

		private void SetupNeighbours ()
		{
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					// Right neighbour
					if (i < size - 1) Node.SetNeighbours (mapNodes[i, j], mapNodes[i + 1, j]);
					// Bottom neighbour
					if (j < size - 1) Node.SetNeighbours (mapNodes[i, j], mapNodes[i, j + 1]);
				}
			}
		}
	}
}
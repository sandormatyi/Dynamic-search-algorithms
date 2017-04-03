using System;
using System.Collections.Generic;
using System.Text;

namespace DSA
{
	public enum MapTextureType
	{
		PerlinNoise = 0,
		Marble = 1,
		Binary = 2,
		BinaryMarble = 3
	}

	class MapGenerator
	{
		private float[,] value;
		private float maxValue;
		private int size;
		private MapTextureType textureType;

		private float persistence;
		private int octaves;

		static Random rand = new Random ();

		public MapGenerator (int size, float maxValue, int octaves, float persistence, MapTextureType textureType)
		{
			this.size = size;
			this.maxValue = maxValue;
			this.textureType = textureType;
			this.octaves = octaves;
			this.persistence = persistence;

			value = new float[size, size];
			for (int i = 0; i < size; i++)
				for (int j = 0; j < size; j++)
					value[i, j] = 0;

			Perlin ();
			FinalizeValues ();
		}

		private static float Interpolate (float a0, float a1, float t)
		{
			float ft = (float)(t * Math.PI);
			float f = (1 - (float)Math.Cos (ft)) / 2;

			return a0 * (1 - f) + a1 * f;
		}

		private void Perlin ()
		{
			for (int it = 0; it < octaves; it++)
			{
				float amplitude = (float)Math.Pow (persistence, it);
				int freq = (int)Math.Pow (2, it);

				int frequency = size / freq;


				if (frequency < 1)
					return;

				const int X = 0;
				const int Y = 1;

				int gridSize = size / frequency + 2;

				float max = 0, min = 0;

				float[,,] gradients = new float[gridSize, gridSize, 2];

				for (int i = 0; i < gridSize; i++)
				{
					for (int j = 0; j < gridSize; j++)
					{
						double rad = rand.NextDouble () * 2 * Math.PI;
						gradients[i, j, X] = (float)Math.Sin (rad);
						gradients[i, j, Y] = (float)Math.Cos (rad);
					}
				}

				for (int i = 0; i < size; i++)
				{
					for (int j = 0; j < size; j++)
					{
						int ii = i / frequency;
						int jj = j / frequency;

						float tx = (float)(i % frequency) / frequency;
						float ty = (float)(j % frequency) / frequency;

						float n0, n1;

						int dx = ii * frequency - i;
						int dy = jj * frequency - j;
						n0 = dx * gradients[ii, jj, X] + dy * gradients[ii, jj, Y];
						dx = (ii + 1) * frequency - i;
						n1 = dx * gradients[ii + 1, jj, X] + dy * gradients[ii + 1, jj, Y];
						float ix0 = Interpolate (n0, n1, tx);

						dx = ii * frequency - i;
						dy = (jj + 1) * frequency - j;
						n0 = dx * gradients[ii, jj + 1, X] + dy * gradients[ii, jj + 1, Y];
						dx = (ii + 1) * frequency - i;
						n1 = dx * gradients[ii + 1, jj + 1, X] + dy * gradients[ii + 1, jj + 1, Y];
						float ix1 = Interpolate (n0, n1, tx);

						float final = Interpolate (ix0, ix1, ty);

						if (final > max)
							max = final;

						if (final < min)
							min = final;

						value[i, j] += final * amplitude;
					}
				}
			}
		}

		private void FinalizeValues ()
		{
			float max = 0, min = 0;

			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					if (value[i, j] > max)
						max = value[i, j];

					if (value[i, j] < min)
						min = value[i, j];
				}
			}

			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					float absMax = Math.Max (Math.Abs (min), max);

					switch (textureType)
					{
						case MapTextureType.PerlinNoise:
							value[i, j] = (value[i, j] - min) / (max - min) * (maxValue - 1) + 1;
							break;
						case MapTextureType.Marble:
							value[i, j] = ((float)Math.Cos (-value[i, j]) + 1) / 2 * (value[i, j] - min) / (max - min) * (maxValue - 1) + 1;
							break;
						case MapTextureType.Binary:
							value[i, j] = (((value[i, j] - min) / (max - min) * (maxValue - 1)) > ((maxValue - 1) / 2)) ? maxValue : 1;
							break;
						case MapTextureType.BinaryMarble:
							value[i, j] = (((float)Math.Cos (-value[i, j]) + 1) / 2 * (value[i, j] - min) / (max - min) * (maxValue - 1) + 1 > ((maxValue - 1) / 4)) ? maxValue : 1;
							break;
						default:
							break;
					}
				}
			}
		}

		public float[,] GetValues ()
		{
			return value;
		}
	}
}
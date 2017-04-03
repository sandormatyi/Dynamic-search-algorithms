using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace DSA
{
	class MapPanel : Panel
	{
		private static object searchStateSyncroot = new object ();

		private Map map;
		private float ratioX, ratioY;
		private Bitmap mapTexture;
		private List<bool> isSearchStateVisible;

		public List<SearchState> searchStates;

		public MapPanel () : base ()
		{
			Dock = DockStyle.Fill;
			DoubleBuffered = true;

			searchStates = new List<SearchState> (4);
			isSearchStateVisible = new List<bool> (4);

			for (int i = 0; i < 5; i++)
				isSearchStateVisible.Add (true);
		}

		public MapPanel (Map map) : this ()
		{
			this.map = map;
		}

		private void GenerateMapTexture ()
		{
			mapTexture = new Bitmap (ClientSize.Width, ClientSize.Height);
			for (int i = 0; i < map.size; i++)
				for (int j = 0; j < map.size; j++)
					for (float ii = 0; ii < ratioX; ii++)
						for (float jj = 0; jj < ratioY; jj++)
							if (map.maxValue != 1)
								mapTexture.SetPixel ((int)(i * ratioX + ii), (int)(j * ratioY + jj), Color.FromArgb (
									(int)(255 * (1 - (map.mapNodes[i, j].cost - 1) / (map.maxValue - 1))),
									(int)(255 * (1 - (map.mapNodes[i, j].cost - 1) / (map.maxValue - 1))),
									(int)(255 * (1 - (map.mapNodes[i, j].cost - 1) / (map.maxValue - 1)))));
							else
								mapTexture.SetPixel ((int)(i * ratioX + ii), (int)(j * ratioY + jj), Color.White);

			BackgroundImage = mapTexture;
			BackgroundImageLayout = ImageLayout.Stretch;
		}

		public void ToggleSearchStateVisible (int i)
		{
			isSearchStateVisible[i] = !isSearchStateVisible[i];
			Invalidate ();
		}

		protected override void OnPaint (PaintEventArgs e)
		{
			base.OnPaint (e);

			lock (searchStateSyncroot)
			{
				DrawAgentPaths (e);
				DrawAgentDiscoveredNodes (e);
				DrawAgentTraversedNodes (e);
				DrawStartAndGoal (e);
			}
		}

		protected override void OnSizeChanged (EventArgs e)
		{
			base.OnSizeChanged (e);

			ratioX = (float)Width / map.size;
			ratioY = (float)Height / map.size;

			GenerateMapTexture ();
			Invalidate ();
		}

		public void DrawAgentTraversedNodes (PaintEventArgs e)
		{
			foreach (SearchState s in searchStates)
			{
				if (isSearchStateVisible[s.id])
				{
					using (Brush brush = new SolidBrush (Color.FromArgb (144, s.color)))
					{
						foreach (Node n in s.traversedNodes)
							e.Graphics.FillRectangle (brush, n.x * ratioX, n.y * ratioY, ratioX, ratioY);
					}
				}
			}
		}

		public void DrawAgentPaths (PaintEventArgs e)
		{
			foreach (SearchState s in searchStates)
			{
				if (isSearchStateVisible[s.id])
				{
					using (Brush brush = new SolidBrush (Color.FromArgb (96, s.color)))
					{
						foreach (Node n in s.path)
							e.Graphics.FillRectangle (brush, n.x * ratioX, n.y * ratioY, ratioX, ratioY);
					}
				}
			}
		}

		public void DrawAgentDiscoveredNodes (PaintEventArgs e)
		{
			foreach (SearchState s in searchStates)
			{
				if (isSearchStateVisible[s.id])
				{
					using (Brush brush = new SolidBrush (Color.FromArgb (48, s.color)))
					{
						foreach (Node n in s.discoveredNodes)
							e.Graphics.FillRectangle (brush, n.x * ratioX, n.y * ratioY, ratioX, ratioY);
					}
				}
			}
		}

		public void DrawStartAndGoal (PaintEventArgs e)
		{
			using (Brush brush = new SolidBrush (Color.LimeGreen))
			{
				e.Graphics.FillRectangle (brush, map.size / 8 * ratioX, map.size / 8 * ratioY, ratioX, ratioY);
				e.Graphics.FillRectangle (brush, 7 * map.size / 8 * ratioX, 7 * map.size / 8 * ratioY, ratioX, ratioY);
			}
		}

		public void ProgressChanged (SearchState s)
		{
			for (int i = 0; i < searchStates.Count; i++)
			{
				if (searchStates[i].id == s.id)
				{
					lock (searchStateSyncroot)
					{
						searchStates[i] = s;
					}
					Invalidate ();
					return;
				}
			}

			lock (searchStateSyncroot)
			{
				isSearchStateVisible[s.id] = true;
				searchStates.Add (s);
			}
			Invalidate ();
		}
	}
}

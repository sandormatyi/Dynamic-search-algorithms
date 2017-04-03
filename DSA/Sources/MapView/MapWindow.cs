using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;
using System.ComponentModel;

namespace DSA
{
	public partial class MapWindow : Form
	{
		private MapPanel mapPanel;
		private List<AgentHandler> agentHandlers;
		private Dictionary<AgentHandler, AgentPanel> agentPanels;
		private bool paused;

		public MapWindow ()
		{
			InitializeComponent ();
		}

		public MapWindow (Map map, List<AgentHandlerConstructionParameters> agentParams)
			: this ()
		{
			paused = false;
			mapPanel = new MapPanel (map);
			splitContainer.Panel1.Controls.Add (mapPanel);
			InitializeAgentHandlers (agentParams);

			StartSearch ();
		}

		private void InitializeAgentHandlers (List<AgentHandlerConstructionParameters> agentParams)
		{
			Agents.AgentBase.maxID = 0;
			int count = agentParams.Count;

			// Creating the AgentHandlers
			agentHandlers = new List<AgentHandler> (count);

			foreach (AgentHandlerConstructionParameters par in agentParams)
			{
				AgentHandler handler = new AgentHandler (par);
				agentHandlers.Add (handler);
				handler.ReportStateEvent += new ReportStateDelegate (mapPanel.ProgressChanged);
			}

			// Organizing the AgentPanels
			agentPanels = new Dictionary<AgentHandler, AgentPanel> (count);

			if (count > 0)
			{
				agentPanels[agentHandlers[0]] = agentPanel1;
				agentPanel1.Init (agentParams[0]);
				if (count > 1)
				{
					agentPanels[agentHandlers[1]] = agentPanel2;
					agentPanel2.Init (agentParams[1]);
					if (count > 2)
					{
						agentPanels[agentHandlers[2]] = agentPanel3;
						agentPanel3.Init (agentParams[2]);
						if (count > 3)
						{
							agentPanels[agentHandlers[3]] = agentPanel4;
							agentPanel4.Init (agentParams[3]);
						}
					}
				}
			}

			foreach (AgentHandler handler in agentHandlers)
			{
				AgentPanel panel = agentPanels[handler];
				panel.Enabled = panel.Visible = true;
				handler.ReportStateEvent += new ReportStateDelegate (panel.ProgressChanged);
				handler.GoalReachedEvent += new GoalReachedDelegate (panel.GoalReached);
				panel.ToggleSearchStateVisibleEvent += new ToggleSearchStateVisibleDelegate (mapPanel.ToggleSearchStateVisible);
			}
		}

		private void StartSearch ()
		{
			foreach (AgentHandler handler in agentHandlers)
			{
				// Starting the background threads
				Thread thread = new Thread (handler.StartSearch);
				thread.IsBackground = true;
				thread.Start ();
			}
		}

		private void StopSearch ()
		{
			foreach (AgentHandler handler in agentHandlers)
			{
				handler.stopped = true;
			}
		}

		private void pauseButton_Click (object sender, EventArgs e)
		{
			foreach (AgentHandler handler in agentHandlers)
				handler.PauseResumeSearch ();

			if (paused)
			{
				paused = false;
				pauseButton.Text = "Pause";
			}
			else
			{
				paused = true;
				pauseButton.Text = "Continue";
			}
		}

		private void MapWindow_FormClosing (object sender, FormClosingEventArgs e)
		{
			StopSearch ();
		}

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
				return cp;
			}
		}
	}
}

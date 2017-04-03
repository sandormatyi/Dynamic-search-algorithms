using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DSA
{
	public delegate void ToggleSearchStateVisibleDelegate (int id);

	public partial class AgentPanel : UserControl
	{
		private SearchState state;
		private bool goalReached;
		public event ToggleSearchStateVisibleDelegate ToggleSearchStateVisibleEvent;

		public AgentPanel ()
		{
			InitializeComponent ();
			goalReached = false;

			if (AgentHandler.speedLimitEnabled)
			{
				label_constRunTime.Visible = label_constRunTime.Enabled = true;
				label_runTime.Visible = label_runTime.Enabled = true;
			}
		}

		public void Init (AgentHandlerConstructionParameters par)
		{
			label_agentName.ForeColor = par.color;
			label_agentName.Text = AgentTypeToString (par.type);

			Update ();
		}

		public void ProgressChanged (SearchState state)
		{
			this.state = state;
			Invalidate ();
		}

		public void GoalReached ()
		{
			if (!goalReached)
			{
				try
				{
					if (InvokeRequired)
						Invoke (new GoalReachedDelegate (this.GoalReached));
					else
						label_agentName.Text += " (ready)";
					goalReached = true;
				}
				catch (ObjectDisposedException) { }
			}
		}

		private static string AgentTypeToString (AgentType p)
		{
			switch (p)
			{
				case AgentType.Omniscient:
					return "Omniscient";
				case AgentType.AStarOptimistic:
					return "Optimistic A*";
				case AgentType.AStarPessimistic:
					return "Pessimistic A*";
				case AgentType.DStarFocused:
					return "Focused D*";
				case AgentType.DStarLite:
					return "D* Lite";
				case AgentType.DStarOriginal:
					return "Original D*";
				default:
					throw new System.ComponentModel.InvalidEnumArgumentException ();
			}
		}

		protected override void OnPaint (PaintEventArgs e)
		{
			base.OnPaint (e);

			if (state != null)
			{
				label_pathCost.Text = state.distance.ToString ();
				label_procTime.Text = state.procTime.ToString (@"mm\:ss\.fff");
				label_stepNumber.Text = state.stepNumber.ToString ();

				if (AgentHandler.speedLimitEnabled)
					label_runTime.Text = state.runTime.ToString (@"mm\:ss\.fff");
			}
		}

		private void checkBox_visible_CheckedChanged (object sender, EventArgs e)
		{
			if (state != null)
				ToggleSearchStateVisibleEvent (state.id);
		}
	}
}

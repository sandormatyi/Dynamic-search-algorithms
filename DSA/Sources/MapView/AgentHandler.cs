using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Timers;
using System.Diagnostics;

namespace DSA
{
	public enum AgentType
	{
		Omniscient = 0,
		AStarOptimistic = 1,
		AStarPessimistic = 2,
		DStarOriginal = 3,
		DStarFocused = 4,
		DStarLite = 5
	}

	public class SearchState
	{
		public ushort id;
		public uint stepNumber;
		public float distance;
		public TimeSpan procTime;
		public TimeSpan runTime;
		public Node goal;
		public List<Node> path;
		public List<Node> traversedNodes;
		public HashSet<Node> discoveredNodes;
		public Color color;
	}

	public delegate void ReportStateDelegate (SearchState state);
	public delegate void GoalReachedDelegate ();

	public class AgentHandlerConstructionParameters
	{
		public AgentType type;
		public Map map;
		public int startX;
		public int startY;
		public int goalX;
		public int goalY;
		public Color color;
	}

	public class AgentHandler
	{
		private Agents.AgentBase agent;
		public Color color;

		public event ReportStateDelegate ReportStateEvent;
		public event GoalReachedDelegate GoalReachedEvent;

		public bool stopped;
		public bool busy;

		public static bool speedLimitEnabled;
		public static int waitTime;
		private Timer timer;
		private Stopwatch stopWatch_procTime;
		private Stopwatch stopWatch_runTime;
		private TimeSpan runTime_previous;

		public AgentHandler (AgentHandlerConstructionParameters param)
		{
			stopWatch_procTime = new Stopwatch ();
			stopWatch_runTime = new Stopwatch ();
			runTime_previous = new TimeSpan (0);

			if (speedLimitEnabled)
			{
				timer = new Timer (waitTime);
				timer.Elapsed += new ElapsedEventHandler (TimerElapsed);
				timer.Enabled = false;
			}

			switch (param.type)
			{
				case AgentType.Omniscient:
					agent = new Agents.Omniscient (param.map, param.startX, param.startY, param.goalX, param.goalY);
					break;
				case AgentType.AStarOptimistic:
					agent = new Agents.AStarOptimistic (param.map, param.startX, param.startY, param.goalX, param.goalY);
					break;
				case AgentType.AStarPessimistic:
					agent = new Agents.AStarPessimistic (param.map, param.startX, param.startY, param.goalX, param.goalY);
					break;
				case AgentType.DStarOriginal:
					agent = new Agents.DStarOriginal (param.map, param.startX, param.startY, param.goalX, param.goalY);
					break;
				case AgentType.DStarFocused:
					agent = new Agents.DStarFocused (param.map, param.startX, param.startY, param.goalX, param.goalY);
					break;
				case AgentType.DStarLite:
					agent = new Agents.DStarLite (param.map, param.startX, param.startY, param.goalX, param.goalY);
					break;
				default:
					throw new System.ComponentModel.InvalidEnumArgumentException ();
			}
			color = param.color;
			stopped = false;
			busy = false;
		}

		public void PlanRouteAndStep ()
		{
			if (stopped || busy)
			{
				return;
			}

			if (agent.state == Agents.AgentState.Finished)
			{
				GoalReachedEvent ();
				return;
			}

			busy = true;

			SearchState state = new SearchState ();
			state.id = agent.id;
			state.color = color;
			state.goal = agent.goal;

			stopWatch_runTime.Start ();

			// Procesor time measurement
			stopWatch_procTime.Start ();
			state.path = agent.PlanRouteAndStep ();
			stopWatch_procTime.Stop ();
			// Measurement ends

			stopWatch_runTime.Stop ();

			state.procTime = stopWatch_procTime.Elapsed;
			state.runTime = (speedLimitEnabled ? TimeSpan.FromMilliseconds (Math.Max (stopWatch_runTime.ElapsedMilliseconds, waitTime)) : stopWatch_procTime.Elapsed) + runTime_previous;
			runTime_previous = state.runTime;
			stopWatch_runTime.Reset ();

			state.stepNumber = agent.stepNumber;
			state.traversedNodes = agent.GetTraversedNodes ();
			state.discoveredNodes = agent.GetDiscoveredNodes ();
			state.distance = agent.GetDistanceTraveled ();

			ReportStateEvent (state);

			busy = false;

			if (!speedLimitEnabled)
				PlanRouteAndStep ();
		}

		private void TimerElapsed (object sender, ElapsedEventArgs e)
		{
			if (!busy)
				PlanRouteAndStep ();
		}

		public void PauseResumeSearch ()
		{
			if (speedLimitEnabled)
				timer.Enabled = !timer.Enabled;
			else
			{
				stopped = !stopped;

				// Called from the main thread
				System.Threading.Thread thread = new System.Threading.Thread (this.StartSearch);
				thread.IsBackground = true;
				thread.Start ();
			}
		}

		public void StartSearch ()
		{
			if (speedLimitEnabled)
				timer.Enabled = true;
			else
				PlanRouteAndStep ();
		}
	}
}

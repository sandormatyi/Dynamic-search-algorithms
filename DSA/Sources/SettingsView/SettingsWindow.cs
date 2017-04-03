using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DSA
{
	public partial class SettingsForm : Form
	{
		List<AgentHandlerConstructionParameters> agentParams;
		Map generatedMap;
		MapPanel mapPanel;

		public SettingsForm ()
		{
			InitializeComponent ();

			this.comboBox1.SelectedIndex = 3;
			this.comboBox2.SelectedIndex = 4;
			this.comboBox3.SelectedIndex = 5;
			this.comboBox4.SelectedIndex = 6;
			this.comboBox_mapTexture.SelectedIndex = 0;

			this.toolTip.SetToolTip (this.trackBar_speed, trackBar_speed.Minimum + " - " + trackBar_speed.Maximum + " step / second");
		}

		private void startButton_Click (object sender, EventArgs e)
		{
			if (generatedMap == null)
				GenerateMap ();

			InitializeAgentHandlers ();

			if (agentParams != null && agentParams.Count != 0)
				StartSimulation ();
			else
				MessageBox.Show ("Add at least one agent to start the simulation!", "Run failed");
		}

		private void GenerateMap ()
		{
			int size = (int)mapSizeControl.Value;
			int maxValue = (int)numericUpDown_maxValue.Value;
			int octaves = (int)numericUpDown_octaves.Value;
			float persistence = (float)trackBar_persistence.Value / 20;
			MapTextureType textureType = (MapTextureType)comboBox_mapTexture.SelectedIndex;

			generatedMap = new Map (size, maxValue, octaves, persistence, textureType);

			mapPanel = new MapPanel (generatedMap);
			panel_mapPanelContainer.Controls.Clear ();
			panel_mapPanelContainer.Controls.Add (mapPanel);
		}

		private AgentType GetAgentTypeFromComboBox (ComboBox box)
		{
			switch (box.SelectedIndex)
			{
				case 1:
					return AgentType.Omniscient;
				case 2:
					return AgentType.AStarOptimistic;
				case 3:
					return AgentType.AStarPessimistic;
				case 4:
					return AgentType.DStarOriginal;
				case 5:
					return AgentType.DStarFocused;
				case 6:
					return AgentType.DStarLite;
				default:
					throw new InvalidEnumArgumentException ();
			}
		}

		private void InitializeAgentHandlers ()
		{
			int agentsNumber = 0;

			Agents.AgentBase.sightRange = (UInt16)numericUpDown_sightRange.Value;
			AgentHandler.speedLimitEnabled = checkBox_speedLimit.Checked;
			AgentHandler.waitTime = checkBox_speedLimit.Checked ? 1000 / trackBar_speed.Value : 0;

			List<ComboBox> comboBoxes = new List<ComboBox> (4);
			comboBoxes.Add (comboBox1);
			comboBoxes.Add (comboBox2);
			comboBoxes.Add (comboBox3);
			comboBoxes.Add (comboBox4);

			foreach (ComboBox cb in comboBoxes)
			{
				if (cb.SelectedIndex != 0)
					agentsNumber++;
			}
			agentParams = new List<AgentHandlerConstructionParameters> (agentsNumber);

			if (comboBox1.SelectedIndex != 0)
			{
				AgentHandlerConstructionParameters par1 = new AgentHandlerConstructionParameters ();
				par1.type = GetAgentTypeFromComboBox (comboBox1);
				par1.map = generatedMap;
				par1.color = label_color1.BackColor;
				par1.startX = generatedMap.size / 8;
				par1.startY = generatedMap.size / 8;
				par1.goalX = 7 * generatedMap.size / 8;
				par1.goalY = 7 * generatedMap.size / 8;
				agentParams.Add (par1);
			}

			if (comboBox2.SelectedIndex != 0)
			{
				AgentHandlerConstructionParameters par2 = new AgentHandlerConstructionParameters ();
				par2.type = GetAgentTypeFromComboBox (comboBox2);
				par2.map = generatedMap;
				par2.color = label_color2.BackColor;
				par2.startX = generatedMap.size / 8;
				par2.startY = generatedMap.size / 8;
				par2.goalX = 7 * generatedMap.size / 8;
				par2.goalY = 7 * generatedMap.size / 8;
				agentParams.Add (par2);
			}

			if (comboBox3.SelectedIndex != 0)
			{
				AgentHandlerConstructionParameters par3 = new AgentHandlerConstructionParameters ();
				par3.type = GetAgentTypeFromComboBox (comboBox3);
				par3.map = generatedMap;
				par3.color = label_color3.BackColor;
				par3.startX = generatedMap.size / 8;
				par3.startY = generatedMap.size / 8;
				par3.goalX = 7 * generatedMap.size / 8;
				par3.goalY = 7 * generatedMap.size / 8;
				agentParams.Add (par3);
			}

			if (comboBox4.SelectedIndex != 0)
			{
				AgentHandlerConstructionParameters par4 = new AgentHandlerConstructionParameters ();
				par4.type = GetAgentTypeFromComboBox (comboBox4);
				par4.map = generatedMap;
				par4.color = label_color4.BackColor;
				par4.startX = generatedMap.size / 8;
				par4.startY = generatedMap.size / 8;
				par4.goalX = 7 * generatedMap.size / 8;
				par4.goalY = 7 * generatedMap.size / 8;
				agentParams.Add (par4);
			}
		}

		private void StartSimulation ()
		{
			MapWindow mapWindow = new MapWindow (generatedMap, agentParams);
			mapWindow.Show ();
		}

		private void checkBox_speedLimit_CheckedChanged (object sender, EventArgs e)
		{
			if (checkBox_speedLimit.Checked)
				trackBar_speed.Enabled = true;
			else
				trackBar_speed.Enabled = false;
		}

		private void label_color1_Click (object sender, EventArgs e)
		{
			colorDialog.Color = label_color1.BackColor;
			colorDialog.ShowDialog ();
			label_color1.BackColor = colorDialog.Color;
		}

		private void label_color2_Click (object sender, EventArgs e)
		{
			colorDialog.Color = label_color2.BackColor;
			colorDialog.ShowDialog ();
			label_color2.BackColor = colorDialog.Color;
		}

		private void label_color3_Click (object sender, EventArgs e)
		{
			colorDialog.Color = label_color3.BackColor;
			colorDialog.ShowDialog ();
			label_color3.BackColor = colorDialog.Color;
		}

		private void label_color4_Click (object sender, EventArgs e)
		{
			colorDialog.Color = label_color4.BackColor;
			colorDialog.ShowDialog ();
			label_color4.BackColor = colorDialog.Color;
		}

		private void generateMapButton_Click (object sender, EventArgs e)
		{
			GenerateMap ();
		}
	}
}

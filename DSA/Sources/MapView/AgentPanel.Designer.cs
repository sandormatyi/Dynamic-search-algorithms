namespace DSA
{
    partial class AgentPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.label_constPathCost = new System.Windows.Forms.Label();
			this.label_pathCost = new System.Windows.Forms.Label();
			this.checkBox_visible = new System.Windows.Forms.CheckBox();
			this.label_constStepNumber = new System.Windows.Forms.Label();
			this.label_stepNumber = new System.Windows.Forms.Label();
			this.label_constProcTime = new System.Windows.Forms.Label();
			this.label_procTime = new System.Windows.Forms.Label();
			this.label_agentName = new System.Windows.Forms.Label();
			this.label_constRunTime = new System.Windows.Forms.Label();
			this.label_runTime = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label_constPathCost
			// 
			this.label_constPathCost.AutoSize = true;
			this.label_constPathCost.Location = new System.Drawing.Point(3, 52);
			this.label_constPathCost.Name = "label_constPathCost";
			this.label_constPathCost.Size = new System.Drawing.Size(57, 13);
			this.label_constPathCost.TabIndex = 0;
			this.label_constPathCost.Text = "Total cost:";
			// 
			// label_pathCost
			// 
			this.label_pathCost.AutoSize = true;
			this.label_pathCost.Location = new System.Drawing.Point(64, 52);
			this.label_pathCost.Name = "label_pathCost";
			this.label_pathCost.Size = new System.Drawing.Size(13, 13);
			this.label_pathCost.TabIndex = 1;
			this.label_pathCost.Text = "0";
			// 
			// checkBox_visible
			// 
			this.checkBox_visible.AutoSize = true;
			this.checkBox_visible.Checked = true;
			this.checkBox_visible.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_visible.Location = new System.Drawing.Point(3, 18);
			this.checkBox_visible.Name = "checkBox_visible";
			this.checkBox_visible.Size = new System.Drawing.Size(56, 17);
			this.checkBox_visible.TabIndex = 2;
			this.checkBox_visible.Text = "Visible";
			this.checkBox_visible.UseVisualStyleBackColor = true;
			this.checkBox_visible.CheckedChanged += new System.EventHandler(this.checkBox_visible_CheckedChanged);
			// 
			// label_constStepNumber
			// 
			this.label_constStepNumber.AutoSize = true;
			this.label_constStepNumber.Location = new System.Drawing.Point(3, 35);
			this.label_constStepNumber.Name = "label_constStepNumber";
			this.label_constStepNumber.Size = new System.Drawing.Size(37, 13);
			this.label_constStepNumber.TabIndex = 3;
			this.label_constStepNumber.Text = "Steps:";
			// 
			// label_stepNumber
			// 
			this.label_stepNumber.AutoSize = true;
			this.label_stepNumber.Location = new System.Drawing.Point(64, 35);
			this.label_stepNumber.Name = "label_stepNumber";
			this.label_stepNumber.Size = new System.Drawing.Size(13, 13);
			this.label_stepNumber.TabIndex = 4;
			this.label_stepNumber.Text = "0";
			// 
			// label_constProcTime
			// 
			this.label_constProcTime.AutoSize = true;
			this.label_constProcTime.Location = new System.Drawing.Point(3, 69);
			this.label_constProcTime.Name = "label_constProcTime";
			this.label_constProcTime.Size = new System.Drawing.Size(54, 13);
			this.label_constProcTime.TabIndex = 5;
			this.label_constProcTime.Text = "CPU time:";
			// 
			// label_procTime
			// 
			this.label_procTime.AutoSize = true;
			this.label_procTime.Location = new System.Drawing.Point(64, 69);
			this.label_procTime.Name = "label_procTime";
			this.label_procTime.Size = new System.Drawing.Size(13, 13);
			this.label_procTime.TabIndex = 6;
			this.label_procTime.Text = "0";
			// 
			// label_agentName
			// 
			this.label_agentName.AutoSize = true;
			this.label_agentName.Location = new System.Drawing.Point(3, 2);
			this.label_agentName.Name = "label_agentName";
			this.label_agentName.Size = new System.Drawing.Size(35, 13);
			this.label_agentName.TabIndex = 7;
			this.label_agentName.Text = "Agent";
			// 
			// label_constRunTime
			// 
			this.label_constRunTime.AutoSize = true;
			this.label_constRunTime.Enabled = false;
			this.label_constRunTime.Location = new System.Drawing.Point(3, 86);
			this.label_constRunTime.Name = "label_constRunTime";
			this.label_constRunTime.Size = new System.Drawing.Size(49, 13);
			this.label_constRunTime.TabIndex = 8;
			this.label_constRunTime.Text = "Runtime:";
			this.label_constRunTime.Visible = false;
			// 
			// label_runTime
			// 
			this.label_runTime.AutoSize = true;
			this.label_runTime.Enabled = false;
			this.label_runTime.Location = new System.Drawing.Point(64, 86);
			this.label_runTime.Name = "label_runTime";
			this.label_runTime.Size = new System.Drawing.Size(13, 13);
			this.label_runTime.TabIndex = 9;
			this.label_runTime.Text = "0";
			this.label_runTime.Visible = false;
			// 
			// AgentPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.label_runTime);
			this.Controls.Add(this.label_constRunTime);
			this.Controls.Add(this.label_agentName);
			this.Controls.Add(this.label_procTime);
			this.Controls.Add(this.label_constProcTime);
			this.Controls.Add(this.label_stepNumber);
			this.Controls.Add(this.label_constStepNumber);
			this.Controls.Add(this.checkBox_visible);
			this.Controls.Add(this.label_pathCost);
			this.Controls.Add(this.label_constPathCost);
			this.Name = "AgentPanel";
			this.Size = new System.Drawing.Size(116, 116);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_constPathCost;
        private System.Windows.Forms.Label label_pathCost;
        private System.Windows.Forms.CheckBox checkBox_visible;
        private System.Windows.Forms.Label label_constStepNumber;
        private System.Windows.Forms.Label label_stepNumber;
        private System.Windows.Forms.Label label_constProcTime;
        private System.Windows.Forms.Label label_procTime;
        private System.Windows.Forms.Label label_agentName;
        private System.Windows.Forms.Label label_constRunTime;
        private System.Windows.Forms.Label label_runTime;
    }
}

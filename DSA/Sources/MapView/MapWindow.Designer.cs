namespace DSA
{
    partial class MapWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapWindow));
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.pauseButton = new System.Windows.Forms.Button();
			this.agentPanel4 = new DSA.AgentPanel();
			this.agentPanel3 = new DSA.AgentPanel();
			this.agentPanel2 = new DSA.AgentPanel();
			this.agentPanel1 = new DSA.AgentPanel();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer
			// 
			this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainer.IsSplitterFixed = true;
			this.splitContainer.Location = new System.Drawing.Point(0, 0);
			this.splitContainer.Name = "splitContainer";
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Margin = new System.Windows.Forms.Padding(3);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.BackColor = System.Drawing.SystemColors.ControlLight;
			this.splitContainer.Panel2.Controls.Add(this.agentPanel4);
			this.splitContainer.Panel2.Controls.Add(this.agentPanel3);
			this.splitContainer.Panel2.Controls.Add(this.agentPanel2);
			this.splitContainer.Panel2.Controls.Add(this.agentPanel1);
			this.splitContainer.Panel2.Controls.Add(this.pauseButton);
			this.splitContainer.Size = new System.Drawing.Size(680, 557);
			this.splitContainer.SplitterDistance = 525;
			this.splitContainer.SplitterWidth = 1;
			this.splitContainer.TabIndex = 1;
			// 
			// pauseButton
			// 
			this.pauseButton.Location = new System.Drawing.Point(3, 7);
			this.pauseButton.Name = "pauseButton";
			this.pauseButton.Size = new System.Drawing.Size(144, 32);
			this.pauseButton.TabIndex = 1;
			this.pauseButton.Text = "Pause";
			this.pauseButton.UseVisualStyleBackColor = true;
			this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
			// 
			// agentPanel4
			// 
			this.agentPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.agentPanel4.Location = new System.Drawing.Point(3, 430);
			this.agentPanel4.Name = "agentPanel4";
			this.agentPanel4.Size = new System.Drawing.Size(144, 120);
			this.agentPanel4.TabIndex = 5;
			this.agentPanel4.Visible = false;
			// 
			// agentPanel3
			// 
			this.agentPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.agentPanel3.Location = new System.Drawing.Point(3, 304);
			this.agentPanel3.Name = "agentPanel3";
			this.agentPanel3.Size = new System.Drawing.Size(144, 120);
			this.agentPanel3.TabIndex = 4;
			this.agentPanel3.Visible = false;
			// 
			// agentPanel2
			// 
			this.agentPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.agentPanel2.Location = new System.Drawing.Point(3, 178);
			this.agentPanel2.Name = "agentPanel2";
			this.agentPanel2.Size = new System.Drawing.Size(144, 120);
			this.agentPanel2.TabIndex = 3;
			this.agentPanel2.Visible = false;
			// 
			// agentPanel1
			// 
			this.agentPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.agentPanel1.Location = new System.Drawing.Point(3, 52);
			this.agentPanel1.Name = "agentPanel1";
			this.agentPanel1.Size = new System.Drawing.Size(144, 120);
			this.agentPanel1.TabIndex = 2;
			this.agentPanel1.Visible = false;
			// 
			// MapWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(680, 557);
			this.Controls.Add(this.splitContainer);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MapWindow";
			this.Text = "Simulation";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MapWindow_FormClosing);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button pauseButton;
        private AgentPanel agentPanel4;
        private AgentPanel agentPanel3;
        private AgentPanel agentPanel2;
        private AgentPanel agentPanel1;
    }
}
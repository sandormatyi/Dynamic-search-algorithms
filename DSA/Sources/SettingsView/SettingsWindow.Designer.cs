namespace DSA
{
    partial class SettingsForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
			this.startButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.comboBox4 = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.mapSizeControl = new System.Windows.Forms.NumericUpDown();
			this.comboBox_mapTexture = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.numericUpDown_maxValue = new System.Windows.Forms.NumericUpDown();
			this.label13 = new System.Windows.Forms.Label();
			this.numericUpDown_octaves = new System.Windows.Forms.NumericUpDown();
			this.trackBar_persistence = new System.Windows.Forms.TrackBar();
			this.label9 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label_color4 = new System.Windows.Forms.Label();
			this.label_color3 = new System.Windows.Forms.Label();
			this.label_color2 = new System.Windows.Forms.Label();
			this.label_color1 = new System.Windows.Forms.Label();
			this.checkBox_speedLimit = new System.Windows.Forms.CheckBox();
			this.label11 = new System.Windows.Forms.Label();
			this.numericUpDown_sightRange = new System.Windows.Forms.NumericUpDown();
			this.trackBar_speed = new System.Windows.Forms.TrackBar();
			this.label12 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.colorDialog = new System.Windows.Forms.ColorDialog();
			this.panel_mapPanelContainer = new System.Windows.Forms.Panel();
			this.generateMapButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.mapSizeControl)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_maxValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_octaves)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_persistence)).BeginInit();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_sightRange)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_speed)).BeginInit();
			this.SuspendLayout();
			// 
			// startButton
			// 
			this.startButton.Location = new System.Drawing.Point(272, 269);
			this.startButton.Name = "startButton";
			this.startButton.Size = new System.Drawing.Size(108, 23);
			this.startButton.TabIndex = 0;
			this.startButton.Text = "Start simulation";
			this.startButton.UseVisualStyleBackColor = true;
			this.startButton.Click += new System.EventHandler(this.startButton_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 81);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "2. agent:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 117);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(49, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "3. agent:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 153);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(49, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "4. agent:";
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "<Inactive>",
            "Omniscient",
            "Optimistic A*",
            "Pessimistic A*",
            "Original D*",
            "Focused D*",
            "D* Lite"});
			this.comboBox1.Location = new System.Drawing.Point(60, 42);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(119, 21);
			this.comboBox1.TabIndex = 5;
			// 
			// comboBox2
			// 
			this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Items.AddRange(new object[] {
            "<Inactive>",
            "Omniscient",
            "Optimistic A*",
            "Pessimistic A*",
            "Original D*",
            "Focused D*",
            "D* Lite"});
			this.comboBox2.Location = new System.Drawing.Point(60, 78);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(119, 21);
			this.comboBox2.TabIndex = 6;
			// 
			// comboBox3
			// 
			this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox3.FormattingEnabled = true;
			this.comboBox3.Items.AddRange(new object[] {
            "<Inactive>",
            "Omniscient",
            "Optimistic A*",
            "Pessimistic A*",
            "Original D*",
            "Focused D*",
            "D* Lite"});
			this.comboBox3.Location = new System.Drawing.Point(60, 114);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(119, 21);
			this.comboBox3.TabIndex = 7;
			// 
			// comboBox4
			// 
			this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox4.FormattingEnabled = true;
			this.comboBox4.Items.AddRange(new object[] {
            "<Inactive>",
            "Omniscient",
            "Optimistic A*",
            "Pessimistic A*",
            "Original D*",
            "Focused D*",
            "D* Lite"});
			this.comboBox4.Location = new System.Drawing.Point(60, 150);
			this.comboBox4.Name = "comboBox4";
			this.comboBox4.Size = new System.Drawing.Size(119, 21);
			this.comboBox4.TabIndex = 8;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(3, 44);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(52, 13);
			this.label6.TabIndex = 10;
			this.label6.Text = "Map size:";
			// 
			// mapSizeControl
			// 
			this.mapSizeControl.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.mapSizeControl.Location = new System.Drawing.Point(88, 42);
			this.mapSizeControl.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
			this.mapSizeControl.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.mapSizeControl.Name = "mapSizeControl";
			this.mapSizeControl.Size = new System.Drawing.Size(43, 20);
			this.mapSizeControl.TabIndex = 12;
			this.mapSizeControl.Tag = "";
			this.mapSizeControl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.mapSizeControl.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			// 
			// comboBox_mapTexture
			// 
			this.comboBox_mapTexture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_mapTexture.Items.AddRange(new object[] {
            "Perlin noise",
            "Marble",
            "Binary Perlin",
            "Binary marble"});
			this.comboBox_mapTexture.Location = new System.Drawing.Point(88, 77);
			this.comboBox_mapTexture.Name = "comboBox_mapTexture";
			this.comboBox_mapTexture.Size = new System.Drawing.Size(104, 21);
			this.comboBox_mapTexture.TabIndex = 13;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3, 80);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(66, 13);
			this.label5.TabIndex = 14;
			this.label5.Text = "Map texture:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(3, 118);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(83, 13);
			this.label7.TabIndex = 15;
			this.label7.Text = "Octave number:";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(3, 152);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(65, 13);
			this.label8.TabIndex = 16;
			this.label8.Text = "Persistence:";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.Control;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.numericUpDown_maxValue);
			this.panel1.Controls.Add(this.label13);
			this.panel1.Controls.Add(this.numericUpDown_octaves);
			this.panel1.Controls.Add(this.trackBar_persistence);
			this.panel1.Controls.Add(this.label9);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.mapSizeControl);
			this.panel1.Controls.Add(this.comboBox_mapTexture);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Location = new System.Drawing.Point(226, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(197, 232);
			this.panel1.TabIndex = 17;
			// 
			// numericUpDown_maxValue
			// 
			this.numericUpDown_maxValue.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.numericUpDown_maxValue.Location = new System.Drawing.Point(91, 187);
			this.numericUpDown_maxValue.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
			this.numericUpDown_maxValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDown_maxValue.Name = "numericUpDown_maxValue";
			this.numericUpDown_maxValue.Size = new System.Drawing.Size(43, 20);
			this.numericUpDown_maxValue.TabIndex = 21;
			this.numericUpDown_maxValue.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(1, 189);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(71, 13);
			this.label13.TabIndex = 20;
			this.label13.Text = "Maximal cost:";
			// 
			// numericUpDown_octaves
			// 
			this.numericUpDown_octaves.Location = new System.Drawing.Point(93, 116);
			this.numericUpDown_octaves.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.numericUpDown_octaves.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDown_octaves.Name = "numericUpDown_octaves";
			this.numericUpDown_octaves.Size = new System.Drawing.Size(37, 20);
			this.numericUpDown_octaves.TabIndex = 19;
			this.numericUpDown_octaves.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			// 
			// trackBar_persistence
			// 
			this.trackBar_persistence.Location = new System.Drawing.Point(88, 150);
			this.trackBar_persistence.Maximum = 40;
			this.trackBar_persistence.Minimum = 1;
			this.trackBar_persistence.Name = "trackBar_persistence";
			this.trackBar_persistence.Size = new System.Drawing.Size(104, 45);
			this.trackBar_persistence.TabIndex = 18;
			this.trackBar_persistence.TickFrequency = 5;
			this.trackBar_persistence.Value = 20;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(49, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(77, 15);
			this.label9.TabIndex = 17;
			this.label9.Text = "Map settings";
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.Control;
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.label_color4);
			this.panel2.Controls.Add(this.label_color3);
			this.panel2.Controls.Add(this.label_color2);
			this.panel2.Controls.Add(this.label_color1);
			this.panel2.Controls.Add(this.checkBox_speedLimit);
			this.panel2.Controls.Add(this.label11);
			this.panel2.Controls.Add(this.numericUpDown_sightRange);
			this.panel2.Controls.Add(this.trackBar_speed);
			this.panel2.Controls.Add(this.label12);
			this.panel2.Controls.Add(this.label10);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.comboBox4);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.comboBox3);
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.comboBox2);
			this.panel2.Controls.Add(this.comboBox1);
			this.panel2.Location = new System.Drawing.Point(12, 12);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(202, 267);
			this.panel2.TabIndex = 18;
			// 
			// label_color4
			// 
			this.label_color4.AutoSize = true;
			this.label_color4.BackColor = System.Drawing.Color.Gold;
			this.label_color4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label_color4.Location = new System.Drawing.Point(185, 153);
			this.label_color4.Name = "label_color4";
			this.label_color4.Size = new System.Drawing.Size(12, 15);
			this.label_color4.TabIndex = 27;
			this.label_color4.Text = " ";
			this.label_color4.Click += new System.EventHandler(this.label_color4_Click);
			// 
			// label_color3
			// 
			this.label_color3.AutoSize = true;
			this.label_color3.BackColor = System.Drawing.Color.Green;
			this.label_color3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label_color3.Location = new System.Drawing.Point(185, 117);
			this.label_color3.Name = "label_color3";
			this.label_color3.Size = new System.Drawing.Size(12, 15);
			this.label_color3.TabIndex = 26;
			this.label_color3.Text = " ";
			this.label_color3.Click += new System.EventHandler(this.label_color3_Click);
			// 
			// label_color2
			// 
			this.label_color2.AutoSize = true;
			this.label_color2.BackColor = System.Drawing.Color.Blue;
			this.label_color2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label_color2.Location = new System.Drawing.Point(185, 81);
			this.label_color2.Name = "label_color2";
			this.label_color2.Size = new System.Drawing.Size(12, 15);
			this.label_color2.TabIndex = 25;
			this.label_color2.Text = " ";
			this.label_color2.Click += new System.EventHandler(this.label_color2_Click);
			// 
			// label_color1
			// 
			this.label_color1.AutoSize = true;
			this.label_color1.BackColor = System.Drawing.Color.Red;
			this.label_color1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label_color1.Location = new System.Drawing.Point(185, 45);
			this.label_color1.Name = "label_color1";
			this.label_color1.Size = new System.Drawing.Size(12, 15);
			this.label_color1.TabIndex = 24;
			this.label_color1.Text = " ";
			this.label_color1.Click += new System.EventHandler(this.label_color1_Click);
			// 
			// checkBox_speedLimit
			// 
			this.checkBox_speedLimit.AutoSize = true;
			this.checkBox_speedLimit.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBox_speedLimit.Location = new System.Drawing.Point(92, 189);
			this.checkBox_speedLimit.Name = "checkBox_speedLimit";
			this.checkBox_speedLimit.Size = new System.Drawing.Size(15, 14);
			this.checkBox_speedLimit.TabIndex = 23;
			this.checkBox_speedLimit.UseVisualStyleBackColor = true;
			this.checkBox_speedLimit.CheckedChanged += new System.EventHandler(this.checkBox_speedLimit_CheckedChanged);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(3, 225);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(76, 13);
			this.label11.TabIndex = 20;
			this.label11.Text = "Visibility range:";
			// 
			// numericUpDown_sightRange
			// 
			this.numericUpDown_sightRange.Location = new System.Drawing.Point(80, 223);
			this.numericUpDown_sightRange.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.numericUpDown_sightRange.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDown_sightRange.Name = "numericUpDown_sightRange";
			this.numericUpDown_sightRange.Size = new System.Drawing.Size(36, 20);
			this.numericUpDown_sightRange.TabIndex = 21;
			this.numericUpDown_sightRange.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			// 
			// trackBar_speed
			// 
			this.trackBar_speed.Enabled = false;
			this.trackBar_speed.LargeChange = 20;
			this.trackBar_speed.Location = new System.Drawing.Point(113, 186);
			this.trackBar_speed.Minimum = 1;
			this.trackBar_speed.Name = "trackBar_speed";
			this.trackBar_speed.Size = new System.Drawing.Size(82, 45);
			this.trackBar_speed.TabIndex = 20;
			this.trackBar_speed.TickFrequency = 2;
			this.trackBar_speed.Value = 5;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(3, 189);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(61, 13);
			this.label12.TabIndex = 22;
			this.label12.Text = "Speed limit:";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(32, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(83, 15);
			this.label10.TabIndex = 18;
			this.label10.Text = "Agent settings";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 45);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "1. agent:";
			// 
			// colorDialog
			// 
			this.colorDialog.SolidColorOnly = true;
			// 
			// panel_mapPanelContainer
			// 
			this.panel_mapPanelContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel_mapPanelContainer.Location = new System.Drawing.Point(433, 13);
			this.panel_mapPanelContainer.Name = "panel_mapPanelContainer";
			this.panel_mapPanelContainer.Size = new System.Drawing.Size(250, 250);
			this.panel_mapPanelContainer.TabIndex = 19;
			// 
			// generateMapButton
			// 
			this.generateMapButton.Location = new System.Drawing.Point(492, 269);
			this.generateMapButton.Name = "generateMapButton";
			this.generateMapButton.Size = new System.Drawing.Size(118, 23);
			this.generateMapButton.TabIndex = 20;
			this.generateMapButton.Text = "Generate map";
			this.generateMapButton.UseVisualStyleBackColor = true;
			this.generateMapButton.Click += new System.EventHandler(this.generateMapButton_Click);
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(695, 304);
			this.Controls.Add(this.startButton);
			this.Controls.Add(this.generateMapButton);
			this.Controls.Add(this.panel_mapPanelContainer);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "SettingsForm";
			this.Text = "Settings";
			((System.ComponentModel.ISupportInitialize)(this.mapSizeControl)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_maxValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_octaves)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_persistence)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_sightRange)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_speed)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown mapSizeControl;
        private System.Windows.Forms.ComboBox comboBox_mapTexture;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TrackBar trackBar_persistence;
        private System.Windows.Forms.NumericUpDown numericUpDown_octaves;
        private System.Windows.Forms.NumericUpDown numericUpDown_sightRange;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TrackBar trackBar_speed;
        private System.Windows.Forms.CheckBox checkBox_speedLimit;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.NumericUpDown numericUpDown_maxValue;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label_color4;
        private System.Windows.Forms.Label label_color3;
        private System.Windows.Forms.Label label_color2;
        private System.Windows.Forms.Label label_color1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Panel panel_mapPanelContainer;
        private System.Windows.Forms.Button generateMapButton;
    }
}


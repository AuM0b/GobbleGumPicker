namespace GobbleGumPicker
{
    partial class Main
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.GobblegumButton = new System.Windows.Forms.PictureBox();
            this.GobbleGum1Image = new System.Windows.Forms.PictureBox();
            this.GobbleGum2Image = new System.Windows.Forms.PictureBox();
            this.GobbleGum3Image = new System.Windows.Forms.PictureBox();
            this.GobbleGum4Image = new System.Windows.Forms.PictureBox();
            this.GobbleGum5Image = new System.Windows.Forms.PictureBox();
            this.TutorialLabel = new System.Windows.Forms.Label();
            this.GobbleGum1Label = new System.Windows.Forms.Label();
            this.GobbleGum2Label = new System.Windows.Forms.Label();
            this.GobbleGum3Label = new System.Windows.Forms.Label();
            this.GobbleGum4Label = new System.Windows.Forms.Label();
            this.GobbleGum5Label = new System.Windows.Forms.Label();
            this.LeveledCheckBox = new System.Windows.Forms.CheckBox();
            this.WhimsicalCheckBox = new System.Windows.Forms.CheckBox();
            this.VersionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GobblegumButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GobbleGum1Image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GobbleGum2Image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GobbleGum3Image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GobbleGum4Image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GobbleGum5Image)).BeginInit();
            this.SuspendLayout();
            // 
            // GobblegumButton
            // 
            this.GobblegumButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GobblegumButton.Image = global::GobbleGumPicker.Properties.Resources.GobbleGumMachine;
            this.GobblegumButton.Location = new System.Drawing.Point(12, 12);
            this.GobblegumButton.Name = "GobblegumButton";
            this.GobblegumButton.Size = new System.Drawing.Size(114, 360);
            this.GobblegumButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GobblegumButton.TabIndex = 6;
            this.GobblegumButton.TabStop = false;
            this.GobblegumButton.Click += new System.EventHandler(this.GobblegumMachineClick);
            this.GobblegumButton.DoubleClick += new System.EventHandler(this.GobblegumMachineClick);
            // 
            // GobbleGum1Image
            // 
            this.GobbleGum1Image.Location = new System.Drawing.Point(201, 142);
            this.GobbleGum1Image.Name = "GobbleGum1Image";
            this.GobbleGum1Image.Size = new System.Drawing.Size(100, 100);
            this.GobbleGum1Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GobbleGum1Image.TabIndex = 3;
            this.GobbleGum1Image.TabStop = false;
            // 
            // GobbleGum2Image
            // 
            this.GobbleGum2Image.Location = new System.Drawing.Point(307, 142);
            this.GobbleGum2Image.Name = "GobbleGum2Image";
            this.GobbleGum2Image.Size = new System.Drawing.Size(100, 100);
            this.GobbleGum2Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GobbleGum2Image.TabIndex = 1;
            this.GobbleGum2Image.TabStop = false;
            // 
            // GobbleGum3Image
            // 
            this.GobbleGum3Image.Location = new System.Drawing.Point(413, 142);
            this.GobbleGum3Image.Name = "GobbleGum3Image";
            this.GobbleGum3Image.Size = new System.Drawing.Size(100, 100);
            this.GobbleGum3Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GobbleGum3Image.TabIndex = 5;
            this.GobbleGum3Image.TabStop = false;
            // 
            // GobbleGum4Image
            // 
            this.GobbleGum4Image.Location = new System.Drawing.Point(519, 142);
            this.GobbleGum4Image.Name = "GobbleGum4Image";
            this.GobbleGum4Image.Size = new System.Drawing.Size(100, 100);
            this.GobbleGum4Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GobbleGum4Image.TabIndex = 4;
            this.GobbleGum4Image.TabStop = false;
            // 
            // GobbleGum5Image
            // 
            this.GobbleGum5Image.Location = new System.Drawing.Point(625, 142);
            this.GobbleGum5Image.Name = "GobbleGum5Image";
            this.GobbleGum5Image.Size = new System.Drawing.Size(100, 100);
            this.GobbleGum5Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GobbleGum5Image.TabIndex = 2;
            this.GobbleGum5Image.TabStop = false;
            // 
            // TutorialLabel
            // 
            this.TutorialLabel.AutoSize = true;
            this.TutorialLabel.Font = new System.Drawing.Font("FoundryGridnik", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TutorialLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.TutorialLabel.Location = new System.Drawing.Point(192, 178);
            this.TutorialLabel.Name = "TutorialLabel";
            this.TutorialLabel.Size = new System.Drawing.Size(541, 22);
            this.TutorialLabel.TabIndex = 8;
            this.TutorialLabel.Text = "Press on GobbleGum Machine to roll a GobbleGum Pack!";
            // 
            // GobbleGum1Label
            // 
            this.GobbleGum1Label.Font = new System.Drawing.Font("Escom-Regular", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GobbleGum1Label.ForeColor = System.Drawing.SystemColors.Control;
            this.GobbleGum1Label.Location = new System.Drawing.Point(201, 245);
            this.GobbleGum1Label.Name = "GobbleGum1Label";
            this.GobbleGum1Label.Size = new System.Drawing.Size(100, 33);
            this.GobbleGum1Label.TabIndex = 9;
            this.GobbleGum1Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GobbleGum2Label
            // 
            this.GobbleGum2Label.Font = new System.Drawing.Font("Escom-Regular", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GobbleGum2Label.ForeColor = System.Drawing.SystemColors.Control;
            this.GobbleGum2Label.Location = new System.Drawing.Point(307, 245);
            this.GobbleGum2Label.Name = "GobbleGum2Label";
            this.GobbleGum2Label.Size = new System.Drawing.Size(100, 33);
            this.GobbleGum2Label.TabIndex = 10;
            this.GobbleGum2Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GobbleGum3Label
            // 
            this.GobbleGum3Label.Font = new System.Drawing.Font("Escom-Regular", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GobbleGum3Label.ForeColor = System.Drawing.SystemColors.Control;
            this.GobbleGum3Label.Location = new System.Drawing.Point(413, 245);
            this.GobbleGum3Label.Name = "GobbleGum3Label";
            this.GobbleGum3Label.Size = new System.Drawing.Size(100, 33);
            this.GobbleGum3Label.TabIndex = 11;
            this.GobbleGum3Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GobbleGum4Label
            // 
            this.GobbleGum4Label.Font = new System.Drawing.Font("Escom-Regular", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GobbleGum4Label.ForeColor = System.Drawing.SystemColors.Control;
            this.GobbleGum4Label.Location = new System.Drawing.Point(519, 245);
            this.GobbleGum4Label.Name = "GobbleGum4Label";
            this.GobbleGum4Label.Size = new System.Drawing.Size(100, 33);
            this.GobbleGum4Label.TabIndex = 12;
            this.GobbleGum4Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GobbleGum5Label
            // 
            this.GobbleGum5Label.Font = new System.Drawing.Font("Escom-Regular", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GobbleGum5Label.ForeColor = System.Drawing.SystemColors.Control;
            this.GobbleGum5Label.Location = new System.Drawing.Point(625, 245);
            this.GobbleGum5Label.Name = "GobbleGum5Label";
            this.GobbleGum5Label.Size = new System.Drawing.Size(100, 33);
            this.GobbleGum5Label.TabIndex = 13;
            this.GobbleGum5Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LeveledCheckBox
            // 
            this.LeveledCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.LeveledCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LeveledCheckBox.Checked = true;
            this.LeveledCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LeveledCheckBox.FlatAppearance.BorderSize = 0;
            this.LeveledCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(88)))), ((int)(((byte)(5)))));
            this.LeveledCheckBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(44)))), ((int)(((byte)(5)))));
            this.LeveledCheckBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(122)))), ((int)(((byte)(5)))));
            this.LeveledCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LeveledCheckBox.Font = new System.Drawing.Font("Escom-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeveledCheckBox.ForeColor = System.Drawing.Color.White;
            this.LeveledCheckBox.Location = new System.Drawing.Point(586, 12);
            this.LeveledCheckBox.Name = "LeveledCheckBox";
            this.LeveledCheckBox.Size = new System.Drawing.Size(98, 28);
            this.LeveledCheckBox.TabIndex = 15;
            this.LeveledCheckBox.TabStop = false;
            this.LeveledCheckBox.Text = "Leveled";
            this.LeveledCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ToolTip.SetToolTip(this.LeveledCheckBox, "Enable or disable rolling of level-awarded GobbleGums (Impatient, Sword Flay, etc" +
        ".)");
            this.LeveledCheckBox.UseVisualStyleBackColor = false;
            this.LeveledCheckBox.CheckedChanged += new System.EventHandler(this.LeveledCheckedChanged);
            // 
            // WhimsicalCheckBox
            // 
            this.WhimsicalCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.WhimsicalCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.WhimsicalCheckBox.Checked = true;
            this.WhimsicalCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.WhimsicalCheckBox.FlatAppearance.BorderSize = 0;
            this.WhimsicalCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(88)))), ((int)(((byte)(5)))));
            this.WhimsicalCheckBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(44)))), ((int)(((byte)(5)))));
            this.WhimsicalCheckBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(122)))), ((int)(((byte)(5)))));
            this.WhimsicalCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WhimsicalCheckBox.Font = new System.Drawing.Font("Escom-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WhimsicalCheckBox.ForeColor = System.Drawing.Color.White;
            this.WhimsicalCheckBox.Location = new System.Drawing.Point(690, 12);
            this.WhimsicalCheckBox.Name = "WhimsicalCheckBox";
            this.WhimsicalCheckBox.Size = new System.Drawing.Size(98, 28);
            this.WhimsicalCheckBox.TabIndex = 16;
            this.WhimsicalCheckBox.TabStop = false;
            this.WhimsicalCheckBox.Text = "Whimsical";
            this.WhimsicalCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ToolTip.SetToolTip(this.WhimsicalCheckBox, "Enable or disable rolling of Whimsical GobbleGums (Eye Candy, Tone Death, etc.)");
            this.WhimsicalCheckBox.UseVisualStyleBackColor = false;
            this.WhimsicalCheckBox.CheckedChanged += new System.EventHandler(this.WhimsicalCheckedChanged);
            // 
            // VersionLabel
            // 
            this.VersionLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VersionLabel.Font = new System.Drawing.Font("Escom-Regular", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.VersionLabel.Location = new System.Drawing.Point(700, 370);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(100, 12);
            this.VersionLabel.TabIndex = 17;
            this.VersionLabel.Text = "1.0.0.0";
            this.VersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(800, 384);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.WhimsicalCheckBox);
            this.Controls.Add(this.LeveledCheckBox);
            this.Controls.Add(this.GobbleGum1Label);
            this.Controls.Add(this.GobbleGum2Label);
            this.Controls.Add(this.GobbleGum3Label);
            this.Controls.Add(this.GobbleGum4Label);
            this.Controls.Add(this.GobbleGum5Label);
            this.Controls.Add(this.TutorialLabel);
            this.Controls.Add(this.GobblegumButton);
            this.Controls.Add(this.GobbleGum1Image);
            this.Controls.Add(this.GobbleGum2Image);
            this.Controls.Add(this.GobbleGum3Image);
            this.Controls.Add(this.GobbleGum4Image);
            this.Controls.Add(this.GobbleGum5Image);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GobbleGum Picker";
            ((System.ComponentModel.ISupportInitialize)(this.GobblegumButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GobbleGum1Image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GobbleGum2Image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GobbleGum3Image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GobbleGum4Image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GobbleGum5Image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.PictureBox GobbleGum1Image;
        private System.Windows.Forms.PictureBox GobbleGum2Image;
        private System.Windows.Forms.PictureBox GobbleGum3Image;
        private System.Windows.Forms.PictureBox GobbleGum4Image;
        private System.Windows.Forms.PictureBox GobbleGum5Image;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.PictureBox GobblegumButton;
        private System.Windows.Forms.Label TutorialLabel;
        private System.Windows.Forms.Label GobbleGum1Label;
        private System.Windows.Forms.Label GobbleGum2Label;
        private System.Windows.Forms.Label GobbleGum3Label;
        private System.Windows.Forms.Label GobbleGum4Label;
        private System.Windows.Forms.Label GobbleGum5Label;
        private System.Windows.Forms.CheckBox LeveledCheckBox;
        private System.Windows.Forms.CheckBox WhimsicalCheckBox;
        private System.Windows.Forms.Label VersionLabel;
    }
}


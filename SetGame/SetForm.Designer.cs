
namespace SetGame
{
	partial class SetForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetForm));
			this.CardButtonTemplate = new System.Windows.Forms.Button();
			this.NoSetButton = new System.Windows.Forms.Button();
			this.ScoreLabel = new System.Windows.Forms.Label();
			this.NewGameButton = new System.Windows.Forms.Button();
			this.LargeButton = new System.Windows.Forms.RadioButton();
			this.MediumButton = new System.Windows.Forms.RadioButton();
			this.SmallButton = new System.Windows.Forms.RadioButton();
			this.Timer = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// CardButtonTemplate
			// 
			this.CardButtonTemplate.Location = new System.Drawing.Point(12, 50);
			this.CardButtonTemplate.Name = "CardButtonTemplate";
			this.CardButtonTemplate.Size = new System.Drawing.Size(128, 128);
			this.CardButtonTemplate.TabIndex = 0;
			this.CardButtonTemplate.UseVisualStyleBackColor = true;
			this.CardButtonTemplate.Visible = false;
			this.CardButtonTemplate.Click += new System.EventHandler(this.CardButton_Click);
			// 
			// NoSetButton
			// 
			this.NoSetButton.Location = new System.Drawing.Point(12, 13);
			this.NoSetButton.Name = "NoSetButton";
			this.NoSetButton.Size = new System.Drawing.Size(128, 23);
			this.NoSetButton.TabIndex = 1;
			this.NoSetButton.Text = "Geen Set";
			this.NoSetButton.UseVisualStyleBackColor = true;
			this.NoSetButton.Click += new System.EventHandler(this.AddButton_Click);
			// 
			// ScoreLabel
			// 
			this.ScoreLabel.AutoSize = true;
			this.ScoreLabel.Location = new System.Drawing.Point(146, 16);
			this.ScoreLabel.Name = "ScoreLabel";
			this.ScoreLabel.Size = new System.Drawing.Size(49, 17);
			this.ScoreLabel.TabIndex = 2;
			this.ScoreLabel.Text = "Score:";
			// 
			// NewGameButton
			// 
			this.NewGameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.NewGameButton.Location = new System.Drawing.Point(1169, 13);
			this.NewGameButton.Name = "NewGameButton";
			this.NewGameButton.Size = new System.Drawing.Size(94, 23);
			this.NewGameButton.TabIndex = 3;
			this.NewGameButton.Text = "Opnieuw";
			this.NewGameButton.UseVisualStyleBackColor = true;
			this.NewGameButton.Click += new System.EventHandler(this.NewGameButton_Click);
			// 
			// LargeButton
			// 
			this.LargeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.LargeButton.AutoSize = true;
			this.LargeButton.Location = new System.Drawing.Point(1098, 14);
			this.LargeButton.Name = "LargeButton";
			this.LargeButton.Size = new System.Drawing.Size(65, 21);
			this.LargeButton.TabIndex = 4;
			this.LargeButton.Text = "Groot";
			this.LargeButton.UseVisualStyleBackColor = true;
			this.LargeButton.CheckedChanged += new System.EventHandler(this.LargeButton_CheckedChanged);
			// 
			// MediumButton
			// 
			this.MediumButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.MediumButton.AutoSize = true;
			this.MediumButton.Checked = true;
			this.MediumButton.Location = new System.Drawing.Point(1022, 14);
			this.MediumButton.Name = "MediumButton";
			this.MediumButton.Size = new System.Drawing.Size(70, 21);
			this.MediumButton.TabIndex = 5;
			this.MediumButton.TabStop = true;
			this.MediumButton.Text = "Middel";
			this.MediumButton.UseVisualStyleBackColor = true;
			this.MediumButton.CheckedChanged += new System.EventHandler(this.MediumButton_CheckedChanged);
			// 
			// SmallButton
			// 
			this.SmallButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SmallButton.AutoSize = true;
			this.SmallButton.Location = new System.Drawing.Point(946, 14);
			this.SmallButton.Name = "SmallButton";
			this.SmallButton.Size = new System.Drawing.Size(60, 21);
			this.SmallButton.TabIndex = 6;
			this.SmallButton.Text = "Klein";
			this.SmallButton.UseVisualStyleBackColor = true;
			this.SmallButton.CheckedChanged += new System.EventHandler(this.SmallButton_CheckedChanged);
			// 
			// Timer
			// 
			this.Timer.Enabled = true;
			this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
			// 
			// SetForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1275, 553);
			this.Controls.Add(this.SmallButton);
			this.Controls.Add(this.MediumButton);
			this.Controls.Add(this.LargeButton);
			this.Controls.Add(this.NewGameButton);
			this.Controls.Add(this.ScoreLabel);
			this.Controls.Add(this.NoSetButton);
			this.Controls.Add(this.CardButtonTemplate);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "SetForm";
			this.Text = "Set";
			this.Load += new System.EventHandler(this.SetForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button CardButtonTemplate;
		private System.Windows.Forms.Button NoSetButton;
		private System.Windows.Forms.Label ScoreLabel;
		private System.Windows.Forms.Button NewGameButton;
		private System.Windows.Forms.RadioButton LargeButton;
		private System.Windows.Forms.RadioButton MediumButton;
		private System.Windows.Forms.RadioButton SmallButton;
		private System.Windows.Forms.Timer Timer;
	}
}


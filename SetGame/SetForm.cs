using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SetGame
{
	public partial class SetForm : Form
	{
		private bool RememberMissed = false; 
		public int ErrorCount { get; private set; } = 0;
		public int CorrectCount { get; private set; } = 0;
		public List<Button> Buttons { get; } = new List<Button>();
		public List<bool> Active { get; } = new List<bool>(); 
		public Game Game { get; private set; } = new Game();
		public List<Image> Images { get; } = new List<Image>();
		public Stopwatch Stopwatch { get; } = new Stopwatch(); 

		public int sizeSmall = 128;
		public int sizeMedium = 192;
		public int sizeLarge = 256;
		public int margin = 10; 

		public SetForm()
		{
			InitializeComponent();
			for (int i = 0; i < 81; i++)
			{
				Card card = new Card(i); 
				Image image = card.Compose();
				Images.Add(image); 
			}

			Rebutton();
			RefreshActiveness();
			Stopwatch.Start(); 
		}


		private void NewGameButton_Click(object sender, EventArgs e)
		{
			RememberMissed = false;
			ErrorCount = 0;
			CorrectCount = 0;
			Game = new Game(); 

			Rebutton();
			RefreshActiveness();
			Stopwatch.Restart(); 
		}

		private void Rebutton()
		{
			foreach (Button button in Buttons)
			{
				button.Dispose(); 
			}
			Buttons.Clear();
			Active.Clear(); 
			
			foreach (Card card in Game.OpenCards)
			{
				Button button = CreateButton(card, Buttons.Count);
				Buttons.Add(button);
				Active.Add(false); 
			}
			RefreshActiveness(); 
		}

		private Button CreateButton(Card card, int index)
		{
			int column = index / 3;
			int row = index % 3;

			
			Button button = new Button();
			int buttonSize = sizeSmall;
			if (MediumButton.Checked)
				buttonSize = sizeMedium;
			if (LargeButton.Checked)
				buttonSize = sizeLarge;

			int size = buttonSize + margin;  ;

			button.Size = new Size(buttonSize,buttonSize);
			button.Location = new Point(CardButtonTemplate.Location.X + column * size, 
				CardButtonTemplate.Location.Y + row * size);
			button.Click += CardButton_Click;
			button.Parent = this;

			button.Text = "";
			

			button.BackgroundImage = Images[card.index];
			button.BackgroundImageLayout = ImageLayout.Stretch;
			return button; 
		}

		

		private void CardButton_Click(object sender, EventArgs e)
		{
			Button clicked = sender as Button;
			if (clicked == null)
				return;
			for (int i = 0; i < Buttons.Count; i++)
			{
				if (Buttons[i] == clicked)
				{
					ButtonClicked(i); 
				}
			}
		}

		private void ButtonClicked(int index)
		{
			Active[index] = !Active[index];
			if (Active[index])
			{
				Active[index] = true; 
				List<Card> activeCards = new List<Card>();
				for (int i = 0; i < Active.Count; i++)
				{
					if (Active[i])
						activeCards.Add(Game.OpenCards[i]);
				}
				if (activeCards.Count == 3)
				{
					if (Set.IsSet(activeCards[0], activeCards[1], activeCards[2]))
					{
						if (RememberMissed)
							RememberMissed = false;
						else
							CorrectCount++;
						if (Game.OpenCards.Count <= 12)
							Game.Draw(activeCards);
						else
						{
							foreach (Card card in activeCards)
								Game.Remove(card);
						}

						Rebutton();
					}
					else
					{
						ErrorCount++;
						for (int i = 0; i < Active.Count; i++)
							Active[i] = false;
					}
				}
			}

			RefreshActiveness(); 
		}

		private void RefreshActiveness()
		{
			for (int i = 0; i < Active.Count; i++)
			{
				if (Active[i])
				{
					Buttons[i].FlatStyle = FlatStyle.Flat;
					Buttons[i].FlatAppearance.BorderColor = Color.Black;
					Buttons[i].FlatAppearance.BorderSize = 3;
				}
				else
				{
					Buttons[i].FlatStyle = FlatStyle.Flat;
					Buttons[i].FlatAppearance.BorderColor = Color.White;
					Buttons[i].FlatAppearance.BorderSize = 0;
				}
			}
			RefreshLabel(); 
		}

		private void RefreshLabel()
		{
			ScoreLabel.Text = "Goed: " + CorrectCount.ToString() + 
				" Fout: " + ErrorCount.ToString() + " Tijd: " + Stopwatch.Elapsed.ToString("mm\\:ss"); 
		}

		private void SetForm_Load(object sender, EventArgs e)
		{

		}

		private void AddButton_Click(object sender, EventArgs e)
		{

			for (int a = 0; a < Game.OpenCards.Count; a++)
				for (int b = a + 1; b < Game.OpenCards.Count; b++)
					for (int c = b + 1; c < Game.OpenCards.Count; c++)
						if (Set.IsSet(Game.OpenCards[a], Game.OpenCards[b], Game.OpenCards[c]))
						{
							for (int i = 0; i < Active.Count; i++)
								Active[i] = false;
							RefreshActiveness();

							Buttons[a].FlatStyle = FlatStyle.Flat;
							Buttons[a].FlatAppearance.BorderColor = Color.Red;
							Buttons[a].FlatAppearance.BorderSize = 3;
							Buttons[b].FlatStyle = FlatStyle.Flat;
							Buttons[b].FlatAppearance.BorderColor = Color.Red;
							Buttons[b].FlatAppearance.BorderSize = 3;
							Buttons[c].FlatStyle = FlatStyle.Flat;
							Buttons[c].FlatAppearance.BorderColor = Color.Red;
							Buttons[c].FlatAppearance.BorderSize = 3;

							ErrorCount++;
							RememberMissed = true; 
							RefreshLabel();
							return;
						}
			int count = Game.OpenCards.Count();
			Game.Draw();
			Rebutton();

			if (count == Game.OpenCards.Count)
			{
				Stopwatch.Stop(); 
				MessageBox.Show("Klaar!\n"+Stopwatch.Elapsed.ToString()); 
			}
		}

		private void SmallButton_CheckedChanged(object sender, EventArgs e)
		{
			Rebutton(); 
		}

		private void MediumButton_CheckedChanged(object sender, EventArgs e)
		{
			Rebutton();
		}

		private void LargeButton_CheckedChanged(object sender, EventArgs e)
		{
			Rebutton(); 
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			RefreshLabel(); 
		}
	}
}

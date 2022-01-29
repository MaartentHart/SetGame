using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetGame
{
	public class Game
	{
		public List<Card> OpenCards { get; } = new List<Card>();
		public Deck Deck { get; } = new Deck();
		public int Drawn { get; private set; } = 0;

		public Game()
		{
			Draw(); 
		}

		public void Draw(List<Card> removeCards = null)
		{
			int target = Drawn + 3;

			if (OpenCards.Count == 0)
				target = 12; 
			
			if (target > 81)
				target = 81;

			if (OpenCards.Count == 12 && removeCards != null && target!=Drawn)
			{
				int replaced = 0;

				for (; Drawn < target; Drawn++, replaced++)
				{
					if (replaced >= removeCards.Count)
						OpenCards.Add(Deck.Cards[Drawn]);
					else
					{
						for (int i = 0; i < OpenCards.Count; i++)
						{
							if (OpenCards[i].index == removeCards[replaced].index)
							{
								OpenCards[i] = Deck.Cards[Drawn];
							}
						}

					}
				}
				return;
			}
			else if (OpenCards.Count <= 12 && removeCards != null)
			{
				foreach (Card card in removeCards)
				{
					for (int i = 0; i < OpenCards.Count; i++)
						if (OpenCards[i].index == card.index)
							OpenCards.RemoveAt(i); 
				}
			}

			for (; Drawn < target; Drawn++)
				OpenCards.Add(Deck.Cards[Drawn]); 			
		}

		public void Remove(Card card)
		{
			for (int i = 0; i < OpenCards.Count; i++)
			{
				if (OpenCards[i].index == card.index)
				{
					OpenCards.RemoveAt(i);
					return; 
				}
			}
		}

	}
}

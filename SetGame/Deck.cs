using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetGame
{
	public class Deck
	{
		public Card[] Cards {get;}
		public Deck()
		{
			List<Card> sorted = new List<Card>();
			for (int i = 0; i < 81; i++)
				sorted.Add(new Card(i));

			//shuffle
			Cards = new Card[81];

			Random random = new Random();

			for (int i = 0; i < 81; i++)
			{
				int pick = random.Next(0, 81 - i);
				Cards[i] = sorted[pick];
				sorted.RemoveAt(pick); 
			}
		}
	}
}

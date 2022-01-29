using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetGame
{
	public static class Set
	{
		public static bool IsSetProperty(int a, int b, int c)
		{
			if (a == b && a == c)
				return true;
			if (a == b || a == c || b == c)
				return false;
			return true; 
		}

		public static bool IsSet(Card a, Card b, Card c)
		{
			if (a.index == b.index || a.index == c.index || b.index == c.index)
				throw new Exception("Sets cannot consist of 2 identical cards");
			if (!IsSetProperty(a.color, b.color, c.color))
				return false;
			if (!IsSetProperty(a.amount, b.amount, c.amount))
				return false;
			if (!IsSetProperty(a.fill, b.fill, c.fill))
				return false;
			if (!IsSetProperty(a.shape, b.shape, c.shape))
				return false;
			return true; 
			
		}
	}
}

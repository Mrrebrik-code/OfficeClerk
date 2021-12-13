using Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
	public class Transaction
	{
		public int Price { get; private set; }
		public TypeTransaction Type {get; private set;}

		public Transaction(int price, TypeTransaction type)
		{
			Price = price;
			Type = type;
		}
	}
}

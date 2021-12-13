using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
	public interface IValue
	{
		int Count { get; set; }
		bool Put(int count);
		void Put(int count, Action<bool> callback);
		bool Withdraw(int count);
		void Withdraw(int count, Action<bool> callback);
	}
}

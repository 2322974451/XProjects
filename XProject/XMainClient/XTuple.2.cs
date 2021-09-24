using System;

namespace XMainClient
{

	internal class XTuple<T1, T2, T3>
	{

		public XTuple(T1 t1, T2 t2, T3 t3)
		{
			this.Item1 = t1;
			this.Item2 = t2;
			this.Item3 = t3;
		}

		public XTuple()
		{
		}

		public T1 Item1;

		public T2 Item2;

		public T3 Item3;
	}
}

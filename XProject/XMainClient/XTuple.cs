using System;

namespace XMainClient
{

	internal class XTuple<T1, T2>
	{

		public XTuple(T1 t1, T2 t2)
		{
			this.Item1 = t1;
			this.Item2 = t2;
		}

		public XTuple()
		{
		}

		public T1 Item1;

		public T2 Item2;
	}
}

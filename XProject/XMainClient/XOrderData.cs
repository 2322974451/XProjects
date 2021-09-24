using System;

namespace XMainClient
{

	internal struct XOrderData<T1, T2> : IComparable<XOrderData<T1, T2>> where T1 : IComparable
	{

		public int CompareTo(XOrderData<T1, T2> other)
		{
			return this.x.CompareTo(other.x);
		}

		public T1 x;

		public T2 y;
	}
}

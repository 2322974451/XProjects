using System;

namespace XMainClient
{

	internal class XLFUItem<T> : IComparable<XLFUItem<T>>
	{

		public bool bCanPop
		{
			get
			{
				return this.canPop < 0;
			}
			set
			{
				this.canPop = (value ? -1 : 1);
			}
		}

		public int CompareTo(XLFUItem<T> other)
		{
			bool flag = this.canPop == other.canPop;
			int result;
			if (flag)
			{
				result = this.frequent.CompareTo(other.frequent);
			}
			else
			{
				result = this.canPop.CompareTo(other.canPop);
			}
			return result;
		}

		public T data;

		public uint frequent = 0U;

		public int index;

		private int canPop;
	}
}

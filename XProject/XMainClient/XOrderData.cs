using System;

namespace XMainClient
{
	// Token: 0x02000892 RID: 2194
	internal struct XOrderData<T1, T2> : IComparable<XOrderData<T1, T2>> where T1 : IComparable
	{
		// Token: 0x060085C1 RID: 34241 RVA: 0x0010BC50 File Offset: 0x00109E50
		public int CompareTo(XOrderData<T1, T2> other)
		{
			return this.x.CompareTo(other.x);
		}

		// Token: 0x04002991 RID: 10641
		public T1 x;

		// Token: 0x04002992 RID: 10642
		public T2 y;
	}
}

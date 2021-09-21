using System;

namespace XUtliPoolLib
{
	// Token: 0x020000D1 RID: 209
	public interface ISeqRef<T>
	{
		// Token: 0x170000A3 RID: 163
		T this[int key]
		{
			get;
		}
	}
}

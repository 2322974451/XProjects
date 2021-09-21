using System;

namespace XUtliPoolLib
{
	// Token: 0x020000CF RID: 207
	public interface ISeqListRef<T>
	{
		// Token: 0x170000A1 RID: 161
		T this[int index, int key]
		{
			get;
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x060005C6 RID: 1478
		int Count { get; }
	}
}

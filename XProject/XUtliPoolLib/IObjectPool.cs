using System;

namespace XUtliPoolLib
{
	// Token: 0x02000191 RID: 401
	public interface IObjectPool
	{
		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060008B6 RID: 2230
		int countAll { get; }

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060008B7 RID: 2231
		int countActive { get; }

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060008B8 RID: 2232
		int countInactive { get; }
	}
}

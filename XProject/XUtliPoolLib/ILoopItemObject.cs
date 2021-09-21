using System;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x0200005E RID: 94
	public interface ILoopItemObject
	{
		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000305 RID: 773
		// (set) Token: 0x06000306 RID: 774
		int dataIndex { get; set; }

		// Token: 0x06000307 RID: 775
		bool isVisible();

		// Token: 0x06000308 RID: 776
		GameObject GetObj();

		// Token: 0x06000309 RID: 777
		void SetHeight(int height);
	}
}

using System;
using System.Collections.Generic;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x02000060 RID: 96
	public interface ILoopScrollView
	{
		// Token: 0x0600030D RID: 781
		void Init(List<LoopItemData> datas, DelegateHandler onItemInitCallback, Action onDragfinish, int pivot = 0, bool forceRefreshPerTime = false);

		// Token: 0x0600030E RID: 782
		GameObject GetTpl();

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x0600030F RID: 783
		GameObject gameobject { get; }

		// Token: 0x06000310 RID: 784
		bool IsScrollLast();

		// Token: 0x06000311 RID: 785
		void ResetScroll();

		// Token: 0x06000312 RID: 786
		void SetDepth(int delpth);

		// Token: 0x06000313 RID: 787
		GameObject GetFirstItem();

		// Token: 0x06000314 RID: 788
		GameObject GetLastItem();

		// Token: 0x06000315 RID: 789
		void AddItem(LoopItemData data);

		// Token: 0x06000316 RID: 790
		void SetClipSize(Vector2 size);
	}
}

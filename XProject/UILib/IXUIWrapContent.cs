using System;
using System.Collections.Generic;
using UnityEngine;

namespace UILib
{
	// Token: 0x02000045 RID: 69
	public interface IXUIWrapContent : IXUIObject
	{
		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060001D3 RID: 467
		// (set) Token: 0x060001D4 RID: 468
		bool enableBounds { get; set; }

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060001D5 RID: 469
		// (set) Token: 0x060001D6 RID: 470
		Vector2 itemSize { get; set; }

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060001D7 RID: 471
		// (set) Token: 0x060001D8 RID: 472
		int widthDimension { get; set; }

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060001D9 RID: 473
		int heightDimensionMax { get; }

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060001DA RID: 474
		int maxItemCount { get; }

		// Token: 0x060001DB RID: 475
		void SetContentCount(int num, bool fadeIn = false);

		// Token: 0x060001DC RID: 476
		void SetOffset(int offset);

		// Token: 0x060001DD RID: 477
		void RegisterItemUpdateEventHandler(WrapItemUpdateEventHandler eventHandler);

		// Token: 0x060001DE RID: 478
		void RegisterItemInitEventHandler(WrapItemInitEventHandler eventHandler);

		// Token: 0x060001DF RID: 479
		void InitContent();

		// Token: 0x060001E0 RID: 480
		void RefreshAllVisibleContents();

		// Token: 0x060001E1 RID: 481
		void GetActiveList(List<GameObject> ret);
	}
}

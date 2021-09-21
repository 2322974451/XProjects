using System;
using UnityEngine;

namespace UILib
{
	// Token: 0x02000041 RID: 65
	public interface IXUIPanel : IXUIObject
	{
		// Token: 0x060001B6 RID: 438
		void SetSize(float width, float height);

		// Token: 0x060001B7 RID: 439
		void SetCenter(float width, float height);

		// Token: 0x060001B8 RID: 440
		void SetAlpha(float a);

		// Token: 0x060001B9 RID: 441
		float GetAlpha();

		// Token: 0x060001BA RID: 442
		void SetDepth(int d);

		// Token: 0x060001BB RID: 443
		int GetDepth();

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060001BC RID: 444
		// (set) Token: 0x060001BD RID: 445
		Vector2 offset { get; set; }

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060001BE RID: 446
		// (set) Token: 0x060001BF RID: 447
		Vector2 softness { get; set; }

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060001C0 RID: 448
		// (set) Token: 0x060001C1 RID: 449
		Vector4 ClipRange { get; set; }

		// Token: 0x060001C2 RID: 450
		Vector4 GetBaseRect();

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060001C3 RID: 451
		// (set) Token: 0x060001C4 RID: 452
		Action onMoveDel { get; set; }

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060001C5 RID: 453
		Component UIComponent { get; }
	}
}

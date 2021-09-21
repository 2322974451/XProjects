using System;
using UnityEngine;

namespace UILib
{
	// Token: 0x02000021 RID: 33
	public interface IXUIObject
	{
		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000E5 RID: 229
		GameObject gameObject { get; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000E6 RID: 230
		// (set) Token: 0x060000E7 RID: 231
		IXUIObject parent { get; set; }

		// Token: 0x060000E8 RID: 232
		IXUIObject GetUIObject(string strName);

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000E9 RID: 233
		// (set) Token: 0x060000EA RID: 234
		ulong ID { get; set; }

		// Token: 0x060000EB RID: 235
		bool IsVisible();

		// Token: 0x060000EC RID: 236
		void SetVisible(bool bVisible);

		// Token: 0x060000ED RID: 237
		void OnFocus();

		// Token: 0x060000EE RID: 238
		void Highlight(bool bTrue);

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000EF RID: 239
		// (set) Token: 0x060000F0 RID: 240
		bool Exculsive { get; set; }
	}
}

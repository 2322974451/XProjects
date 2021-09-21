using System;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x020000A0 RID: 160
	public interface IXGameUI : IXInterface
	{
		// Token: 0x060004EA RID: 1258
		void OnGenericClick();

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x060004EB RID: 1259
		// (set) Token: 0x060004EC RID: 1260
		Transform UIRoot { get; set; }

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060004ED RID: 1261
		GameObject[] buttonTpl { get; }

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060004EE RID: 1262
		GameObject[] spriteTpl { get; }

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060004EF RID: 1263
		GameObject DlgControllerTpl { get; }

		// Token: 0x060004F0 RID: 1264
		void SetOverlayAlpha(float alpha);

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x060004F1 RID: 1265
		// (set) Token: 0x060004F2 RID: 1266
		int Base_UI_Width { get; set; }

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060004F3 RID: 1267
		// (set) Token: 0x060004F4 RID: 1268
		int Base_UI_Height { get; set; }

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060004F5 RID: 1269
		// (set) Token: 0x060004F6 RID: 1270
		Camera UICamera { get; set; }
	}
}

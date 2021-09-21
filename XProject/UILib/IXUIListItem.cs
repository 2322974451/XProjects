using System;
using UnityEngine;

namespace UILib
{
	// Token: 0x02000020 RID: 32
	public interface IXUIListItem : IXUIObject
	{
		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000D9 RID: 217
		// (set) Token: 0x060000DA RID: 218
		uint id { get; set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000DB RID: 219
		int Index { get; }

		// Token: 0x060000DC RID: 220
		void SetIconSprite(string strSprite);

		// Token: 0x060000DD RID: 221
		void SetIconSprite(string strSprite, string strAtlas);

		// Token: 0x060000DE RID: 222
		void SetIconTexture(string strTexture);

		// Token: 0x060000DF RID: 223
		void SetTip(string strTip);

		// Token: 0x060000E0 RID: 224
		void SetColor(Color color);

		// Token: 0x060000E1 RID: 225
		bool SetText(uint unIndex, string strText);

		// Token: 0x060000E2 RID: 226
		void SetEnable(bool bEnable);

		// Token: 0x060000E3 RID: 227
		void SetEnableSelect(bool bEnable);

		// Token: 0x060000E4 RID: 228
		void Clear();
	}
}

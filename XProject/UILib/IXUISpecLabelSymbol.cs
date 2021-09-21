using System;
using System.Collections.Generic;
using UnityEngine;

namespace UILib
{
	// Token: 0x02000007 RID: 7
	public interface IXUISpecLabelSymbol : IXUIObject
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600001F RID: 31
		IXUILabel Label { get; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000020 RID: 32
		IXUISprite Board { get; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000021 RID: 33
		IXUISprite[] SpriteList { get; }

		// Token: 0x06000022 RID: 34
		void SetColor(Color color);

		// Token: 0x06000023 RID: 35
		Color GetColor();

		// Token: 0x06000024 RID: 36
		void SetInputText(List<string> sprite);

		// Token: 0x06000025 RID: 37
		void Copy(IXUISpecLabelSymbol other);

		// Token: 0x06000026 RID: 38
		void SetSpriteVisibleFalse(int index);
	}
}

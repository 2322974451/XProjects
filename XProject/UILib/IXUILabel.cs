using System;
using UnityEngine;

namespace UILib
{
	// Token: 0x0200001B RID: 27
	public interface IXUILabel : IXUIObject
	{
		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000AE RID: 174
		float AlphaVar { get; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000AF RID: 175
		// (set) Token: 0x060000B0 RID: 176
		float Alpha { get; set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000B1 RID: 177
		// (set) Token: 0x060000B2 RID: 178
		int spriteWidth { get; set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000B3 RID: 179
		int spriteHeight { get; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000B4 RID: 180
		// (set) Token: 0x060000B5 RID: 181
		int spriteDepth { get; set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000B6 RID: 182
		// (set) Token: 0x060000B7 RID: 183
		int fontSize { get; set; }

		// Token: 0x060000B8 RID: 184
		Color GetColor();

		// Token: 0x060000B9 RID: 185
		string GetText();

		// Token: 0x060000BA RID: 186
		void SetText(string strText);

		// Token: 0x060000BB RID: 187
		void SetRootAsUIPanel(bool bFlag);

		// Token: 0x060000BC RID: 188
		void SetColor(Color c);

		// Token: 0x060000BD RID: 189
		void SetEffectColor(Color c);

		// Token: 0x060000BE RID: 190
		void SetGradient(bool bEnable, Color top, Color bottom);

		// Token: 0x060000BF RID: 191
		void ToggleGradient(bool bEnable);

		// Token: 0x060000C0 RID: 192
		void SetEnabled(bool bEnabled);

		// Token: 0x060000C1 RID: 193
		Vector2 GetPrintSize();

		// Token: 0x060000C2 RID: 194
		void SetDepthOffset(int d);

		// Token: 0x060000C3 RID: 195
		void MakePixelPerfect();

		// Token: 0x060000C4 RID: 196
		void RegisterLabelClickEventHandler(LabelClickEventHandler eventHandler);

		// Token: 0x060000C5 RID: 197
		void SetIdentity(int i);

		// Token: 0x060000C6 RID: 198
		bool HasIdentityChanged(int i);
	}
}

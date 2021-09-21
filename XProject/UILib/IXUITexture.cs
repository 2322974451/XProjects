using System;
using UnityEngine;

namespace UILib
{
	// Token: 0x0200002B RID: 43
	public interface IXUITexture : IXUIObject
	{
		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000111 RID: 273
		// (set) Token: 0x06000112 RID: 274
		int spriteWidth { get; set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000113 RID: 275
		// (set) Token: 0x06000114 RID: 276
		int spriteHeight { get; set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000115 RID: 277
		// (set) Token: 0x06000116 RID: 278
		int spriteDepth { get; set; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000117 RID: 279
		// (set) Token: 0x06000118 RID: 280
		int aspectRatioSource { get; set; }

		// Token: 0x06000119 RID: 281
		void SetTexturePath(string texPath);

		// Token: 0x0600011A RID: 282
		void SetRuntimeTex(Texture tex, bool autoDestroy = true);

		// Token: 0x0600011B RID: 283
		void SetUVRect(Rect rect);

		// Token: 0x0600011C RID: 284
		void RegisterLabelClickEventHandler(TextureClickEventHandler eventHandler);

		// Token: 0x0600011D RID: 285
		void SetEnabled(bool bEnabled);

		// Token: 0x0600011E RID: 286
		void SetColor(Color color);

		// Token: 0x0600011F RID: 287
		void SetAlpha(float alpha);

		// Token: 0x06000120 RID: 288
		void MakePixelPerfect();

		// Token: 0x06000121 RID: 289
		TextureClickEventHandler GetTextureClickHandler();

		// Token: 0x06000122 RID: 290
		void CloseScrollView();

		// Token: 0x06000123 RID: 291
		void SetClickCD(float cd);
	}
}

using System;
using UnityEngine;

namespace UILib
{
	// Token: 0x02000036 RID: 54
	public interface IXUISprite : IXUIObject, IUIWidget, IUIRect, IXUICD
	{
		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000154 RID: 340
		IXUIAtlas uiAtlas { get; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000155 RID: 341
		// (set) Token: 0x06000156 RID: 342
		string spriteName { get; set; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000157 RID: 343
		// (set) Token: 0x06000158 RID: 344
		int spriteWidth { get; set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000159 RID: 345
		// (set) Token: 0x0600015A RID: 346
		int spriteHeight { get; set; }

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x0600015B RID: 347
		// (set) Token: 0x0600015C RID: 348
		int spriteDepth { get; set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x0600015D RID: 349
		string atlasPath { get; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x0600015E RID: 350
		// (set) Token: 0x0600015F RID: 351
		Vector4 drawRegion { get; set; }

		// Token: 0x06000160 RID: 352
		void SetAlpha(float alpha);

		// Token: 0x06000161 RID: 353
		float GetAlpha();

		// Token: 0x06000162 RID: 354
		bool SetSprite(string strSprite, string strAtlas, bool fullAtlasName = false);

		// Token: 0x06000163 RID: 355
		bool SetSprite(string strSprite);

		// Token: 0x06000164 RID: 356
		void SetEnabled(bool bEnabled);

		// Token: 0x06000165 RID: 357
		void SetGrey(bool bGrey);

		// Token: 0x06000166 RID: 358
		void SetColor(Color c);

		// Token: 0x06000167 RID: 359
		void SetAudioClip(string name);

		// Token: 0x06000168 RID: 360
		void CloseScrollView();

		// Token: 0x06000169 RID: 361
		void MakePixelPerfect();

		// Token: 0x0600016A RID: 362
		void RegisterSpriteClickEventHandler(SpriteClickEventHandler eventHandler);

		// Token: 0x0600016B RID: 363
		void RegisterSpritePressEventHandler(SpritePressEventHandler eventHandler);

		// Token: 0x0600016C RID: 364
		void RegisterSpriteDragEventHandler(SpriteDragEventHandler eventHandler);

		// Token: 0x0600016D RID: 365
		void SetRootAsUIPanel(bool bFlag);

		// Token: 0x0600016E RID: 366
		void SetFillAmount(float val);

		// Token: 0x0600016F RID: 367
		void SetFlipHorizontal(bool bValue);

		// Token: 0x06000170 RID: 368
		void SetFlipVertical(bool bValue);

		// Token: 0x06000171 RID: 369
		void ResetAnimationAndPlay();

		// Token: 0x06000172 RID: 370
		SpriteClickEventHandler GetSpriteClickHandler();

		// Token: 0x06000173 RID: 371
		SpritePressEventHandler GetSpritePressHandler();

		// Token: 0x06000174 RID: 372
		void ResetPanel();

		// Token: 0x06000175 RID: 373
		void UpdateAnchors();

		// Token: 0x06000176 RID: 374
		bool IsEnabled();
	}
}

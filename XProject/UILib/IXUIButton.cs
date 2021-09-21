using System;

namespace UILib
{
	// Token: 0x0200000B RID: 11
	public interface IXUIButton : IXUIObject, IXUICD
	{
		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000033 RID: 51
		int spriteWidth { get; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000034 RID: 52
		int spriteHeight { get; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000035 RID: 53
		// (set) Token: 0x06000036 RID: 54
		int spriteDepth { get; set; }

		// Token: 0x06000037 RID: 55
		void SetCaption(string strText);

		// Token: 0x06000038 RID: 56
		void SetEnable(bool bEnable, bool withcollider = false);

		// Token: 0x06000039 RID: 57
		void SetGrey(bool bGrey);

		// Token: 0x0600003A RID: 58
		void SetAlpha(float f);

		// Token: 0x0600003B RID: 59
		void CloseScrollView();

		// Token: 0x0600003C RID: 60
		void RegisterClickEventHandler(ButtonClickEventHandler eventHandler);

		// Token: 0x0600003D RID: 61
		void RegisterPressEventHandler(ButtonPressEventHandler eventHandler);

		// Token: 0x0600003E RID: 62
		void RegisterDragEventHandler(ButtonDragEventHandler eventHandler);

		// Token: 0x0600003F RID: 63
		void SetSpriteWithPrefix(string prefix);

		// Token: 0x06000040 RID: 64
		void SetAudioClip(string name);

		// Token: 0x06000041 RID: 65
		void SetSprites(string normal, string hover, string press);

		// Token: 0x06000042 RID: 66
		ButtonClickEventHandler GetClickEventHandler();

		// Token: 0x06000043 RID: 67
		ButtonPressEventHandler GetPressEventHandler();

		// Token: 0x06000044 RID: 68
		void ResetState();

		// Token: 0x06000045 RID: 69
		void ResetPanel();

		// Token: 0x06000046 RID: 70
		void SetUnavailableCD(int cd);
	}
}

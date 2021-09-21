using System;

namespace UILib
{
	// Token: 0x0200000E RID: 14
	public interface IXUICheckBox : IXUIObject
	{
		// Token: 0x0600004C RID: 76
		void RegisterOnCheckEventHandler(CheckBoxOnCheckEventHandler eventHandler);

		// Token: 0x0600004D RID: 77
		CheckBoxOnCheckEventHandler GetCheckEventHandler();

		// Token: 0x0600004E RID: 78
		void SetEnable(bool bEnable);

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600004F RID: 79
		// (set) Token: 0x06000050 RID: 80
		bool bChecked { get; set; }

		// Token: 0x06000051 RID: 81
		void ForceSetFlag(bool bCheckd);

		// Token: 0x06000052 RID: 82
		void SetAlpha(float f);

		// Token: 0x06000053 RID: 83
		void SetAudioClip(string name);

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000054 RID: 84
		// (set) Token: 0x06000055 RID: 85
		bool bInstantTween { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000056 RID: 86
		// (set) Token: 0x06000057 RID: 87
		int spriteHeight { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000058 RID: 88
		// (set) Token: 0x06000059 RID: 89
		int spriteWidth { get; set; }

		// Token: 0x0600005A RID: 90
		void SetGroup(int group);
	}
}

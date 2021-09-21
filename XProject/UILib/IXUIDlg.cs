using System;

namespace UILib
{
	// Token: 0x02000011 RID: 17
	public interface IXUIDlg
	{
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000066 RID: 102
		IXUIBehaviour uiBehaviourInterface { get; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000067 RID: 103
		string fileName { get; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000068 RID: 104
		int layer { get; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000069 RID: 105
		int group { get; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600006A RID: 106
		bool exclusive { get; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600006B RID: 107
		bool hideMainMenu { get; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600006C RID: 108
		bool pushstack { get; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600006D RID: 109
		bool isMainUI { get; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600006E RID: 110
		bool isHideTutorial { get; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600006F RID: 111
		bool isHideChat { get; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000070 RID: 112
		int sysid { get; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000071 RID: 113
		bool fullscreenui { get; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000072 RID: 114
		bool needOnTop { get; }

		// Token: 0x06000073 RID: 115
		void OnUpdate();

		// Token: 0x06000074 RID: 116
		void OnPostUpdate();

		// Token: 0x06000075 RID: 117
		void Load();

		// Token: 0x06000076 RID: 118
		void UnLoad(bool bTransfer = false);

		// Token: 0x06000077 RID: 119
		void SetVisiblePure(bool bVisible);

		// Token: 0x06000078 RID: 120
		void SetVisible(bool bVisible, bool bEnableAuto = true);

		// Token: 0x06000079 RID: 121
		bool IsVisible();

		// Token: 0x0600007A RID: 122
		void Reset();

		// Token: 0x0600007B RID: 123
		void SetDepthZ(int nDepthZ);

		// Token: 0x0600007C RID: 124
		bool BindReverse(IXUIBehaviour uiBehaviour);

		// Token: 0x0600007D RID: 125
		void SetAlpha(float a);

		// Token: 0x0600007E RID: 126
		void StackRefresh();

		// Token: 0x0600007F RID: 127
		void LeaveStackTop();

		// Token: 0x06000080 RID: 128
		void SetRelatedVisible(bool bVisible);

		// Token: 0x06000081 RID: 129
		int[] GetTitanBarItems();
	}
}

using System;
using UILib;

namespace XMainClient.UI
{
	// Token: 0x020016EB RID: 5867
	internal interface IGVGBattlePrepare : IXUIDlg
	{
		// Token: 0x0600F1FD RID: 61949
		bool IsLoaded();

		// Token: 0x0600F1FE RID: 61950
		void OnEnterSceneFinally();

		// Token: 0x0600F1FF RID: 61951
		void RefreshSection();

		// Token: 0x0600F200 RID: 61952
		void ReFreshGroup();

		// Token: 0x0600F201 RID: 61953
		void RefreshInspire();

		// Token: 0x0600F202 RID: 61954
		void RefreahCountTime(float time);

		// Token: 0x0600F203 RID: 61955
		void SetResurgence(int leftTime);

		// Token: 0x0600F204 RID: 61956
		void UpdateDownUp();
	}
}

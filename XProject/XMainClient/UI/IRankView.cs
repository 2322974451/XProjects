using System;

namespace XMainClient.UI
{
	// Token: 0x0200187E RID: 6270
	internal interface IRankView
	{
		// Token: 0x06010506 RID: 66822
		void RefreshPage();

		// Token: 0x06010507 RID: 66823
		bool IsVisible();

		// Token: 0x06010508 RID: 66824
		void RefreshVoice(ulong[] roleids, int[] states);

		// Token: 0x06010509 RID: 66825
		void HideVoice();
	}
}

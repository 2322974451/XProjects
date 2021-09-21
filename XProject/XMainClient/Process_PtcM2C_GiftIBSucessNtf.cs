using System;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x020014FB RID: 5371
	internal class Process_PtcM2C_GiftIBSucessNtf
	{
		// Token: 0x0600E901 RID: 59649 RVA: 0x00342124 File Offset: 0x00340324
		public static void Process(PtcM2C_GiftIBSucessNtf roPtc)
		{
			DlgBase<PresentDlg, PresentBehaviour>.singleton.OnResPresent(roPtc.Data.openid, roPtc.Data.name);
		}
	}
}

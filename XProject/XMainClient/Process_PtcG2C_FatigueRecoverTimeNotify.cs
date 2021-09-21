using System;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02001064 RID: 4196
	internal class Process_PtcG2C_FatigueRecoverTimeNotify
	{
		// Token: 0x0600D649 RID: 54857 RVA: 0x00325E50 File Offset: 0x00324050
		public static void Process(PtcG2C_FatigueRecoverTimeNotify roPtc)
		{
			DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton.ReceiveFatigueTime(roPtc);
		}
	}
}

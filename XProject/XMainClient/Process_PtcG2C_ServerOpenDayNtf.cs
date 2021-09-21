using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02001388 RID: 5000
	internal class Process_PtcG2C_ServerOpenDayNtf
	{
		// Token: 0x0600E316 RID: 58134 RVA: 0x00339E68 File Offset: 0x00338068
		public static void Process(PtcG2C_ServerOpenDayNtf roPtc)
		{
			XActivityDocument specificDocument = XDocuments.GetSpecificDocument<XActivityDocument>(XActivityDocument.uuID);
			specificDocument.ServerOpenDay = roPtc.Data.openday;
			specificDocument.ServerOpenWeek = (int)roPtc.Data.week;
			specificDocument.SeverOpenSecond = roPtc.Data.daybeginsecdiff;
			specificDocument.ServerTimeSince1970 = roPtc.Data.nowTime;
			bool flag = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.SetActivityEffect(true);
			}
		}
	}
}

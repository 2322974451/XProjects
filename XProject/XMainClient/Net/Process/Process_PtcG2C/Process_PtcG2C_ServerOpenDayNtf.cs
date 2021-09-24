using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class Process_PtcG2C_ServerOpenDayNtf
	{

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

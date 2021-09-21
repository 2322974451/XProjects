using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001269 RID: 4713
	internal class Process_PtcG2C_IBShopIcon
	{
		// Token: 0x0600DE80 RID: 56960 RVA: 0x00333584 File Offset: 0x00331784
		public static void Process(PtcG2C_IBShopIcon roPtc)
		{
			XGameMallDocument specificDocument = XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
			bool flag = specificDocument != null;
			if (flag)
			{
				specificDocument.isNewWeekly = roPtc.Data.limittag;
				specificDocument.hotGoods = roPtc.Data.viptag;
				bool bState = specificDocument.isNewWeekly || specificDocument.isNewVIP;
				XSingleton<XGameSysMgr>.singleton.SetSysRedPointState(XSysDefine.XSys_GameMall, bState);
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_GameMall, true);
			}
		}
	}
}

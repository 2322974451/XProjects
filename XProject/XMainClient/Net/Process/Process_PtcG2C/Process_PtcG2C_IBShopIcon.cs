using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_IBShopIcon
	{

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

using System;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class Process_PtcG2C_FatigueRecoverTimeNotify
	{

		public static void Process(PtcG2C_FatigueRecoverTimeNotify roPtc)
		{
			DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton.ReceiveFatigueTime(roPtc);
		}
	}
}

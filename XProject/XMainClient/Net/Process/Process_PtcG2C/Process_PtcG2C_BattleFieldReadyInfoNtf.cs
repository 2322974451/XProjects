using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class Process_PtcG2C_BattleFieldReadyInfoNtf
	{

		public static void Process(PtcG2C_BattleFieldReadyInfoNtf roPtc)
		{
			bool flag = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._WaitHandler != null && roPtc.Data.failedSpecified && roPtc.Data.failed;
			if (flag)
			{
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._WaitHandler.NextWaitStart();
			}
			bool flag2 = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._WaitHandler != null && roPtc.Data.endSpecified && roPtc.Data.end;
			if (flag2)
			{
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._WaitHandler.SetWaitEnd();
			}
			XSkyArenaEntranceDocument specificDocument = XDocuments.GetSpecificDocument<XSkyArenaEntranceDocument>(XSkyArenaEntranceDocument.uuID);
			specificDocument.SetTime(roPtc.Data.time);
			bool flag3 = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._WaitHandler != null && roPtc.Data.roundSpecified;
			if (flag3)
			{
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._WaitHandler.RefreshMapName((int)roPtc.Data.round);
			}
		}
	}
}

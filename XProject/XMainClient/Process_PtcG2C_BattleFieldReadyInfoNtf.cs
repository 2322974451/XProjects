using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x020015EE RID: 5614
	internal class Process_PtcG2C_BattleFieldReadyInfoNtf
	{
		// Token: 0x0600ECE6 RID: 60646 RVA: 0x00347A64 File Offset: 0x00345C64
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

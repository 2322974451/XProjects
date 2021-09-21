using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x020015B2 RID: 5554
	internal class Process_PtcG2C_HorseFailTipsNtf
	{
		// Token: 0x0600EBEE RID: 60398 RVA: 0x00346614 File Offset: 0x00344814
		public static void Process(PtcG2C_HorseFailTipsNtf roPtc)
		{
			bool flag = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._WaitHandler != null;
			if (flag)
			{
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._WaitHandler.SetWaitEnd();
			}
		}
	}
}

using System;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x0200117B RID: 4475
	internal class Process_PtcG2C_WorldChannelLeftTimesNtf
	{
		// Token: 0x0600DABE RID: 55998 RVA: 0x0032E0EC File Offset: 0x0032C2EC
		public static void Process(PtcG2C_WorldChannelLeftTimesNtf roPtc)
		{
			DlgBase<XChatView, XChatBehaviour>.singleton._worldSpeadTimes = roPtc.Data.leftTimes;
			DlgBase<XChatView, XChatBehaviour>.singleton.RefeshWorldSpeakTimes();
		}
	}
}

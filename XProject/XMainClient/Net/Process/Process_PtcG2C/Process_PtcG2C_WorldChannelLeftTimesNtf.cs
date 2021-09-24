using System;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class Process_PtcG2C_WorldChannelLeftTimesNtf
	{

		public static void Process(PtcG2C_WorldChannelLeftTimesNtf roPtc)
		{
			DlgBase<XChatView, XChatBehaviour>.singleton._worldSpeadTimes = roPtc.Data.leftTimes;
			DlgBase<XChatView, XChatBehaviour>.singleton.RefeshWorldSpeakTimes();
		}
	}
}

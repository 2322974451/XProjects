using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class Process_PtcG2C_HorseFailTipsNtf
	{

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

using System;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcM2C_MSEventNotify
	{

		public static void Process(PtcM2C_MSEventNotify roPtc)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(roPtc.Data.notify, "fece00");
		}
	}
}

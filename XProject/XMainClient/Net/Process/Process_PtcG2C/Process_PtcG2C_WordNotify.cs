using System;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_WordNotify
	{

		public static void Process(PtcG2C_WordNotify roPtc)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(roPtc.Data.hint, "fece00");
		}
	}
}

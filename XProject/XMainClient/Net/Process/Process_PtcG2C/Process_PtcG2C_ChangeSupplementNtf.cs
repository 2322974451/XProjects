using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_ChangeSupplementNtf
	{

		public static void Process(PtcG2C_ChangeSupplementNtf roPtc)
		{
			bool flag = roPtc.Data.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(roPtc.Data.errorcode, "fece00");
			}
		}
	}
}

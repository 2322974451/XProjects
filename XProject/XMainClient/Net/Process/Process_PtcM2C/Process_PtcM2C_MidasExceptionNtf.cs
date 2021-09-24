using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcM2C_MidasExceptionNtf
	{

		public static void Process(PtcM2C_MidasExceptionNtf roPtc)
		{
			bool flag = roPtc.Data.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(roPtc.Data.result, "fece00");
			}
		}
	}
}

using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcT2C_ErrorNotify
	{

		public static void Process(PtcT2C_ErrorNotify roPtc)
		{
			XSingleton<XClientNetwork>.singleton.OnServerErrorNotify(roPtc.Data.errorno, null);
		}
	}
}

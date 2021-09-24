using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_NotifyStartUpTypeToClient
	{

		public static void Process(PtcG2C_NotifyStartUpTypeToClient roPtc)
		{
			XSingleton<XLoginDocument>.singleton.SetLaunchTypeServerInfo(roPtc.Data.type);
		}
	}
}

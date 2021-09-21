using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001583 RID: 5507
	internal class Process_PtcG2C_NotifyStartUpTypeToClient
	{
		// Token: 0x0600EB30 RID: 60208 RVA: 0x00345628 File Offset: 0x00343828
		public static void Process(PtcG2C_NotifyStartUpTypeToClient roPtc)
		{
			XSingleton<XLoginDocument>.singleton.SetLaunchTypeServerInfo(roPtc.Data.type);
		}
	}
}

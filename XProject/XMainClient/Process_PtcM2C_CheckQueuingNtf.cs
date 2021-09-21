using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200120C RID: 4620
	internal class Process_PtcM2C_CheckQueuingNtf
	{
		// Token: 0x0600DCF9 RID: 56569 RVA: 0x003310C0 File Offset: 0x0032F2C0
		public static void Process(PtcM2C_CheckQueuingNtf roPtc)
		{
			ErrorCode errorcode = roPtc.Data.errorcode;
			if (errorcode != ErrorCode.ERR_SUCCESS)
			{
				if (errorcode == ErrorCode.ERR_ACCOUNT_QUEUING)
				{
					XSingleton<XLoginDocument>.singleton.WaitForServerQueue(roPtc.Data.rolecount, roPtc.Data.timeleft);
				}
			}
			else
			{
				XSingleton<XLoginDocument>.singleton.EnterToSelectChar();
			}
		}
	}
}

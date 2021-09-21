using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B6D RID: 2925
	internal class Process_PtcN2C_CheckQueuingNtf
	{
		// Token: 0x0600A926 RID: 43302 RVA: 0x001E1B8C File Offset: 0x001DFD8C
		public static void Process(PtcN2C_CheckQueuingNtf roPtc)
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
